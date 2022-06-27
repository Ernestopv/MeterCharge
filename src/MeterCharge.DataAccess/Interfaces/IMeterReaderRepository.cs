// <copyright file="IMeterReaderRepository.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess.Interfaces
{
    using Schema.Models;
    
    /// <summary>
    /// Defines the contract of the MeterReaderRepository
    /// </summary>
    public interface IMeterReaderRepository
    {
        /// <summary>
        /// Save meter read to db
        /// </summary>
        /// <param name="meterReaderEntity">the meter read</param>
        void SaveMeterRead(MeterReaderDto meterReaderEntity);
    }
}
