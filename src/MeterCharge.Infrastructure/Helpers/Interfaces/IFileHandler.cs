// <copyright file="IFileHandler.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>


namespace MeterCharge.Infrastructure.Helpers.Interfaces
{
    using Models;

    /// <summary>
    /// Defines the contract of fileHandler
    /// </summary>
    public interface IFileHandler
    {

        #region Public methods

        void CreateFileIfExists();

        void CreateColumnsOnTextFile(string fileName);

        void WriteMeterReaderDetails(MeterReader result);

        #endregion
    }
}
