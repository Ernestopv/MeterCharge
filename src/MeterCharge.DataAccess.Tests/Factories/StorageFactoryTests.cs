// <copyright file="StorageFactoryTests.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>


namespace MeterCharge.DataAccess.Tests.Factories
{
    using DataAccess.Factories.Implementations;
    using Infrastructure.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Enums;
    using NSubstitute;
    using System;



    [TestClass]
    public class StorageFactoryTests
    {
        #region Private fields

        /// <summary>
        /// The storage factory
        /// </summary>
        private readonly StorageFactory _sut;

        /// <summary>
        /// The app config
        /// </summary>
        private readonly IAppConfig _appConfig;


        #endregion

        #region Public constructors

        /// <summary>
        ///  Initialises a new instance of the <see cref="StorageFactoryTests"/> class.
        /// </summary>
        public StorageFactoryTests()
        {
            _appConfig = Substitute.For<IAppConfig>();
            _sut = new StorageFactory(_appConfig);
        }

        #endregion

        #region Public methods

        [TestMethod]
        public void GetStorageType_AssemblyNameIsEmpty_ThrowsException()
        {
            //Arrange
            _appConfig.Get<string>("usb").Returns("");


            //Assert & Act
            Assert.ThrowsException<ArgumentNullException>(() => _sut.GetStorageType());

        }

        [TestMethod]
        public void GetStorageType_InvalidAssemblyName_ThrowsException()
        {
            //Arrange
            _appConfig.Get<string>(StorageType.Db.ToString())
                .Returns("MeterCharge.DataAccess.Implementations.usb, MeterCharge.DataAccess");

            //Assert & Act
            Assert.ThrowsException<ArgumentNullException>(() => _sut.GetStorageType());

        }

        [TestMethod]
        public void GetStorageType_Returns_Db()
        {
            //Arrange
            _appConfig.Get<bool>("EnableDb").Returns(true);
            _appConfig.Get<string>(StorageType.Db.ToString()).
                Returns("MeterCharge.DataAccess.Implementations.Db, MeterCharge.DataAccess");

            //Act
            var storageType = _sut.GetStorageType();

            //Assert
            Assert.AreEqual("MeterCharge.DataAccess.Implementations.Db", storageType.GetType().FullName);
        }


        [TestMethod]
        public void GetStorageType_Returns_TextFile()
        {
            //Arrange
            _appConfig.Get<bool>("EnableDb").Returns(false);
            _appConfig.Get<string>(StorageType.TextFile.ToString()).
                Returns("MeterCharge.DataAccess.Implementations.TextFile, MeterCharge.DataAccess");

            //Act
            var storageType = _sut.GetStorageType();

            //Assert
            Assert.AreEqual("MeterCharge.DataAccess.Implementations.TextFile", storageType.GetType().FullName);
        }

        #endregion
    }
}
