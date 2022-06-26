// <copyright file="MeterReading.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>


namespace MeterCharge.Models
{
    using Enums;

    /// <summary>
    /// The meter reading model 
    /// </summary>
    public class MeterReader
    {
        #region Public fields

        /// <summary>
        /// Gets or sets Meter Read Id
        /// </summary>
        public string MeterName { get; set; }

        /// <summary>
        /// Gets or sets MeterType
        /// </summary>
        public MeterType MeterType { get; set; }

        /// <summary>
        /// Gets or sets Consumption
        /// </summary>
        public int Consumption { get; set; }

        /// <summary>
        /// Gets or sets Cost
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Gets or sets Charge $
        /// </summary>
        public int Charge { get; set; }

        #endregion
    }
}
