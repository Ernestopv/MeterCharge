// <copyright file="Heating.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Implementations
{
    using Interfaces;
    using Models;
    using Models.Enums;

    /// <summary>
    /// Handles Heating Reading
    /// </summary>
    public class Heating : IMeterReader
    {
        #region Public methods

        /// <summary>
        /// Get meter reading 
        /// </summary>
        /// <param name="reading">the reading</param>
        /// <returns>The Meter reading in cost, consumption and charge</returns>
        public MeterReader GetReading(int reading)
        {
            var cost = 5;
            return new MeterReader()
            {
                MeterType = MeterType.Heating,
                Charge = cost * reading,
                Consumption = reading,
                Cost = cost
            };
        }

        #endregion
    }
}
