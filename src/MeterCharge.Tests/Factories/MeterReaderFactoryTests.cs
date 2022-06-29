// <copyright file="MeterReaderFactoryTests.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Tests.Factories
{
    using MeterCharge.Factories.Implementations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Enums;

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


        #endregion

        #region Public constructors

        /// <summary>
        ///  Initialises a new instance of the <see cref="MeterReaderFactoryTests"/> class.
        /// </summary>
        public MeterReaderFactoryTests()
        {
            _sut = new MeterReaderFactory();
        }

        #endregion

        #region Public methods


        [TestMethod]
        public void GetMeterReaderType_Returns_Electricity()
        {
            // Arrange & Act 
            var meterReaderType = _sut.GetMeterReaderType(MeterType.Electricity);

            //Assert
            Assert.AreEqual("MeterCharge.Implementations.Electricity", meterReaderType.GetType().FullName);
        }


        [TestMethod]
        public void GetMeterReaderType_Returns_Water()
        {
            //Arrange & Act
            var meterReaderType = _sut.GetMeterReaderType(MeterType.Water);

            //Assert
            Assert.AreEqual("MeterCharge.Implementations.Water", meterReaderType.GetType().FullName);
        }


        [TestMethod]
        public void GetMeterReaderType_Returns_Heating()
        {
            //Arrange & Act
            var meterReaderType = _sut.GetMeterReaderType(MeterType.Heating);

            //Assert
            Assert.AreEqual("MeterCharge.Implementations.Heating", meterReaderType.GetType().FullName);
        }
    }

    #endregion
}
