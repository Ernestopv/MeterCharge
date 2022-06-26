// <copyright file="StorageFactory.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess.Factories.Implementations
{
    using System;
    using DataAccess.Interfaces;
    using Infrastructure.Helpers.Implementations;
    using Infrastructure.Settings;
    using Interfaces;
    using Models.Enums;

    /// <summary>
    /// Handles the storage type , (TextFile or Db)
    /// </summary>
    public class StorageFactory : IStorageFactory
    {

        #region Private fields

        /// <summary>
        /// The app config
        /// </summary>
        private readonly IAppConfig _appConfig;

        #endregion

        #region Public Constructors

        /// <summary>
        ///  Initialises a new instance of the <see cref="StorageFactory"/> class.
        /// </summary>
        /// <param name="appConfig"></param>
        public StorageFactory(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// Get storage instance type
        /// </summary>
        /// <returns>Storage instance</returns>
        public IData GetStorageType()
        {
            var isDbEnabled = _appConfig.Get<bool>("EnableDb");

            return isDbEnabled ? GetDbInstance() : GetTextFileInstance();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get text file instance (store to text file)
        /// </summary>
        /// <returns>Text file instance</returns>
        private IData GetTextFileInstance()
        {
            var assemblyName = _appConfig.Get<string>(StorageType.TextFile.ToString());
            var textFileInstance = GetInstance<IData>(assemblyName);
            return textFileInstance;
        }

        /// <summary>
        /// Get Db instance (store to db)
        /// </summary>
        /// <returns>Db instance</returns>
        private IData GetDbInstance()
        {
            var assemblyName = _appConfig.Get<string>(StorageType.Db.ToString());
            var dbInstance = GetInstance<IData>(assemblyName);
            return dbInstance;
        }

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

            if (objecType.Name == StorageType.Db.ToString())
            {
                var meterReaderRepository = new MeterReaderRepository();
                return Activator.CreateInstance(objecType, meterReaderRepository) as T;
            }

            var fileHandler = new FileHandler();
            return Activator.CreateInstance(objecType, fileHandler) as T;

        }

        #endregion
    }
}
