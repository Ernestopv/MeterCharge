// <copyright file="DbTests.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess.Tests.Implementations
{
    using DataAccess.Implementations;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Models.Enums;
    using NSubstitute;
    using NSubstitute.ReceivedExtensions;
    using Schema.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Handles db tests
    /// </summary>
    [TestClass]
    public class DbTests
    {
        #region Private fields

        /// <summary>
        /// The db repository
        /// </summary>
        private readonly IMeterReaderRepository _repository;

        /// <summary>
        /// Handles db class
        /// </summary>
        private readonly Db _sut;

        #endregion

        #region Public constructors

        /// <summary>
        ///  Initialises a new instance of the <see cref="DbTests"/> class.
        /// </summary>
        public DbTests()
        {
            _repository = Substitute.For<IMeterReaderRepository>();
            _sut = new Db(_repository);
        }

        #endregion


        #region Public methods

        [TestMethod]
        public void Test_SetMeterName_Returns_meterName()
        {
            //Arrange
            var meterName = "Meter-xxxxxxxxxxxxxx";

            var meter = new Meter()
            {
                Id = "xxxxxxxxxxxxxx",
                MeterType = MeterType.Electricity,
                Readings = new List<int>() { 98 }
            };

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

            var entity = new MeterReaderDto()
            {
                MeterType = input.MeterType.ToString(),
                Consumption = input.Consumption,
                Cost = input.Cost,
                MeterName = input.MeterName,
                Charge = input.Charge,
                Timestamp = DateTime.Now
            };


            _repository.SaveMeterRead(Arg.Any<MeterReaderDto>());

            //Act

            _sut.SaveConsumption(input);

            //Assert
            _repository.ReceivedWithAnyArgs(1).SaveMeterRead(entity);

        }

        #endregion
    }
}
