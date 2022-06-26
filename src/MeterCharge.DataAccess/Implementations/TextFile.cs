﻿// <copyright file="TextFile.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess.Implementations
{
    using Interfaces;
    using MeterCharge.Infrastructure.Helpers.Interfaces;
    using Models;

    /// <summary>
    /// Handles data to a text file 
    /// </summary>
    public class TextFile : IData
    {
        #region PrivateFields


        private IFileHandler _fileHandler;

        #endregion

        public TextFile(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;

        }

        #region Public Methods

        /// <summary>
        /// Save consumption
        /// </summary>
        /// <param name="result">result (cost,charge, consumption)</param>
        public void SaveConsumption(MeterReader result)
        {
            _fileHandler.WriteMeterReaderDetails(result);
        }

        /// <summary>
        /// Set Meter Id
        /// </summary>
        /// <param name="meter">The meter</param>
        /// <returns>meter id</returns>
        public string SetMeterName(Meter meter)
        {

            _fileHandler.CreateFileIfExists();

            var meterName = "Meter-" + meter.Id;
            var filename = meterName + ".log";

            _fileHandler.CreateColumnsOnFileText(filename);

            return meterName;
        }

        #endregion
    }
}
