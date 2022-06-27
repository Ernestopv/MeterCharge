// <copyright file="MeterReaderRepository.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess
{
    using Interfaces;
    using Schema.Models;

    /// <summary>
    /// Th meter reader repository
    /// </summary>
    public class MeterReaderRepository : IMeterReaderRepository
    {

        #region public methods

        /// <summary>
        /// Save meter read to db
        /// </summary>
        /// <param name="meterReaderEntity">the meter read</param>
        public void SaveMeterRead(MeterReaderDto meterReaderEntity)
        {
            using (var context = new MeterReaderContext())
            {
                context.MeterReaders.Add(meterReaderEntity);
                context.SaveChanges();
            }
        }

        #endregion

    }
}
