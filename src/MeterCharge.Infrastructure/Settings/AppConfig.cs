// <copyright file="AppConfig.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Infrastructure.Settings
{
    using System;
    using System.ComponentModel;
    using System.Configuration;

    /// <summary>
    /// Gets the app configuration
    /// </summary>
    public  class AppConfig: IAppConfig
    {
        #region Public methods

        /// <summary>
        /// Get value from key
        /// </summary>
        /// <typeparam name="T">value type</typeparam>
        /// <param name="key">Key</param>
        /// <returns>value key</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public  T Get<T>(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(appSetting))
            {
                throw new InvalidOperationException(key);
            }

            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)(converter.ConvertFromInvariantString(appSetting));

        }

        #endregion
    }
}
