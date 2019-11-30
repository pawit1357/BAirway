﻿using System;


/// <summary>
/// This class can generate random passwords, which do not include ambiguous 
/// characters, such as I, l, and 1. The generated password will be made of
/// 7-bit ASCII symbols. Every four characters will include one lower case
/// character, one upper case character, one number, and one special symbol
/// (such as '%') in a random order. The password will always start with an
/// alpha-numeric character; it will not start with a special symbol (we do
/// this because some back-end systems do not like certain special
/// characters in the first position).
/// </summary>
/// 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Text;
namespace BAW.Utils
{

    /// <summary>
    /// Class to store one CSV row
    /// </summary>
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }

    /// <summary>
    /// Class to write data to a CSV file
    /// </summary>
    public class CsvFileWriter : StreamWriter
    {
        public CsvFileWriter(Stream stream)
            : base(stream)
        {
        }

        public CsvFileWriter(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Writes a single row to a CSV file.
        /// </summary>
        /// <param name="row">The row to be written</param>
        public void WriteRow(CsvRow row)
        {
            StringBuilder builder = new StringBuilder();
            bool firstColumn = true;
            foreach (string value in row)
            {
                // Add separator if this isn't the first value
                if (!firstColumn)
                    builder.Append(',');
                // Implement special handling for values that contain comma or quote
                // Enclose in quotes and double up any double quotes
                if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                else
                    builder.Append(value);
                firstColumn = false;
            }
            row.LineText = builder.ToString();
            WriteLine(row.LineText);
        }
    }

    /// <summary>
    /// Class to read data from a CSV file
    /// </summary>
    public class CsvFileReader : StreamReader
    {
        public CsvFileReader(Stream stream)
            : base(stream)
        {
        }

        public CsvFileReader(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Reads a row of data from a CSV file
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                // Special handling for quoted field
                if (row.LineText[pos] == '"')
                {
                    // Skip initial quote
                    pos++;

                    // Parse quoted value
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        // Test for quote character
                        if (row.LineText[pos] == '"')
                        {
                            // Found one
                            pos++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Parse unquoted value
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                // Add field to list
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;

                // Eat up to and including next comma
                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            // Delete any unused items
            while (row.Count > rows)
                row.RemoveAt(rows);

            // Return true if any columns read
            return (row.Count > 0);
        }
    }

    //public class CsvReader
    //{
        //public DataTable read(string strFileName)
        //{
        //    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=NO;FMT=Delimited\"");
        //    conn.Open();
        //    string strQuery = "SELECT * FROM [" + System.IO.Path.GetFileName(strFileName) + "]";
        //    OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
        //    DataSet ds = new DataSet("CSV File");
        //    adapter.Fill(ds);
        //    return ds.Tables[0];
        //}

        //public DataTable read(string strFileName, bool firstRowHeaders)
        //{
        //    string hdr = "NO";
        //    if (firstRowHeaders) { hdr = "YES"; }

        //    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=" + hdr + ";FMT=Delimited\"");
        //    conn.Open();
        //    string strQuery = "SELECT * FROM [" + System.IO.Path.GetFileName(strFileName) + "]";
        //    OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
        //    DataSet ds = new DataSet("CSV File");
        //    adapter.Fill(ds);
        //    return ds.Tables[0];
        //}
    //}
}
