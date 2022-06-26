// <copyright file="IStorageFactory.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>


namespace MeterCharge.DataAccess.Factories.Interfaces
{
    using DataAccess.Interfaces;

    /// <summary>
    /// Defines the contract for storage
    /// </summary>
    public interface IStorageFactory
    {
        #region Public methods

        /// <summary>
        /// Get storage type 
        /// </summary>
        /// <returns>The storage type</returns>
        IData GetStorageType();

        #endregion
    }
}
