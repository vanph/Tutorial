﻿// Copyright 2009-2017 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using System.Threading.Tasks;

namespace CsvHelper
{
	/// <summary>
	/// Defines methods used to read parsed data
	/// from a CSV file.
	/// </summary>
	public interface IReader : IReaderRow, IDisposable
	{
		/// <summary>
		/// Gets the parser.
		/// </summary>
		IParser Parser { get; }

		/// <summary>
		/// Reads the header field without reading the first row.
		/// </summary>
		/// <returns>True if there are more records, otherwise false.</returns>
		bool ReadHeader();

		/// <summary>
		/// Advances the reader to the next record. This will not read headers.
		/// You need to call <see cref="Read"/> then <see cref="ReadHeader"/> 
		/// for the headers to be read.
		/// </summary>
		/// <returns>True if there are more records, otherwise false.</returns>
		bool Read();

		/// <summary>
		/// Advances the reader to the next record. This will not read headers.
		/// You need to call <see cref="ReadAsync"/> then <see cref="ReadHeader"/> 
		/// for the headers to be read.
		/// </summary>
		/// <returns>True if there are more records, otherwise false.</returns>
		Task<bool> ReadAsync();

		/// <summary>
		/// Gets all the records in the CSV file and
		/// converts each to <see cref="Type"/> T. The Read method
		/// should not be used when using this.
		/// </summary>
		/// <typeparam name="T">The <see cref="Type"/> of the record.</typeparam>
		/// <returns>An <see cref="IList{T}" /> of records.</returns>
		IEnumerable<T> GetRecords<T>();

		/// <summary>
		/// Gets all the records in the CSV file and converts
		/// each to <see cref="System.Type"/> T. The read method
		/// should not be used when using this.
		/// </summary>
		/// <typeparam name="T">The <see cref="System.Type"/> of the record.</typeparam>
		/// <param name="anonymousTypeDefinition">The anonymous type definition to use for the records.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of records.</returns>
		IEnumerable<T> GetRecords<T>( T anonymousTypeDefinition );

		/// <summary>
		/// Gets all the records in the CSV file and
		/// converts each to <see cref="Type"/> T. The Read method
		/// should not be used when using this.
		/// </summary>
		/// <param name="type">The <see cref="Type"/> of the record.</param>
		/// <returns>An <see cref="IList{Object}" /> of records.</returns>
		IEnumerable<object> GetRecords( Type type );
	}
}
