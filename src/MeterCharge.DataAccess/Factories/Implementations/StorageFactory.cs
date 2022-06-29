// <copyright file="StorageFactory.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess.Factories.Implementations
{
    using DataAccess.Interfaces;
    using Infrastructure.Helpers.Implementations;
    using Infrastructure.Settings;
    using Interfaces;
    using MeterCharge.DataAccess.Implementations;

    /// <summary>
    /// Handles the storage type , (TextFile or Db)
    /// </summary>
    public class StorageFactory : IStorageFactory
    {

        #region Private fields

        /// <summary>
        /// Verifies if the db is enabled from app config
        /// </summary>
        private readonly bool _isDbEnabled;

        #endregion

        #region Public Constructors

        /// <summary>
        ///  Initialises a new instance of the <see cref="StorageFactory"/> class.
        /// </summary>
        /// <param name="appConfig"></param>
        public StorageFactory(IAppConfig appConfig)
        {
  
            _isDbEnabled = appConfig.Get<bool>("EnableDb");
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// Get storage instance type
        /// </summary>
        /// <returns>Storage instance</returns>
        public IData GetStorageType()
        {
            if (_isDbEnabled)
            {
                var repository = new MeterReaderRepository();
                return new Db(repository);
            }

            var fileHandler = new FileHandler();
            return new TextFile(fileHandler);
        }

        #endregion


    }
}
