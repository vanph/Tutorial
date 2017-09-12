﻿// Copyright 2009-2017 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System;
using System.Globalization;
using CsvHelper.Configuration;
using System.Linq;

namespace CsvHelper.TypeConversion
{
	/// <summary>
	/// Converts an <see cref="object"/> to and from a <see cref="string"/>.
	/// </summary>
	public class DefaultTypeConverter : ITypeConverter
	{
		/// <summary>
		/// Converts the object to a string.
		/// </summary>
		/// <param name="value">The object to convert to a string.</param>
		/// <param name="row">The <see cref="IWriterRow"/> for the current record.</param>
		/// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being written.</param>
		/// <returns>The string representation of the object.</returns>
		public virtual string ConvertToString( object value, IWriterRow row, MemberMapData memberMapData )
		{
			if( value == null )
			{
				return string.Empty;
			}

			var formattable = value as IFormattable;
			if( formattable != null )
			{
				var format = memberMapData.TypeConverterOptions.Formats?.FirstOrDefault();
				return formattable.ToString( format, memberMapData.TypeConverterOptions.CultureInfo );
			}

			return value.ToString();
		}

		/// <summary>
		/// Converts the string to an object.
		/// </summary>
		/// <param name="text">The string to convert to an object.</param>
		/// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
		/// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
		/// <returns>The object created from the string.</returns>
		public virtual object ConvertFromString( string text, IReaderRow row, MemberMapData memberMapData )
		{
			throw new TypeConverterException( (ReadingContext)row.Context, "The conversion cannot be performed." );
		}
	}
}
