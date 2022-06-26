// <copyright file="TextFileTests.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess.Tests.Implementations
{
    using DataAccess.Implementations;
    using Infrastructure.Helpers.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Models.Enums;
    using NSubstitute;
    using System.Collections.Generic;

    /// <summary>
    /// Handles the text file class tests
    /// </summary>
    [TestClass]
    public class TextFileTests
    {
        #region Private methods

        /// <summary>
        /// test the file handler text
        /// </summary>
        private readonly IFileHandler _fileHandler;

        /// <summary>
        /// Test the textfile substitute
        /// </summary>
        private readonly TextFile _sut;

        #endregion


        #region Public constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="TextFileTests"/> class.
        /// </summary>
        public TextFileTests()
        {
            _fileHandler = Substitute.For<IFileHandler>();
            _sut = new TextFile(_fileHandler);
        }

        #endregion


        #region Public methods

        [TestMethod]
        public void Test_SetMeterName_Returns_meterName()
        {
            //Arrange
            var meterName = "Meter-xxxxxxxxxxxxxx";
            var fileName = meterName + ".log";
            var meter = new Meter()
            {
                Id = "xxxxxxxxxxxxxx",
                MeterType = MeterType.Electricity,
                Readings = new List<int>() { 98 }
            };

            _fileHandler.CreateFileIfExists();
            _fileHandler.CreateColumnsOnFileText(fileName);

            //Act
            var result = _sut.SetMeterName(meter);

            //Assert
            Assert.AreEqual(result, meterName);
        }


        [TestMethod]
        public void Test_SaveConsumption()
        {
            //Arrange
            var input = new MeterReader()
            {
                MeterType = MeterType.Electricity,
                Charge = 45,
                Consumption = 32,
                Cost = 4,
                MeterName = "Meter-xxxxxxxxxxxxxx"

            };

            _fileHandler.WriteMeterReaderDetails(Arg.Any<MeterReader>());

            //Act
            _sut.SaveConsumption(input);

            //Assert
            _fileHandler.ReceivedWithAnyArgs(1).WriteMeterReaderDetails(input);

        }

        #endregion
    }
}
