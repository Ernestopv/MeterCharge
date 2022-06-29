// <copyright file="MeterReaderFactory.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>


namespace MeterCharge.Factories.Implementations
{
    using Interfaces;
    using MeterCharge.Implementations;
    using MeterCharge.Interfaces;
    using Models.Enums;
    using System;

    /// <summary>
    /// The meter reader factory identifies the meter type
    /// </summary>
    public class MeterReaderFactory : IMeterReaderFactory
    {

        #region Public methods

     

        /// <summary>
        /// Get meter reader type
        /// </summary>
        /// <param name="identifier">the identifier (electricity, heating or water)</param>
        /// <returns>The meter</returns>
        public IMeterReader GetMeterReaderType(MeterType identifier)
        {
            switch (identifier)
            {
                case MeterType.Electricity:
                    {
                        var dateTime = DateTime.Now;
                        return new Electricity(dateTime);
                    }
                case MeterType.Water:
                    {
                        return new Water();
                    }
                case MeterType.Heating:
                default:
                    {
                        return new Heating();
                    }        
            }
        }

        #endregion

    }
}

