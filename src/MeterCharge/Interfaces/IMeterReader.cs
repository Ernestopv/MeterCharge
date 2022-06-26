// <copyright file="IMeterReader.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

using MeterCharge.Models;

namespace MeterCharge.Interfaces
{
    /// <summary>
    /// Defines the contract of MeterReader 
    /// </summary>
    public interface IMeterReader
    {
        #region Public methods

        /// <summary>
        /// Get meter reading 
        /// </summary>
        /// <param name="reading">the reading</param>
        /// <returns>The Meter reading in cost, consumption and charge</returns>
        MeterReader GetReading(int reading);

        #endregion
    }
}
