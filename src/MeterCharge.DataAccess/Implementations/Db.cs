// <copyright file="Db.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess.Implementations
{
    using System;
    using Interfaces;
    using Models;
    public class Db : IData
    {
        private readonly  IMeterReaderRepository _repository;
        public Db(IMeterReaderRepository repository)
        {
            _repository = repository;
            
        }

        /// <summary>
        /// Save consumption
        /// </summary>
        /// <param name="result">The consumption result (cost, charge, consumption)</param>
        public void SaveConsumption(MeterReader result)
        {
            var meterReaderEntity = new Schema.Models.MeterReaderDto()
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
    }
}
