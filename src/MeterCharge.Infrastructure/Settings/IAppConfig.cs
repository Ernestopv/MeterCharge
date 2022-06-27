// <copyright file="IAppConfig.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Infrastructure.Settings
{
    /// <summary>
    /// Defines the contract of app config
    /// </summary>
    public interface IAppConfig
    {
        #region public methods

        /// <summary>
        /// Get key value pair
        /// </summary>
        /// <typeparam name="T">property type</typeparam>
        /// <param name="key">key</param>
        /// <returns>key value pair</returns>
        T Get<T>(string key);

        #endregion
    }
}
