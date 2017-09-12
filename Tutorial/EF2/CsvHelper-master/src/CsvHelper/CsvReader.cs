﻿// Copyright 2009-2017 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using System.Dynamic;
using System.Threading.Tasks;

namespace CsvHelper
{
	/// <summary>
	/// Reads data that was parsed from <see cref="IParser" />.
	/// </summary>
	public class CsvReader : IReader
	{
		private ReadingContext context;
		private bool disposed;
		private IParser parser;

		/// <summary>
		/// Gets the reading context.
		/// </summary>
		public virtual IReaderContext Context => context;

		/// <summary>
		/// Gets the configuration.
		/// </summary>
		public virtual IReaderConfiguration Configuration => context.ReaderConfiguration;

		/// <summary>
		/// Gets the parser.
		/// </summary>
		public virtual IParser Parser => parser;

		/// <summary>
		/// Creates a new CSV reader using the given <see cref="TextReader"/>.
		/// </summary>
		/// <param name="reader">The reader.</param>
		public CsvReader( TextReader reader ) : this( new CsvParser( reader, new Configuration.Configuration(), false ) ) { }

		/// <summary>
		/// Creates a new CSV reader using the given <see cref="TextReader"/>.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="leaveOpen">true to leave the reader open after the CsvReader object is disposed, otherwise false.</param>
		public CsvReader( TextReader reader, bool leaveOpen ) : this( new CsvParser( reader, new Configuration.Configuration(), leaveOpen ) ) { }

		/// <summary>
		/// Creates a new CSV reader using the given <see cref="TextReader"/> and
		/// <see cref="CsvHelper.Configuration.Configuration"/> and <see cref="CsvParser"/> as the default parser.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="configuration">The configuration.</param>
		public CsvReader( TextReader reader, Configuration.Configuration configuration ) : this( new CsvParser( reader, configuration, false ) ) { }

		/// <summary>
		/// Creates a new CSV reader using the given <see cref="TextReader"/>.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="configuration">The configuration.</param>
		/// <param name="leaveOpen">true to leave the reader open after the CsvReader object is disposed, otherwise false.</param>
		public CsvReader( TextReader reader, Configuration.Configuration configuration, bool leaveOpen ) : this( new CsvParser( reader, configuration, leaveOpen ) ) { }

		/// <summary>
		/// Creates a new CSV reader using the given <see cref="IParser" />.
		/// </summary>
		/// <param name="parser">The <see cref="IParser" /> used to parse the CSV file.</param>
		public CsvReader( IParser parser )
		{
			this.parser = parser ?? throw new ArgumentNullException( nameof( parser ) );
			context = parser.Context as ReadingContext ?? throw new InvalidOperationException( "For ICsvParser to be used in CsvReader, ICSvParser.Context must also implement IReaderContext." );
		}

		/// <summary>
		/// Reads the header field without reading the first row.
		/// </summary>
		/// <returns>True if there are more records, otherwise false.</returns>
		public virtual bool ReadHeader()
		{
			if( !context.ReaderConfiguration.HasHeaderRecord )
			{
				throw new ReaderException( context, "Configuration.HasHeaderRecord is false." );
			}

			context.HeaderRecord = context.Record;
			ParseNamedIndexes();

			return context.HeaderRecord != null;
		}

		/// <summary>
		/// Validates the header. A header is bad if all the mapped members don't match.
		/// If the header is not valid, a <see cref="ValidationException"/> will be thrown.
		/// </summary>
		/// <typeparam name="T">The type to validate the header against.</typeparam>
		public virtual void ValidateHeader<T>()
		{
			ValidateHeader( typeof( T ) );
		}

		/// <summary>
		/// Validates the header. A header is bad if all the mapped members don't match.
		/// If the header is not valid, a <see cref="ValidationException"/> will be thrown.
		/// </summary>
		/// <param name="type">The type to validate the header against.</param>
		public virtual void ValidateHeader( Type type )
		{
			if( Configuration.HasHeaderRecord == false )
			{
				throw new InvalidOperationException( $"Validation can't be performed on a the header if no header exists. {nameof( Configuration.HasHeaderRecord )} can't be false." );
			}

			CheckHasBeenRead();

			if( context.HeaderRecord == null )
			{
				throw new InvalidOperationException( $"The header must be read before it can be validated." );
			}

			if( context.ReaderConfiguration.Maps[type] == null )
			{
				context.ReaderConfiguration.Maps.Add( context.ReaderConfiguration.AutoMap( type ) );
			}

			var map = context.ReaderConfiguration.Maps[type];
			ValidateHeader( map );
		}

		/// <summary>
		/// Validates the header against the given map.
		/// </summary>
		/// <param name="map">The map to validate against.</param>
		protected virtual void ValidateHeader( ClassMap map )
		{
			var configSettingMessage = 
				$"If you are expecting some headers to be missing and want to turn this validation check off, " +
				$"set the configuration {nameof( Configuration.ThrowOnBadHeader )} to false.";

			foreach( var parameter in map.ParameterMaps )
			{
				if( parameter.ConstructorTypeMap != null )
				{
					ValidateHeader( parameter.ConstructorTypeMap );
				}
				else if( parameter.ReferenceMap != null )
				{
					ValidateHeader( parameter.ReferenceMap.Data.Mapping );
				}
				else
				{
					var index = GetFieldIndex( parameter.Data.Name, 0, true );
					if( index == -1 )
					{
						throw new ValidationException( context, $"Header '{parameter.Data.Name}' was not found. {configSettingMessage}" );
					}
				}
			}

			foreach( var memberMap in map.MemberMaps )
			{
				if( !CanRead( memberMap ) )
				{
					continue;
				}

				var index = GetFieldIndex( memberMap.Data.Names.ToArray(), memberMap.Data.NameIndex, true );
				if( index == -1 )
				{
					throw new ValidationException( context, $"Header '{memberMap.Data.Names[memberMap.Data.NameIndex]}' was not found. {configSettingMessage}" );
				}
			}

			foreach( var referenceMap in map.ReferenceMaps )
			{
				if( !CanRead( referenceMap ) )
				{
					continue;
				}

				ValidateHeader( referenceMap.Data.Mapping );
			}
		}

		/// <summary>
		/// Advances the reader to the next record. This will not read headers.
		/// You need to call <see cref="Read"/> then <see cref="ReadHeader"/> 
		/// for the headers to be read.
		/// </summary>
		/// <returns>True if there are more records, otherwise false.</returns>
		public virtual bool Read()
		{
			// Don't forget about the async method below!

			do
			{
				context.Record = parser.Read();
			} 
			while( ShouldSkipRecord() );

			context.CurrentIndex = -1;
			context.HasBeenRead = true;

			if( context.ReaderConfiguration.DetectColumnCountChanges && context.Record != null )
			{
				if( context.ColumnCount > 0 && context.ColumnCount != context.Record.Length )
				{
					var csvException = new BadDataException( context, "An inconsistent number of columns has been detected." );

					if( context.ReaderConfiguration.IgnoreReadingExceptions )
					{
						context.ReaderConfiguration.ReadingExceptionCallback?.Invoke( csvException, this );
					}
					else
					{
						throw csvException;
					}
				}

				context.ColumnCount = context.Record.Length;
			}

			return context.Record != null;
		}

		/// <summary>
		/// Advances the reader to the next record. This will not read headers.
		/// You need to call <see cref="ReadAsync"/> then <see cref="ReadHeader"/> 
		/// for the headers to be read.
		/// </summary>
		/// <returns>True if there are more records, otherwise false.</returns>
		public virtual async Task<bool> ReadAsync()
		{
			do
			{
				context.Record = await parser.ReadAsync();
			}
			while( ShouldSkipRecord() );

			context.CurrentIndex = -1;
			context.HasBeenRead = true;

			if( context.ReaderConfiguration.DetectColumnCountChanges && context.Record != null )
			{
				if( context.ColumnCount > 0 && context.ColumnCount != context.Record.Length )
				{
					var csvException = new BadDataException( context, "An inconsistent number of columns has been detected." );

					if( context.ReaderConfiguration.IgnoreReadingExceptions )
					{
						context.ReaderConfiguration.ReadingExceptionCallback?.Invoke( csvException, this );
					}
					else
					{
						throw csvException;
					}
				}

				context.ColumnCount = context.Record.Length;
			}

			return context.Record != null;
		}

		/// <summary>
		/// Gets the raw field at position (column) index.
		/// </summary>
		/// <param name="index">The zero based index of the field.</param>
		/// <returns>The raw field.</returns>
		public virtual string this[int index]
		{
			get
			{
				CheckHasBeenRead();

				return GetField( index );
			}
		}

		/// <summary>
		/// Gets the raw field at position (column) name.
		/// </summary>
		/// <param name="name">The named index of the field.</param>
		/// <returns>The raw field.</returns>
		public virtual string this[string name]
		{
			get
			{
				CheckHasBeenRead();

				return GetField( name );
			}
		}

		/// <summary>
		/// Gets the raw field at position (column) name.
		/// </summary>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the field.</param>
		/// <returns>The raw field.</returns>
		public virtual string this[string name, int index]
		{
			get 
			{
				CheckHasBeenRead();

				return GetField( name, index );
			}
		}

		/// <summary>
		/// Gets the raw field at position (column) index.
		/// </summary>
		/// <param name="index">The zero based index of the field.</param>
		/// <returns>The raw field.</returns>
		public virtual string GetField( int index )
		{
			CheckHasBeenRead();

			// Set the current index being used so we
			// have more information if an error occurs
			// when reading records.
			context.CurrentIndex = index;

			if( index >= context.Record.Length )
			{
				if( context.ReaderConfiguration.ThrowOnMissingField && context.ReaderConfiguration.IgnoreBlankLines )
				{
					throw new MissingFieldException( context, $"Field at index '{index}' does not exist." );
				}

				return default( string );
			}

			var field = context.Record[index];

			return field;
		}

		/// <summary>
		/// Gets the raw field at position (column) name.
		/// </summary>
		/// <param name="name">The named index of the field.</param>
		/// <returns>The raw field.</returns>
		public virtual string GetField( string name )
		{
			CheckHasBeenRead();

			var index = GetFieldIndex( name );
			if( index < 0 )
			{
				return null;
			}

			return GetField( index );
		}

		/// <summary>
		/// Gets the raw field at position (column) name and the index
		/// instance of that field. The index is used when there are
		/// multiple columns with the same header name.
		/// </summary>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <returns>The raw field.</returns>
		public virtual string GetField( string name, int index )
		{
			CheckHasBeenRead();

			var fieldIndex = GetFieldIndex( name, index );
			if( fieldIndex < 0 )
			{
				return null;
			}

			return GetField( fieldIndex );
		}

		/// <summary>
		/// Gets the field converted to <see cref="Object"/> using
		/// the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <param name="type">The type of the field.</param>
		/// <param name="index">The index of the field.</param>
		/// <returns>The field converted to <see cref="Object"/>.</returns>
		public virtual object GetField( Type type, int index )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter( type );
			return GetField( type, index, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="Object"/> using
		/// the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <param name="type">The type of the field.</param>
		/// <param name="name">The named index of the field.</param>
		/// <returns>The field converted to <see cref="Object"/>.</returns>
		public virtual object GetField( Type type, string name )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter( type );
			return GetField( type, name, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="Object"/> using
		/// the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <param name="type">The type of the field.</param>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <returns>The field converted to <see cref="Object"/>.</returns>
		public virtual object GetField( Type type, string name, int index )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter( type );
			return GetField( type, name, index, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="Object"/> using
		/// the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <param name="type">The type of the field.</param>
		/// <param name="index">The index of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="Object"/>.</param>
		/// <returns>The field converted to <see cref="Object"/>.</returns>
		public virtual object GetField( Type type, int index, ITypeConverter converter )
		{
			CheckHasBeenRead();

			context.ReusableMemberMapData.Index = index;
			context.ReusableMemberMapData.TypeConverter = converter;
			if( !context.TypeConverterOptionsCache.TryGetValue( type, out TypeConverterOptions typeConverterOptions ) )
			{
				typeConverterOptions = TypeConverterOptions.Merge( new TypeConverterOptions(), context.ReaderConfiguration.TypeConverterOptionsFactory.GetOptions( type ) );
				typeConverterOptions.CultureInfo = context.ReaderConfiguration.CultureInfo;
				context.TypeConverterOptionsCache.Add( type, typeConverterOptions );
			}

			context.ReusableMemberMapData.TypeConverterOptions = typeConverterOptions;

			var field = GetField( index );
			return converter.ConvertFromString( field, this, context.ReusableMemberMapData );
		}

		/// <summary>
		/// Gets the field converted to <see cref="Object"/> using
		/// the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <param name="type">The type of the field.</param>
		/// <param name="name">The named index of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="Object"/>.</param>
		/// <returns>The field converted to <see cref="Object"/>.</returns>
		public virtual object GetField( Type type, string name, ITypeConverter converter )
		{
			CheckHasBeenRead();

			var index = GetFieldIndex( name );
			return GetField( type, index, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="Object"/> using
		/// the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <param name="type">The type of the field.</param>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="Object"/>.</param>
		/// <returns>The field converted to <see cref="Object"/>.</returns>
		public virtual object GetField( Type type, string name, int index, ITypeConverter converter )
		{
			CheckHasBeenRead();

			var fieldIndex = GetFieldIndex( name, index );
			return GetField( type, fieldIndex, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) index.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <param name="index">The zero based index of the field.</param>
		/// <returns>The field converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetField<T>( int index )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter<T>();
			return GetField<T>( index, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <returns>The field converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetField<T>( string name )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter<T>();
			return GetField<T>( name, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position 
		/// (column) name and the index instance of that field. The index 
		/// is used when there are multiple columns with the same header name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <returns></returns>
		public virtual T GetField<T>( string name, int index )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter<T>();
			return GetField<T>( name, index, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) index using
		/// the given <see cref="ITypeConverter" />.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <param name="index">The zero based index of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</param>
		/// <returns>The field converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetField<T>( int index, ITypeConverter converter )
		{
			CheckHasBeenRead();

			if( index >= context.Record.Length || index < 0 )
			{
				if( context.ReaderConfiguration.ThrowOnMissingField )
				{
					context.CurrentIndex = index;
					throw new MissingFieldException( context, $"Field at index '{index}' does not exist." );
				}

				return default( T );
			}

			return (T)GetField( typeof( T ), index, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name using
		/// the given <see cref="ITypeConverter" />.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</param>
		/// <returns>The field converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetField<T>( string name, ITypeConverter converter )
		{
			CheckHasBeenRead();

			var index = GetFieldIndex( name );
			return GetField<T>( index, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position 
		/// (column) name and the index instance of that field. The index 
		/// is used when there are multiple columns with the same header name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</param>
		/// <returns>The field converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetField<T>( string name, int index, ITypeConverter converter )
		{
			CheckHasBeenRead();

			var fieldIndex = GetFieldIndex( name, index );
			return GetField<T>( fieldIndex, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) index using
		/// the given <see cref="ITypeConverter" />.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <typeparam name="TConverter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</typeparam>
		/// <param name="index">The zero based index of the field.</param>
		/// <returns>The field converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetField<T, TConverter>( int index ) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();

			var converter = ReflectionHelper.CreateInstance<TConverter>();
			return GetField<T>( index, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name using
		/// the given <see cref="ITypeConverter" />.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <typeparam name="TConverter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <returns>The field converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetField<T, TConverter>( string name ) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();

			var converter = ReflectionHelper.CreateInstance<TConverter>();
			return GetField<T>( name, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position 
		/// (column) name and the index instance of that field. The index 
		/// is used when there are multiple columns with the same header name.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <typeparam name="TConverter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <returns>The field converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetField<T, TConverter>( string name, int index ) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();

			var converter = ReflectionHelper.CreateInstance<TConverter>();
			return GetField<T>( name, index, converter );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) index.
		/// </summary>
		/// <param name="type">The <see cref="System.Type"/> of the field.</param>
		/// <param name="index">The zero based index of the field.</param>
		/// <param name="field">The field converted to type T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField( Type type, int index, out object field )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter( type );
			return TryGetField( type, index, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name.
		/// </summary>
		/// <param name="type">The <see cref="System.Type"/> of the field.</param>
		/// <param name="name">The named index of the field.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField( Type type, string name, out object field )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter( type );
			return TryGetField( type, name, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position 
		/// (column) name and the index instance of that field. The index 
		/// is used when there are multiple columns with the same header name.
		/// </summary>
		/// <param name="type">The <see cref="System.Type"/> of the field.</param>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField( Type type, string name, int index, out object field )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter( type );
			return TryGetField( type, name, index, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) index
		/// using the specified <see cref="ITypeConverter" />.
		/// </summary>
		/// <param name="type">The <see cref="System.Type"/> of the field.</param>
		/// <param name="index">The zero based index of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField( Type type, int index, ITypeConverter converter, out object field )
		{
			CheckHasBeenRead();

			// DateTimeConverter.ConvertFrom will successfully convert
			// a white space string to a DateTime.MinValue instead of
			// returning null, so we need to handle this special case.
			if( converter is DateTimeConverter )
			{
				if( string.IsNullOrWhiteSpace( context.Record[index] ) )
				{
					field = type.GetTypeInfo().IsValueType ? ReflectionHelper.CreateInstance( type ) : null;
					return false;
				}
			}

			// TypeConverter.IsValid() just wraps a
			// ConvertFrom() call in a try/catch, so lets not
			// do it twice and just do it ourselves.
			try
			{
				field = GetField( type, index, converter );
				return true;
			}
			catch
			{
				field = type.GetTypeInfo().IsValueType ? ReflectionHelper.CreateInstance( type ) : null;
				return false;
			}
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name
		/// using the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <param name="type">The <see cref="System.Type"/> of the field.</param>
		/// <param name="name">The named index of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField( Type type, string name, ITypeConverter converter, out object field )
		{
			CheckHasBeenRead();

			var index = GetFieldIndex( name, isTryGet: true );
			if( index == -1 )
			{
				field = type.GetTypeInfo().IsValueType ? ReflectionHelper.CreateInstance( type ) : null;
				return false;
			}

			return TryGetField( type, index, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name
		/// using the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <param name="type">The <see cref="System.Type"/> of the field.</param>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField( Type type, string name, int index, ITypeConverter converter, out object field )
		{
			CheckHasBeenRead();

			var fieldIndex = GetFieldIndex( name, index, true );
			if( fieldIndex == -1 )
			{
				field = type.GetTypeInfo().IsValueType ? ReflectionHelper.CreateInstance( type ) : null;
				return false;
			}

			return TryGetField( type, fieldIndex, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) index.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <param name="index">The zero based index of the field.</param>
		/// <param name="field">The field converted to type T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField<T>( int index, out T field )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter<T>();
			return TryGetField( index, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField<T>( string name, out T field )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter<T>();
			return TryGetField( name, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position 
		/// (column) name and the index instance of that field. The index 
		/// is used when there are multiple columns with the same header name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField<T>( string name, int index, out T field )
		{
			CheckHasBeenRead();

			var converter = Configuration.TypeConverterFactory.GetConverter<T>();
			return TryGetField( name, index, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) index
		/// using the specified <see cref="ITypeConverter" />.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <param name="index">The zero based index of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField<T>( int index, ITypeConverter converter, out T field )
		{
			CheckHasBeenRead();

			// TypeConverter.IsValid() just wraps a
			// ConvertFrom() call in a try/catch, so lets not
			// do it twice and just do it ourselves.
			try
			{
				field = GetField<T>( index, converter );
				return true;
			}
			catch
			{
				field = default( T );
				return false;
			}
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name
		/// using the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField<T>( string name, ITypeConverter converter, out T field )
		{
			CheckHasBeenRead();

			var index = GetFieldIndex( name, isTryGet: true );
			if( index == -1 )
			{
				field = default( T );
				return false;
			}

			return TryGetField( index, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name
		/// using the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <param name="converter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField<T>( string name, int index, ITypeConverter converter, out T field )
		{
			CheckHasBeenRead();

			var fieldIndex = GetFieldIndex( name, index, true );
			if( fieldIndex == -1 )
			{
				field = default( T );
				return false;
			}

			return TryGetField( fieldIndex, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) index
		/// using the specified <see cref="ITypeConverter" />.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <typeparam name="TConverter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</typeparam>
		/// <param name="index">The zero based index of the field.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField<T, TConverter>( int index, out T field ) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();

			var converter = ReflectionHelper.CreateInstance<TConverter>();
			return TryGetField( index, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name
		/// using the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <typeparam name="TConverter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField<T, TConverter>( string name, out T field ) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();

			var converter = ReflectionHelper.CreateInstance<TConverter>();
			return TryGetField( name, converter, out field );
		}

		/// <summary>
		/// Gets the field converted to <see cref="System.Type"/> T at position (column) name
		/// using the specified <see cref="ITypeConverter"/>.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the field.</typeparam>
		/// <typeparam name="TConverter">The <see cref="ITypeConverter"/> used to convert the field to <see cref="System.Type"/> T.</typeparam>
		/// <param name="name">The named index of the field.</param>
		/// <param name="index">The zero based index of the instance of the field.</param>
		/// <param name="field">The field converted to <see cref="System.Type"/> T.</param>
		/// <returns>A value indicating if the get was successful.</returns>
		public virtual bool TryGetField<T, TConverter>( string name, int index, out T field ) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();

			var converter = ReflectionHelper.CreateInstance<TConverter>();
			return TryGetField( name, index, converter, out field );
		}

		/// <summary>
		/// Determines whether the current record is empty.
		/// A record is considered empty if all fields are empty.
		/// </summary>
		/// <returns>
		///   <c>true</c> if [is record empty]; otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsRecordEmpty()
		{
			return IsRecordEmpty( true );
		}

		/// <summary>
		/// Gets the record converted into <see cref="System.Type"/> T.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the record.</typeparam>
		/// <returns>The record converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetRecord<T>() 
		{
			CheckHasBeenRead();

			if( context.HeaderRecord == null && context.ReaderConfiguration.HasHeaderRecord )
			{
				ReadHeader();
				if( Configuration.ThrowOnBadHeader )
				{
					ValidateHeader<T>();
				}

				if( !Read() )
				{
					return default( T );
				}
			}

			T record;
			try
			{
				record = CreateRecord<T>();
			}
			catch( Exception ex )
			{
				throw ex as CsvHelperException ?? new ReaderException( context, "An unexpected error occurred.", ex );
			}

			return record;
		}

		/// <summary>
		/// Get the record converted into <see cref="System.Type"/> T.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the record.</typeparam>
		/// <param name="anonymousTypeDefinition">The anonymous type definition to use for the record.</param>
		/// <returns>The record converted to <see cref="System.Type"/> T.</returns>
		public virtual T GetRecord<T>( T anonymousTypeDefinition )
		{
			if( anonymousTypeDefinition == null )
			{
				throw new ArgumentNullException( nameof( anonymousTypeDefinition ) );
			}

			if( !anonymousTypeDefinition.GetType().IsAnonymous() )
			{
				throw new ArgumentException( $"Argument is not an anonymous type.", nameof( anonymousTypeDefinition ) );
			}

			return GetRecord<T>();
		}

		/// <summary>
		/// Gets the record.
		/// </summary>
		/// <param name="type">The <see cref="System.Type"/> of the record.</param>
		/// <returns>The record.</returns>
		public virtual object GetRecord( Type type )
		{
			CheckHasBeenRead();

			if( context.HeaderRecord == null && context.ReaderConfiguration.HasHeaderRecord )
			{
				ReadHeader();
				if( Configuration.ThrowOnBadHeader )
				{
					ValidateHeader( type );
				}

				if( !Read() )
				{
					return null;
				}
			}

			object record;
			try
			{
				record = CreateRecord( type );
			}
			catch( Exception ex )
			{
				var csvHelperException = ex as CsvHelperException ?? new ReaderException( context, "An unexpected error occurred.", ex );
				throw csvHelperException;
			}

			return record;
		}

		/// <summary>
		/// Gets all the records in the CSV file and
		/// converts each to <see cref="System.Type"/> T. The Read method
		/// should not be used when using this.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the record.</typeparam>
		/// <returns>An <see cref="IEnumerable{T}" /> of records.</returns>
		public virtual IEnumerable<T> GetRecords<T>() 
		{
			// Don't need to check if it's been read
			// since we're doing the reading ourselves.

			if( context.ReaderConfiguration.HasHeaderRecord && context.HeaderRecord == null )
			{
				if( !Read() )
				{
					yield break;
				}

				ReadHeader();
				if( Configuration.ThrowOnBadHeader )
				{
					ValidateHeader<T>();
				}
			}

			while( Read() )
			{
				T record;
				try
				{
					record = CreateRecord<T>();
				}
				catch( Exception ex )
				{
					var csvHelperException = ex as CsvHelperException ?? new ReaderException( context, "An unexpected error occurred.", ex );

					if( context.ReaderConfiguration.IgnoreReadingExceptions )
					{
						context.ReaderConfiguration.ReadingExceptionCallback?.Invoke( csvHelperException, this );

						continue;
					}

					throw csvHelperException;
				}

				yield return record;
			}
		}

		/// <summary>
		/// Gets all the records in the CSV file and converts
		/// each to <see cref="System.Type"/> T. The read method
		/// should not be used when using this.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the record.</typeparam>
		/// <param name="anonymousTypeDefinition">The anonymous type definition to use for the records.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of records.</returns>
		public virtual IEnumerable<T> GetRecords<T>( T anonymousTypeDefinition )
		{
			if( anonymousTypeDefinition == null )
			{
				throw new ArgumentNullException( nameof( anonymousTypeDefinition ) );
			}

			if( !anonymousTypeDefinition.GetType().IsAnonymous() )
			{
				throw new ArgumentException( $"Argument is not an anonymous type.", nameof( anonymousTypeDefinition ) );
			}

			return GetRecords<T>();
		}

		/// <summary>
		/// Gets all the records in the CSV file and
		/// converts each to <see cref="System.Type"/> T. The Read method
		/// should not be used when using this.
		/// </summary>
		/// <param name="type">The <see cref="System.Type"/> of the record.</param>
		/// <returns>An <see cref="IEnumerable{Object}" /> of records.</returns>
		public virtual IEnumerable<object> GetRecords( Type type )
		{
			// Don't need to check if it's been read
			// since we're doing the reading ourselves.

			if( context.ReaderConfiguration.HasHeaderRecord && context.HeaderRecord == null )
			{
				if( !Read() )
				{
					yield break;
				}

				ReadHeader();
				if( Configuration.ThrowOnBadHeader )
				{
					ValidateHeader( type );
				}
			}

			while( Read() )
			{
				object record;
				try
				{
					record = CreateRecord( type );
				}
				catch( Exception ex )
				{
					var csvHelperException = ex as CsvHelperException ?? new ReaderException( context, "An unexpected error occurred.", ex );

					if( context.ReaderConfiguration.IgnoreReadingExceptions )
					{
						context.ReaderConfiguration.ReadingExceptionCallback?.Invoke( csvHelperException, this );

						continue;
					}

					throw csvHelperException;
				}

				yield return record;
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			Dispose( !context.LeaveOpen );
			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <param name="disposing">True if the instance needs to be disposed of.</param>
		protected virtual void Dispose( bool disposing )
		{
			if( disposed )
			{
				return;
			}

			if( disposing )
			{
				parser?.Dispose();
			}

			parser = null;
			context = null;
			disposed = true;
		}

		/// <summary>
		/// Checks if the reader has been read yet.
		/// </summary>
		/// <exception cref="ReaderException" />
		protected virtual void CheckHasBeenRead()
		{
			if( !context.HasBeenRead )
			{
				throw new ReaderException( context, "You must call read on the reader before accessing its data." );
			}
		}

		/// <summary>
		/// Determines whether the current record is empty.
		/// A record is considered empty if all fields are empty.
		/// </summary>
		/// <param name="checkHasBeenRead">True to check if the record 
		/// has been read, otherwise false.</param>
		/// <returns>
		///   <c>true</c> if [is record empty]; otherwise, <c>false</c>.
		/// </returns>
		protected virtual bool IsRecordEmpty( bool checkHasBeenRead )
		{
			if( checkHasBeenRead )
			{
				CheckHasBeenRead();
			}

			if( context.Record == null )
			{
				return false;
			}

			return context.Record.All( GetEmtpyStringMethod() );
		}

		/// <summary>
		/// Gets a function to test for an empty string.
		/// </summary>
		/// <returns>The function to test for an empty string.</returns>
		protected virtual Func<string, bool> GetEmtpyStringMethod()
		{ 
			return string.IsNullOrWhiteSpace;
		}
	
		/// <summary>
		/// Gets the index of the field at name if found.
		/// </summary>
		/// <param name="name">The name of the field to get the index for.</param>
		/// <param name="index">The index of the field if there are multiple fields with the same name.</param>
		/// <param name="isTryGet">A value indicating if the call was initiated from a TryGet.</param>
		/// <returns>The index of the field if found, otherwise -1.</returns>
		/// <exception cref="ReaderException">Thrown if there is no header record.</exception>
		/// <exception cref="MissingFieldException">Thrown if there isn't a field with name.</exception>
		protected virtual int GetFieldIndex( string name, int index = 0, bool isTryGet = false )
		{
			return GetFieldIndex( new[] { name }, index, isTryGet );
		}

		/// <summary>
		/// Gets the index of the field at name if found.
		/// </summary>
		/// <param name="names">The possible names of the field to get the index for.</param>
		/// <param name="index">The index of the field if there are multiple fields with the same name.</param>
		/// <param name="isTryGet">A value indicating if the call was initiated from a TryGet.</param>
		/// <returns>The index of the field if found, otherwise -1.</returns>
		/// <exception cref="ReaderException">Thrown if there is no header record.</exception>
		/// <exception cref="MissingFieldException">Thrown if there isn't a field with name.</exception>
		protected virtual int GetFieldIndex( string[] names, int index = 0, bool isTryGet = false )
		{
			if( names == null )
			{
				throw new ArgumentNullException( nameof( names ) );
			}

			if( !context.ReaderConfiguration.HasHeaderRecord )
			{
				throw new ReaderException( context, "There is no header record to determine the index by name." );
			}

            // Caching the named index speeds up mappings that use ConvertUsing tremendously.
		    var nameKey = string.Join( "_", names ) + index;
		    if( context.NamedIndexCache.ContainsKey( nameKey ) )
		    {
		        var tuple = context.NamedIndexCache[nameKey];
		        return context.NamedIndexes[tuple.Item1][tuple.Item2];
		    }

			string name = null;
			foreach( var pair in context.NamedIndexes )
			{
				var memberName = context.ReaderConfiguration.PrepareHeaderForMatch( pair.Key );
				foreach( var n in names )
				{
					var fieldName = context.ReaderConfiguration.PrepareHeaderForMatch( n );
					if( Configuration.CultureInfo.CompareInfo.Compare( memberName, fieldName, CompareOptions.None ) == 0 )
					{
						name = pair.Key;
					}
				}
			}

			if( name == null || index >= context.NamedIndexes[name].Count )
			{
				if( context.ReaderConfiguration.ThrowOnMissingField && !isTryGet )
				{
					// If we're in strict reading mode and the
					// named index isn't found, throw an exception.
					var namesJoined = $"'{string.Join( "', '", names )}'";
					throw new MissingFieldException( context, $"Fields {namesJoined} do not exist in the CSV file." );
				}

				return -1;
			}

			context.NamedIndexCache.Add( nameKey, new Tuple<string, int>( name, index ) );

			return context.NamedIndexes[name][index];
		}

		/// <summary>
		/// Parses the named indexes from the header record.
		/// </summary>
		protected virtual void ParseNamedIndexes()
		{
			if( context.HeaderRecord == null )
			{
				throw new ReaderException( context, "No header record was found." );
			}

			for( var i = 0; i < context.HeaderRecord.Length; i++ )
			{
				var name = context.HeaderRecord[i];
				if( context.NamedIndexes.ContainsKey( name ) )
				{
					context.NamedIndexes[name].Add( i );
				}
				else
				{
					context.NamedIndexes[name] = new List<int> { i };
				}
			}
		}

		/// <summary>
		/// Checks if the current record should be skipped or not.
		/// </summary>
		/// <returns><c>true</c> if the current record should be skipped, <c>false</c> otherwise.</returns>
		protected virtual bool ShouldSkipRecord()
		{
			if( context.Record == null )
			{
				return false;
			}

			return context.ReaderConfiguration.ShouldSkipRecord != null
				? context.ReaderConfiguration.ShouldSkipRecord( context.Record ) || ( context.ReaderConfiguration.SkipEmptyRecords && IsRecordEmpty( false ) )
				: context.ReaderConfiguration.SkipEmptyRecords && IsRecordEmpty( false );
		}

		/// <summary>
		/// Creates the record for the given type.
		/// </summary>
		/// <typeparam name="T">The type of record to create.</typeparam>
		/// <returns>The created record.</returns>
		protected virtual T CreateRecord<T>() 
		{
			// If the type is an object, a dynamic
			// object will be created. That is the
			// only way we can dynamically add properties
			// to a type of object.
			if( typeof( T ) == typeof( object ) )
			{
				return CreateDynamic();
			}

			return GetReadRecordFunc<T>()();
		}

		/// <summary>
		/// Creates the record for the given type.
		/// </summary>
		/// <param name="type">The type of record to create.</param>
		/// <returns>The created record.</returns>
		protected virtual object CreateRecord( Type type )
		{
			// If the type is an object, a dynamic
			// object will be created. That is the
			// only way we can dynamically add properties
			// to a type of object.
			if( type == typeof( object ) )
			{
				return CreateDynamic();
			}

			try
			{
				return GetReadRecordFunc( type ).DynamicInvoke();
			}
			catch( TargetInvocationException ex )
			{
				throw ex.InnerException;
			}
		}

		/// <summary>
		/// Gets the function delegate used to populate
		/// a custom class object with data from the reader.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of object that is created
		/// and populated.</typeparam>
		/// <returns>The function delegate.</returns>
		protected virtual Func<T> GetReadRecordFunc<T>() 
		{
			var recordType = typeof( T );
			CreateReadRecordFunc( recordType );

			return (Func<T>)context.RecordFuncs[recordType];
		}

		/// <summary>
		/// Gets the function delegate used to populate
		/// a custom class object with data from the reader.
		/// </summary>
		/// <param name="recordType">The <see cref="System.Type"/> of object that is created
		/// and populated.</param>
		/// <returns>The function delegate.</returns>
		protected virtual Delegate GetReadRecordFunc( Type recordType )
		{
			CreateReadRecordFunc( recordType );

			return context.RecordFuncs[recordType];
		}

		/// <summary>
		/// Creates the read record func for the given type if it
		/// doesn't already exist.
		/// </summary>
		/// <param name="recordType">Type of the record.</param>
		protected virtual void CreateReadRecordFunc( Type recordType )
		{
			if( context.RecordFuncs.ContainsKey( recordType ) )
			{
				return;
			}

			if( context.ReaderConfiguration.Maps[recordType] == null )
			{
				context.ReaderConfiguration.Maps.Add( context.ReaderConfiguration.AutoMap( recordType ) );
			}

			if( recordType.GetTypeInfo().IsPrimitive )
			{
				CreateFuncForPrimitive( recordType );
			}
			else
			{
				CreateFuncForObject( recordType );
			}
		}

		/// <summary>
		/// Creates the function for an object.
		/// </summary>
		/// <param name="recordType">The type of object to create the function for.</param>
		protected virtual void CreateFuncForObject( Type recordType )
		{
			var map = context.ReaderConfiguration.Maps[recordType];
			Expression body;

			if( map.ParameterMaps.Count > 0 )
			{
				// This is a constructor paramter type.
				var arguments = new List<Expression>();
				CreateConstructorArgumentExpressionsForMapping( map, arguments );

				body = Expression.New( Configuration.GetConstructor( map.ClassType ), arguments );
			}
			else
			{
				var bindings = new List<MemberBinding>();
				CreateMemberBindingsForMapping( map, recordType, bindings );

				if( bindings.Count == 0 )
				{
					throw new ReaderException( context, $"No members are mapped for type '{recordType.FullName}'." );
				}

				if( map.Constructor is NewExpression )
				{
					body = Expression.MemberInit( (NewExpression)map.Constructor, bindings );
				}
				else if( map.Constructor is MemberInitExpression )
				{
					var memberInitExpression = (MemberInitExpression)map.Constructor;
					var defaultBindings = memberInitExpression.Bindings.ToList();
					defaultBindings.AddRange( bindings );
					body = Expression.MemberInit( memberInitExpression.NewExpression, defaultBindings );
				}
				else
				{
					// This is in case an IContractResolver is being used.
					var type = ReflectionHelper.CreateInstance( recordType ).GetType();
					body = Expression.MemberInit( Expression.New( type ), bindings );
				}
			}

			var funcType = typeof( Func<> ).MakeGenericType( recordType );
			context.RecordFuncs[recordType] = Expression.Lambda( funcType, body ).Compile();
		}

		/// <summary>
		/// Creates the function for a primitive.
		/// </summary>
		/// <param name="recordType">The type of the primitive to create the function for.</param>
		protected virtual void CreateFuncForPrimitive( Type recordType )
		{
			var method = typeof( IReaderRow ).GetProperty( "Item", typeof( string ), new[] { typeof( int ) } ).GetGetMethod();
			Expression fieldExpression = Expression.Call( Expression.Constant( this ), method, Expression.Constant( 0, typeof( int ) ) );

			var memberMapData = new MemberMapData( null )
			{
				Index = 0,
				TypeConverter = Configuration.TypeConverterFactory.GetConverter( recordType )
			};
			memberMapData.TypeConverterOptions = TypeConverterOptions.Merge( new TypeConverterOptions(), context.ReaderConfiguration.TypeConverterOptionsFactory.GetOptions( recordType ) );
			memberMapData.TypeConverterOptions.CultureInfo = context.ReaderConfiguration.CultureInfo;

			fieldExpression = Expression.Call( Expression.Constant( memberMapData.TypeConverter ), "ConvertFromString", null, fieldExpression, Expression.Constant( this ), Expression.Constant( memberMapData ) );
			fieldExpression = Expression.Convert( fieldExpression, recordType );
	
			var funcType = typeof( Func<> ).MakeGenericType( recordType );
			context.RecordFuncs[recordType] = Expression.Lambda( funcType, fieldExpression ).Compile();
		}

		/// <summary>
		/// Creates the constructor arguments used to create a type.
		/// </summary>
		/// <param name="map">The mapping to create the arguments for.</param>
		/// <param name="argumentExpressions">The arguments that will be added to the mapping.</param>
		protected virtual void CreateConstructorArgumentExpressionsForMapping( ClassMap map, List<Expression> argumentExpressions )
		{
			foreach( var parameterMap in map.ParameterMaps )
			{
				if( parameterMap.ConstructorTypeMap != null )
				{
					// Constructor paramter type.
					var arguments = new List<Expression>();
					CreateConstructorArgumentExpressionsForMapping( parameterMap.ConstructorTypeMap, arguments );
					var constructorExpression = Expression.New( Configuration.GetConstructor( parameterMap.ConstructorTypeMap.ClassType ), arguments );

					argumentExpressions.Add( constructorExpression );
				}
				else if( parameterMap.ReferenceMap != null )
				{
					// Reference type.

					var referenceBindings = new List<MemberBinding>();
					CreateMemberBindingsForMapping( parameterMap.ReferenceMap.Data.Mapping, parameterMap.ReferenceMap.Data.Parameter.ParameterType, referenceBindings );

					// This is in case an IContractResolver is being used.
					var type = ReflectionHelper.CreateInstance( parameterMap.ReferenceMap.Data.Parameter.ParameterType ).GetType();
					var referenceBody = Expression.MemberInit( Expression.New( type ), referenceBindings );

					argumentExpressions.Add( referenceBody );
				}
				else
				{
					// Value type.

					var index = Configuration.HasHeaderRecord
						? GetFieldIndex( parameterMap.Data.Name, 0 )
						: parameterMap.Data.Index;

					// Get the field using the field index.
					var method = typeof( IReaderRow ).GetProperty( "Item", typeof( string ), new[] { typeof( int ) } ).GetGetMethod();
					Expression fieldExpression = Expression.Call( Expression.Constant( this ), method, Expression.Constant( index, typeof( int ) ) );

					// Convert the field.
					var typeConverterExpression = Expression.Constant( parameterMap.Data.TypeConverter );
					parameterMap.Data.TypeConverterOptions = TypeConverterOptions.Merge( new TypeConverterOptions(), context.ReaderConfiguration.TypeConverterOptionsFactory.GetOptions( parameterMap.Data.Parameter.ParameterType ), parameterMap.Data.TypeConverterOptions );
					parameterMap.Data.TypeConverterOptions.CultureInfo = context.ReaderConfiguration.CultureInfo;

					// Create type converter expression.
					var memberMapData = new MemberMapData( null )
					{
						Index = parameterMap.Data.Index,
						TypeConverter = parameterMap.Data.TypeConverter,
						TypeConverterOptions = parameterMap.Data.TypeConverterOptions
					};
					memberMapData.Names.Add( parameterMap.Data.Name );
					Expression typeConverterFieldExpression = Expression.Call( typeConverterExpression, nameof( ITypeConverter.ConvertFromString ), null, fieldExpression, Expression.Constant( this ), Expression.Constant( memberMapData ) );
					typeConverterFieldExpression = Expression.Convert( typeConverterFieldExpression, parameterMap.Data.Parameter.ParameterType );

					fieldExpression = typeConverterFieldExpression;

					argumentExpressions.Add( fieldExpression );
				}
			}
		}

		/// <summary>
		/// Creates the member bindings for the given <see cref="ClassMap"/>.
		/// </summary>
		/// <param name="mapping">The mapping to create the bindings for.</param>
		/// <param name="recordType">The type of record.</param>
		/// <param name="bindings">The bindings that will be added to from the mapping.</param>
		protected virtual void CreateMemberBindingsForMapping( ClassMap mapping, Type recordType, List<MemberBinding> bindings )
		{
			AddMemberBindings( mapping.MemberMaps, bindings );

			foreach( var referenceMap in mapping.ReferenceMaps )
			{
				if( !CanRead( referenceMap ) )
				{
					continue;
				}

				var referenceBindings = new List<MemberBinding>();
				CreateMemberBindingsForMapping( referenceMap.Data.Mapping, referenceMap.Data.Member.MemberType(), referenceBindings );

				Expression referenceBody;
				var constructorExpression = referenceMap.Data.Mapping.Constructor;
				if( constructorExpression is NewExpression )
				{
					referenceBody = Expression.MemberInit( (NewExpression)constructorExpression, referenceBindings );
				}
				else if( constructorExpression is MemberInitExpression )
				{
					var memberInitExpression = (MemberInitExpression)constructorExpression;
					var defaultBindings = memberInitExpression.Bindings.ToList();
					defaultBindings.AddRange( referenceBindings );
					referenceBody = Expression.MemberInit( memberInitExpression.NewExpression, defaultBindings );
				}
				else
				{
					// This is in case an IContractResolver is being used.
					var type = ReflectionHelper.CreateInstance( referenceMap.Data.Member.MemberType() ).GetType();
					referenceBody = Expression.MemberInit( Expression.New( type ), referenceBindings );
				}

				bindings.Add( Expression.Bind( referenceMap.Data.Member, referenceBody ) );
			}
		}

		/// <summary>
		/// Adds a <see cref="MemberBinding"/> for each member for it's field.
		/// </summary>
		/// <param name="members">The members to add bindings for.</param>
		/// <param name="bindings">The bindings that will be added to from the members.</param>
		protected virtual void AddMemberBindings( MemberMapCollection members, List<MemberBinding> bindings )
		{
			foreach( var memberMap in members )
			{
				if( memberMap.Data.ReadingConvertExpression != null )
				{
					// The user is providing the expression to do the conversion.
					Expression exp = Expression.Invoke( memberMap.Data.ReadingConvertExpression, Expression.Constant( this ) );
					exp = Expression.Convert( exp, memberMap.Data.Member.MemberType() );
					bindings.Add( Expression.Bind( memberMap.Data.Member, exp ) );
					continue;
				}

				if( !CanRead( memberMap ) )
				{
					continue;
				}

				if( memberMap.Data.TypeConverter == null )
				{
					// Skip if the type isn't convertible.
					continue;
				}

				int index;
				if( memberMap.Data.IsNameSet || context.ReaderConfiguration.HasHeaderRecord && !memberMap.Data.IsIndexSet )
				{
					// Use the name.
					index = GetFieldIndex( memberMap.Data.Names.ToArray(), memberMap.Data.NameIndex );
					if( index == -1 )
					{
						// Skip if the index was not found.
						continue;
					}
				}
				else
				{
					// Use the index.
					index = memberMap.Data.Index;
				}

				// Get the field using the field index.
				var method = typeof( IReaderRow ).GetProperty( "Item", typeof( string ), new[] { typeof( int ) } ).GetGetMethod();
				Expression fieldExpression = Expression.Call( Expression.Constant( this ), method, Expression.Constant( index, typeof( int ) ) );

				// Validate the field.
				if( memberMap.Data.ValidateExpression != null )
				{
					var validateExpression = Expression.IsFalse( Expression.Invoke( memberMap.Data.ValidateExpression, fieldExpression ) );
					var validationExceptionConstructor = typeof( ValidationException ).GetConstructors().OrderBy( c => c.GetParameters().Length ).First();
					var throwExpression = Expression.Throw( Expression.Constant( new ValidationException( context ) ) );
					fieldExpression = Expression.Block(
						// If the validate method returns false, throw an exception.
						Expression.IfThen( validateExpression, throwExpression ),
						fieldExpression
					);
				}

				// Convert the field.
				var typeConverterExpression = Expression.Constant( memberMap.Data.TypeConverter );
				memberMap.Data.TypeConverterOptions = TypeConverterOptions.Merge( new TypeConverterOptions(), context.ReaderConfiguration.TypeConverterOptionsFactory.GetOptions( memberMap.Data.Member.MemberType() ), memberMap.Data.TypeConverterOptions );
				memberMap.Data.TypeConverterOptions.CultureInfo = context.ReaderConfiguration.CultureInfo;

				// Create type converter expression.
				Expression typeConverterFieldExpression = Expression.Call( typeConverterExpression, nameof( ITypeConverter.ConvertFromString ), null, fieldExpression, Expression.Constant( this ), Expression.Constant( memberMap.Data ) );
				typeConverterFieldExpression = Expression.Convert( typeConverterFieldExpression, memberMap.Data.Member.MemberType() );

				if( memberMap.Data.IsConstantSet )
				{
					fieldExpression = Expression.Convert( Expression.Constant( memberMap.Data.Constant ), memberMap.Data.Member.MemberType() );
				}
				else if( memberMap.Data.IsDefaultSet )
				{
					// Create default value expression.
					Expression defaultValueExpression;
					if( memberMap.Data.Member.MemberType() != typeof( string ) && memberMap.Data.Default != null && memberMap.Data.Default.GetType() == typeof( string ) )
					{
						// The default is a string but the member type is not. Use a converter.
						defaultValueExpression = Expression.Call( typeConverterExpression, nameof( ITypeConverter.ConvertFromString ), null, Expression.Constant( memberMap.Data.Default ), Expression.Constant( this ), Expression.Constant( memberMap.Data ) );
					}
					else
					{
						// The member type and default type match.
						defaultValueExpression = Expression.Constant( memberMap.Data.Default );
					}

					defaultValueExpression = Expression.Convert( defaultValueExpression, memberMap.Data.Member.MemberType() );

					// If null, use string.Empty.
					var coalesceExpression = Expression.Coalesce( fieldExpression, Expression.Constant( string.Empty ) );

					// Check if the field is an empty string.
					var checkFieldEmptyExpression = Expression.Equal( Expression.Convert( coalesceExpression, typeof( string ) ), Expression.Constant( string.Empty, typeof( string ) ) );

					// Use a default value if the field is an empty string.
					fieldExpression = Expression.Condition( checkFieldEmptyExpression, defaultValueExpression, typeConverterFieldExpression );
				}
				else
				{
					fieldExpression = typeConverterFieldExpression;
				}

				bindings.Add( Expression.Bind( memberMap.Data.Member, fieldExpression ) );
			}
		}

		/// <summary>
		/// Determines if the member for the <see cref="MemberMap"/>
		/// can be read.
		/// </summary>
		/// <param name="memberMap">The member map.</param>
		/// <returns>A value indicating of the member can be read. True if it can, otherwise false.</returns>
		protected virtual bool CanRead( MemberMap memberMap )
		{
			var cantRead =
				// Ignored member;
				memberMap.Data.Ignore;

			var property = memberMap.Data.Member as PropertyInfo;
			if( property != null )
			{
				cantRead = cantRead ||
					// Properties that don't have a public setter
					// and we are honoring the accessor modifier.
					property.GetSetMethod() == null && !context.ReaderConfiguration.IncludePrivateMembers ||
					// Properties that don't have a setter at all.
					property.GetSetMethod( true ) == null;
			}

			return !cantRead;
		}

		/// <summary>
		/// Determines if the member for the <see cref="MemberReferenceMap"/>
		/// can be read.
		/// </summary>
		/// <param name="memberReferenceMap">The reference map.</param>
		/// <returns>A value indicating of the member can be read. True if it can, otherwise false.</returns>
		protected virtual bool CanRead( MemberReferenceMap memberReferenceMap )
		{
			var cantRead = false;

			var property = memberReferenceMap.Data.Member as PropertyInfo;
			if( property != null )
			{
				cantRead =
					// Properties that don't have a public setter
					// and we are honoring the accessor modifier.
					property.GetSetMethod() == null && !context.ReaderConfiguration.IncludePrivateMembers ||
					// Properties that don't have a setter at all.
					property.GetSetMethod( true ) == null;
			}

			return !cantRead;
		}

		/// <summary>
		/// Creates a dynamic object from the current record.
		/// </summary>
		/// <returns>The dynamic object.</returns>
		protected virtual dynamic CreateDynamic()
		{
			var obj = new ExpandoObject();
			var dict = obj as IDictionary<string, object>;
			if( context.HeaderRecord != null )
			{
				var length = Math.Min( context.HeaderRecord.Length, context.Record.Length );
				for( var i = 0; i < length; i++ )
				{
					var header = context.HeaderRecord[i];
					var field = GetField( i );
					dict.Add( header, field );
				}
			}
			else
			{
				for( var i = 0; i < context.Record.Length; i++ )
				{
					var propertyName = "Field" + ( i + 1 );
					var field = GetField( i );
					dict.Add( propertyName, field );
				}
			}

			return obj;
		}
	}
}
