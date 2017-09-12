﻿// Copyright 2009-2017 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System;
using System.Text;

namespace CsvHelper.Configuration
{
	/// <summary>
	/// Configuration used for the <see cref="IParser"/>.
	/// </summary>
    public interface IParserConfiguration
    {
		/// <summary>
		/// Gets or sets the size of the buffer
		/// used for reading and writing CSV files.
		/// Default is 2048.
		/// </summary>
		int BufferSize { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the number of bytes should
		/// be counted while parsing. Default is false. This will slow down parsing
		/// because it needs to get the byte count of every char for the given encoding.
		/// The <see cref="Encoding"/> needs to be set correctly for this to be accurate.
		/// </summary>
		bool CountBytes { get; set; }

		/// <summary>
		/// Gets or sets the encoding used when counting bytes.
		/// </summary>
		Encoding Encoding { get; set; }

		/// <summary>
		/// Gets or sets a value indicating if an exception should
		/// be thrown when bad field data is detected. A field has
		/// bad data if it contains a quote and the field is not 
		/// quoted (escaped).
		/// True to throw, otherwise false. Default is false.
		/// </summary>
		bool ThrowOnBadData { get; set; }

		/// <summary>
		/// Gets or sets a method that gets called when bad
		/// data is detected.
		/// </summary>
		Action<ReadingContext> BadDataCallback { get; set; }

		/// <summary>
		/// Gets or sets the character used to denote
		/// a line that is commented out. Default is '#'.
		/// </summary>
		char Comment { get; set; }

		/// <summary>
		/// Gets or sets a value indicating if comments are allowed.
		/// True to allow commented out lines, otherwise false.
		/// </summary>
		bool AllowComments { get; set; }

		/// <summary>
		/// Gets or sets a value indicating if blank lines
		/// should be ignored when reading.
		/// True to ignore, otherwise false. Default is true.
		/// </summary>
		bool IgnoreBlankLines { get; set; }

		/// <summary>
		/// Gets or sets a value indicating if quotes should be
		/// ingored when parsing and treated like any other character.
		/// </summary>
		bool IgnoreQuotes { get; set; }

		/// <summary>
		/// Gets or sets the character used to quote fields.
		/// Default is '"'.
		/// </summary>
		char Quote { get; set; }

		/// <summary>
		/// Gets or sets the delimiter used to separate fields.
		/// Default is ',';
		/// </summary>
		string Delimiter { get; set; }

		/// <summary>
		/// Gets or sets the field trimming options.
		/// </summary>
		TrimOptions TrimOptions { get; set; }
	}
}
