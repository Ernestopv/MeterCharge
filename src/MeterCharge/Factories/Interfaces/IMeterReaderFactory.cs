// <copyright file="IMeterReaderFactory.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Factories.Interfaces
{
    using MeterCharge.Interfaces;
    using Models.Enums;

    /// <summary>
    /// Defines the meter reader factory contract
    /// </summary>
    public interface IMeterReaderFactory
    {
        #region public methods

        /// <summary>
        /// Get meter reader type 
        /// </summary>
        /// <param name="identifier">identifier (Electricity, water or heating)</param>
        /// <returns>The Meter reader</returns>
        IMeterReader GetMeterReaderType(MeterType identifier);

        #endregion
    }
}
