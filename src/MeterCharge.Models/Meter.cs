// <copyright file="Meter.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>


namespace MeterCharge.Models
{
    using System.Collections.Generic;
    using Enums;

    /// <summary>
    /// Meter model 
    /// </summary>
    public class Meter
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets MeterType electricity, water or heating
        /// </summary>
        public MeterType MeterType { get; set; }

        /// <summary>
        /// Gets or sets Readings 
        /// </summary>
        public IEnumerable<int> Readings { get; set; }
    }
}
