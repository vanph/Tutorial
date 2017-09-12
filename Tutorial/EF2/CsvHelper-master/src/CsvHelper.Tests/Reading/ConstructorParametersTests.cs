﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvHelper.Tests.Reading
{
	[TestClass]
    public class ConstructorParametersTests
    {
		[TestMethod]
		public void ValueTypesParamsMatchPropsTest()
		{
			using( var stream = new MemoryStream() )
			using( var writer = new StreamWriter( stream ) )
			using( var reader = new StreamReader( stream ) )
			using( var csv = new CsvReader( reader ) )
			{
				writer.WriteLine( "Id,Name" );
				writer.WriteLine( "1,one" );
				writer.Flush();
				stream.Position = 0;

				var records = csv.GetRecords<ValueTypesParamsMatchProps>().ToList();

				Assert.AreEqual( 1, records.Count );

				var record = records[0];

				Assert.AreEqual( 1, record.Id );
				Assert.AreEqual( "one", record.Name );
			}
		}

		[TestMethod]
		public void ValueTypesParamsDontMatchPropsTest()
		{
			using( var stream = new MemoryStream() )
			using( var writer = new StreamWriter( stream ) )
			using( var reader = new StreamReader( stream ) )
			using( var csv = new CsvReader( reader ) )
			{
				writer.WriteLine( "Id,Name" );
				writer.WriteLine( "1,one" );
				writer.Flush();
				stream.Position = 0;

				csv.Configuration.PrepareHeaderForMatch = header => CultureInfo.CurrentCulture.TextInfo.ToTitleCase( header );
				var records = csv.GetRecords<ValueTypesParamsDontMatchProps>().ToList();

				Assert.AreEqual( 1, records.Count );

				var record = records[0];

				Assert.AreEqual( 1, record.Id );
				Assert.AreEqual( "one", record.Name );
			}
		}

		[TestMethod]
		public void MultipleConstructorsTest()
		{
			using( var stream = new MemoryStream() )
			using( var writer = new StreamWriter( stream ) )
			using( var reader = new StreamReader( stream ) )
			using( var csv = new CsvReader( reader ) )
			{
				writer.WriteLine( "Id,Name" );
				writer.WriteLine( "1,one" );
				writer.Flush();
				stream.Position = 0;

				csv.Configuration.PrepareHeaderForMatch = header => CultureInfo.CurrentCulture.TextInfo.ToTitleCase( header );
				var records = csv.GetRecords<MultipleConstructors>().ToList();

				Assert.AreEqual( 1, records.Count );

				var record = records[0];

				Assert.AreEqual( 1, record.Id );
				Assert.AreEqual( "one", record.Name );
			}
		}

		[TestMethod]
		public void UseDifferentConstructorTest()
		{
			using( var stream = new MemoryStream() )
			using( var writer = new StreamWriter( stream ) )
			using( var reader = new StreamReader( stream ) )
			using( var csv = new CsvReader( reader ) )
			{
				writer.WriteLine( "Id,Name" );
				writer.WriteLine( "1,one" );
				writer.Flush();
				stream.Position = 0;

				csv.Configuration.PrepareHeaderForMatch = header => CultureInfo.CurrentCulture.TextInfo.ToTitleCase( header );
				csv.Configuration.GetConstructor = type => type.GetConstructors().First();
				var records = csv.GetRecords<MultipleConstructors>().ToList();

				Assert.AreEqual( 1, records.Count );

				var record = records[0];
				Assert.AreEqual( 1, record.Id );
				Assert.IsNull( record.Name );
			}
		}

		[TestMethod]
		public void UseDifferentConstructorWhenDefaultIsAvailableTest()
		{
			using( var stream = new MemoryStream() )
			using( var writer = new StreamWriter( stream ) )
			using( var reader = new StreamReader( stream ) )
			using( var csv = new CsvReader( reader ) )
			{
				writer.WriteLine( "Id,Name" );
				writer.WriteLine( "1,one" );
				writer.Flush();
				stream.Position = 0;

				csv.Configuration.PrepareHeaderForMatch = header => CultureInfo.CurrentCulture.TextInfo.ToTitleCase( header );
				csv.Configuration.ShouldUseConstructorParameters = type =>
					!type.IsUserDefinedStruct()
					&& !type.IsInterface
					&& Type.GetTypeCode( type ) == TypeCode.Object;
				var records = csv.GetRecords<MultipleConstructorsWithDefault>().ToList();

				Assert.AreEqual( 1, records.Count );

				var record = records[0];
				Assert.AreEqual( 1, record.Id );
				Assert.AreEqual( "one", record.Name );
			}
		}

		private class ValueTypesParamsMatchProps
		{
			public int Id { get; private set; }

			public string Name { get; private set; }

			public ValueTypesParamsMatchProps( int Id, string Name)
			{
				this.Id = Id;
				this.Name = Name;
			}
		}

		private class ValueTypesParamsDontMatchProps
		{
			public int Id { get; private set; }

			public string Name { get; private set; }

			public ValueTypesParamsDontMatchProps( int id, string name )
			{
				Id = id;
				Name = name;
			}
		}

		private class MultipleConstructors
		{
			public int Id { get; private set; }

			public string Name { get; private set; }

			public MultipleConstructors( int id )
			{
				Id = id;
			}

			public MultipleConstructors( int id, string name )
			{
				Id = id;
				Name = name;
			}

			public MultipleConstructors( string name )
			{
				Name = name;
			}
		}

		private class MultipleConstructorsWithDefault
		{
			public int Id { get; private set; }

			public string Name { get; private set; }

			public MultipleConstructorsWithDefault() { }

			public MultipleConstructorsWithDefault( int id, string name )
			{
				Id = id;
				Name = name;
			}
		}
	}
}
