// <copyright file="MeterReaderFactory.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>


namespace MeterCharge.Factories.Implementations
{
    using System;
    using Infrastructure.Settings;
    using Interfaces;
    using MeterCharge.Interfaces;
    using Models.Enums;

    /// <summary>
    /// The meter reader factory identifies the meter type
    /// </summary>
    public class MeterReaderFactory : IMeterReaderFactory
    {
        #region Private fields

        /// <summary>
        /// The app config
        /// </summary>
        private readonly IAppConfig _appConfig;

        #endregion

        #region Public Constructors

        /// <summary>
        ///  Initialises a new instance of the <see cref="MeterReaderFactory"/> class.
        /// </summary>
        /// <param name="appConfig"></param>
        public MeterReaderFactory(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get meter reader type
        /// </summary>
        /// <param name="identifier">the identifier (electricity, heating or water)</param>
        /// <returns>The meter</returns>
        public IMeterReader GetMeterReaderType(MeterType identifier)
        {
            var assemblyName = _appConfig.Get<string>(identifier.ToString());

            var meterType = GetInstance<IMeterReader>(assemblyName);

            return meterType;

        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get the instance 
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="assemblyName">the class name</param>
        /// <returns>The created instance</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private T GetInstance<T>(string assemblyName) where T : class
        {
            if (string.IsNullOrWhiteSpace(assemblyName))
            {
                throw new ArgumentNullException(nameof(assemblyName));
            }
            var objectType = Type.GetType(assemblyName);

            return ValidateInstance<T>(objectType);
        }

        /// <summary>
        /// Validate instance 
        /// </summary>
        /// <typeparam name="T"> Class</typeparam>
        /// <param name="objecType">object type</param>
        /// <returns>The created instance validated </returns>
        /// <exception cref="ArgumentNullException"></exception>
        private T ValidateInstance<T>(Type objecType) where T : class
        {
            if (objecType == null)
            {
                throw new ArgumentNullException(nameof(objecType));
            }

            if (objecType.Name != MeterType.Electricity.ToString())
            {
                return Activator.CreateInstance(objecType) as T;
            }

            var dateTime = DateTime.Now;
            return Activator.CreateInstance(objecType,dateTime) as T;

        }

        #endregion
    }
}
