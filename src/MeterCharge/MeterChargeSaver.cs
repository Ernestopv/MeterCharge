// <copyright file="MeterChargeSaver.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge
{
    using System.Collections.Generic;
    using DataAccess.Factories.Interfaces;
    using DataAccess.Interfaces;
    using Factories.Interfaces;
    using Models;
    // We are not sure if we want to save meterdata to text files going forward.
    public class MeterChargeSaver
    {
        #region Private fields

        /// <summary>
        /// The meter reader factory
        /// </summary>
        private readonly IMeterReaderFactory _meterReaderFactory;

        /// <summary>
        /// the storage
        /// </summary>
        private readonly IData _storage;

        #endregion

        #region Public constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="MeterChargeSaver"/> class.
        /// </summary>
        public MeterChargeSaver(IMeterReaderFactory meterReaderFactory, IStorageFactory storageFactory)
        {
            _meterReaderFactory = meterReaderFactory;
            _storage = storageFactory.GetStorageType();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Calculate charge for meter readings and save
        /// </summary>
        /// <param name="meters">the meters</param>
        public void CalculateChargeForMeterReadingsAndSave(IEnumerable<Meter> meters)
        {
            foreach (var meter in meters)
            {
                var meterId = _storage.SetMeterName(meter);

                foreach (var reading in meter.Readings)
                {

                    var meterReader = _meterReaderFactory.GetMeterReaderType(meter.MeterType);
                    var result = meterReader.GetReading(reading);
                    result.MeterName = meterId;

                    _storage.SaveConsumption(result);
                }
            }
        }

        #endregion

    }
}
