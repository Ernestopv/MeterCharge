// <copyright file="Db.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

using MeterCharge.Schema.Models;

namespace MeterCharge.DataAccess.Implementations
{
    using System;
    using Interfaces;
    using Models;

    /// <summary>
    /// Handles data to db
    /// </summary>
    public class Db : IData
    {
        #region Private fields

        /// <summary>
        /// the db respository
        /// </summary>
        private readonly  IMeterReaderRepository _repository;

        #endregion

        #region Public constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Db"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public Db(IMeterReaderRepository repository)
        {
            _repository = repository;
            
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Save consumption
        /// </summary>
        /// <param name="result">The consumption result (cost, charge, consumption)</param>
        public void SaveConsumption(MeterReader result)
        {
            var meterReaderEntity = new MeterReaderDto()
            {
                Charge = result.Charge,
                Consumption = result.Consumption,
                Cost = result.Cost,
                MeterName = result.MeterName,
                MeterType = result.MeterType.ToString(),
                Timestamp = DateTime.UtcNow
            };

            _repository.SaveMeterRead(meterReaderEntity);

        }

        /// <summary>
        /// Set meter id 
        /// </summary>
        /// <param name="meter">The meter reader</param>
        /// <returns>The meter Id </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string SetMeterName(Meter meter)
        {

            return "Meter-" + meter.Id;
        }

        #endregion
    }
}
