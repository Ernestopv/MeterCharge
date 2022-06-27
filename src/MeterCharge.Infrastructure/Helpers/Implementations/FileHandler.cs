// <copyright file="FileHandler.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Infrastructure.Helpers.Implementations
{
    using System;
    using System.IO;
    using System.Text;
    using Interfaces;
    using Models;

    /// <summary>
    /// Handles file to a text file
    /// </summary>
    public class FileHandler : IFileHandler
    {
        #region Private fields

        /// <summary>
        /// The writer text
        /// </summary>
        private static StreamWriter _writer;

        #endregion

        #region Public methods

        /// <summary>
        /// Create file if exists
        /// </summary>
        public void CreateFileIfExists()
        {
            if (!Directory.Exists(@"C:\MeterDb\"))
            {
                Directory.CreateDirectory(@"C:\MeterDb\");
            }
        }

        /// <summary>
        /// Create columns on text file
        /// </summary>
        /// <param name="filename"></param>
        public void CreateColumnsOnTextFile(string filename)
        {
            _writer = File.AppendText(@"C:\MeterDb\" + filename);
            _writer.Write("Timestamp".PadRight(20, ' ') + "\t" + "Meter Type".PadRight(15, ' ') + "\t" +
                          "Consumption".PadRight(15, ' ') + "\t" + "Cost".PadRight(15, ' ') + "\t" + "Charge".PadRight(15, ' ') +
                          "\t" + Environment.NewLine);
            _writer.AutoFlush = true;

        }

        /// <summary>
        /// Save data from meter reader
        /// </summary>
        /// <param name="result">the meter reader result</param>
        public void WriteMeterReaderDetails(MeterReader result)
        {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            sb.Append("\t");
            sb.Append(result.MeterType.ToString().PadRight(15, ' '));
            sb.Append("\t");
            sb.Append(result.Consumption.ToString().PadRight(15, ' '));
            sb.Append("\t");
            sb.Append(result.Cost.ToString().PadRight(15, ' '));
            sb.Append("\t");
            sb.Append(result.Charge.ToString().PadRight(15, ' '));
            sb.Append("\t");
            sb.Append(Environment.NewLine);

            _writer.Write(sb.ToString());
        }

        #endregion
    }
}
