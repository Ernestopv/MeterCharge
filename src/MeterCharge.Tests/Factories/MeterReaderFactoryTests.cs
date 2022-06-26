// <copyright file="MeterReaderFactoryTests.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Tests.Factories
{
    using System;
    using Infrastructure.Settings;
    using MeterCharge.Factories.Implementations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Enums;
    using NSubstitute;

    /// <summary>
    /// Handles Meter reader factory tests
    /// </summary>
    [TestClass]
    public class MeterReaderFactoryTests
    {
        #region Public fields

        /// <summary>
        /// The meter reader factory
        /// </summary>
        private readonly MeterReaderFactory _sut;

        /// <summary>
        /// The app config
        /// </summary>
        private readonly IAppConfig _appConfig;

        #endregion

        #region Public constructors

        /// <summary>
        ///  Initialises a new instance of the <see cref="MeterReaderFactoryTests"/> class.
        /// </summary>
        public MeterReaderFactoryTests()
        {
            _appConfig = Substitute.For<IAppConfig>();
            _sut = new MeterReaderFactory(_appConfig);
        }

        #endregion

        #region Public methods

        [TestMethod]
        public void GetMeterReaderType_AssemblyNameIsEmpty_ThrowsException()
        {
            //Arrange
            _appConfig.Get<string>("Petrol")
                .Returns("");

            //Assert & Act
            Assert.ThrowsException<ArgumentNullException>(() =>
                _sut.GetMeterReaderType(MeterType.Electricity));

        }


        [TestMethod]
        public void GetMeterReaderType_InvalidAssemblyName_ThrowsException()
        {
            //Arrange

            _appConfig.Get<string>("Electricity")
                .Returns("MeterCharge.Implementations.Petrol, MeterCharge");


            //Assert & Act
            Assert.ThrowsException<ArgumentNullException>(() =>
                _sut.GetMeterReaderType(MeterType.Electricity));

        }


        [TestMethod]
        public void GetMeterReaderType_Returns_Electricity()
        {
            //Arrange
            _appConfig.Get<string>("Electricity")
                .Returns("MeterCharge.Implementations.Electricity, MeterCharge");

            //Act
            var meterReaderType = _sut.GetMeterReaderType(MeterType.Electricity);

            //Assert
            Assert.AreEqual("MeterCharge.Implementations.Electricity", meterReaderType.GetType().FullName);
        }


        [TestMethod]
        public void GetMeterReaderType_Returns_Water()
        {
            //Arrange
            _appConfig.Get<string>("Water")
                .Returns("MeterCharge.Implementations.Water, MeterCharge");

            //Act
            var meterReaderType = _sut.GetMeterReaderType(MeterType.Water);

            //Assert
            Assert.AreEqual("MeterCharge.Implementations.Water", meterReaderType.GetType().FullName);
        }


        [TestMethod]
        public void GetMeterReaderType_Returns_Heating()
        {
            //Arrange
            _appConfig.Get<string>("Heating")
                .Returns("MeterCharge.Implementations.Heating, MeterCharge");

            //Act
            var meterReaderType = _sut.GetMeterReaderType(MeterType.Heating);

            //Assert
            Assert.AreEqual("MeterCharge.Implementations.Heating", meterReaderType.GetType().FullName);
        }
    }

    #endregion
}
