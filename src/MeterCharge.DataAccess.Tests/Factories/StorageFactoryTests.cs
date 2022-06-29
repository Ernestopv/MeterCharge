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


    /// <summary>
    /// Handles the storage factory pattern test 
    /// </summary>
    [TestClass]
    public class StorageFactoryTests
    {

        #region Public methods

        [TestMethod]
        public void GetStorageType_Returns_Db()
        {
            //Arrange
            var appConfig = Substitute.For<IAppConfig>();
            appConfig.Get<bool>("EnableDb").Returns(true);
            var sut = new StorageFactory(appConfig);


            appConfig.Get<string>(StorageType.Db.ToString()).
                Returns("MeterCharge.DataAccess.Implementations.Db, MeterCharge.DataAccess");

            //Act
            var storageType = sut.GetStorageType();

            //Assert
            Assert.AreEqual("MeterCharge.DataAccess.Implementations.Db", storageType.GetType().FullName);
        }


        [TestMethod]
        public void GetStorageType_Returns_TextFile()
        {
            //Arrange

            var appConfig = Substitute.For<IAppConfig>();
            appConfig.Get<bool>("EnableDb").Returns(false);
            var sut = new StorageFactory(appConfig);

            appConfig.Get<bool>("EnableDb").Returns(false);
            appConfig.Get<string>(StorageType.TextFile.ToString()).
                Returns("MeterCharge.DataAccess.Implementations.TextFile, MeterCharge.DataAccess");

            //Act
            var storageType = sut.GetStorageType();

            //Assert
            Assert.AreEqual("MeterCharge.DataAccess.Implementations.TextFile", storageType.GetType().FullName);
        }

        #endregion
    }
}
