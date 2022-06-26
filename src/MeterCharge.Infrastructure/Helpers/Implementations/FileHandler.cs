// <copyright file="FileHandler.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Text;
using MeterCharge.Infrastructure.Helpers.Interfaces;
using MeterCharge.Models;

namespace MeterCharge.Infrastructure.Helpers.Implementations
{
    public class FileHandler : IFileHandler
    {
        /// <summary>
        /// The writer text
        /// </summary>
        private static StreamWriter _writer;

        public void CreateFileIfExists()
        {
            if (!Directory.Exists(@"C:\MeterDb\"))
            {
                Directory.CreateDirectory(@"C:\MeterDb\");
            }
        }

        public void CreateColumnsOnFileText(string filename)
        {
            _writer = File.AppendText(@"C:\MeterDb\" + filename);
            _writer.Write("Timestamp".PadRight(20, ' ') + "\t" + "Meter Type".PadRight(15, ' ') + "\t" +
                          "Consumption".PadRight(15, ' ') + "\t" + "Cost".PadRight(15, ' ') + "\t" + "Charge".PadRight(15, ' ') +
                          "\t" + Environment.NewLine);
            _writer.AutoFlush = true;

        }

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
    }
}
