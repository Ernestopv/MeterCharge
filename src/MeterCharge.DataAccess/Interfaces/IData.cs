// <copyright file="IData.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>



namespace MeterCharge.DataAccess.Interfaces
{
    using Models;

    /// <summary>
    /// Defines the contract of Handling the data
    /// </summary>
    public interface IData 
    {  
        /// <summary>
        /// Save consumption
        /// </summary>
        /// <param name="result">meter reader result</param>
        void SaveConsumption(MeterReader result);

        /// <summary>
        /// Set the meter reader name
        /// </summary>
        /// <param name="meter">the meter reader</param>
        /// <returns> the meter reader name</returns>
        string SetMeterName(Meter meter);
    }
}
