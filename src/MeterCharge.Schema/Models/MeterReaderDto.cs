// <copyright file="MeterReaderDto.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Schema.Models
{
    using System;

    /// <summary>
    /// The meter reader model entity
    /// </summary>
    public class MeterReaderDto
    {
        #region Public fields

        /// <summary>
        /// Gets or sets the unique id
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets MeterName
        /// </summary>
        public string MeterName { get; set; }

        /// <summary>
        /// Gets or sets TimeStamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets MeterType
        /// </summary>
        public string MeterType { get; set; }

        /// <summary>
        /// Gets or sets Consumption
        /// </summary>
        public int Consumption { get; set; }

        /// <summary>
        /// Gets or sets Cost
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Gets or sets Charge
        /// </summary>
        public int Charge { get; set; }

        #endregion
    }
}
