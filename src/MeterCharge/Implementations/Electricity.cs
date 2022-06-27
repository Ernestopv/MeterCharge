// <copyright file="Electricity.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Implementations
{
    using Interfaces;
    using Models;
    using Models.Enums;
    using System;

    /// <summary>
    /// Handles electricity reading
    /// </summary>
    public class Electricity : IMeterReader
    {

        #region Private fields

        /// <summary>
        /// Defines the dateTime to see if It's half price at off peak hours
        /// </summary>
        private readonly DateTime _dateTime;

        #endregion


        #region Public constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Electricity"/> class.
        /// </summary>
        /// <param name="dateTime">The date time</param>
        public Electricity(DateTime dateTime)
        {

            _dateTime = dateTime;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get meter reading 
        /// </summary>
        /// <param name="reading">the reading</param>
        /// <returns>The Meter reading in cost, consumption and charge</returns>
        public MeterReader GetReading(int reading)
        {
            int cost = 4;
            if (_dateTime.TimeOfDay.Hours < 8 || _dateTime.TimeOfDay.Hours > 20)
            {
                // half price at off peak hours: before 8 and after 20.
                cost = 2;
            }

            return new MeterReader()
            {
                MeterType = MeterType.Electricity,
                Charge = cost * reading,
                Consumption = reading,
                Cost = cost
            };
        }

        #endregion



    }
}
