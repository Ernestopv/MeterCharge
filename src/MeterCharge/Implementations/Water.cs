// <copyright file="Water.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

using MeterCharge.Models.Enums;

namespace MeterCharge.Implementations
{
    using Interfaces;
    using Models;

    /// <summary>
    /// Handles Water reading
    /// </summary>
    public class Water : IMeterReader
    {
        #region Public methods

        /// <summary>
        /// Get meter reading 
        /// </summary>
        /// <param name="reading">the reading</param>
        /// <returns>The Meter reading in cost, consumption and charge</returns>
        public MeterReader GetReading(int reading)
        {
            var cost = 3;

            return new MeterReader()
            {
                MeterType = MeterType.Water,
                Charge = cost * reading,
                Consumption = reading,
                Cost = cost
            };
        }

        #endregion
    }
}
