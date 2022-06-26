// <copyright file="MeterChargeSaverTests.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Tests.Implementations
{
    using System;
    using System.Collections.Generic;
    using DataAccess.Factories.Interfaces;
    using DataAccess.Interfaces;
    using MeterCharge.Factories.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Models.Enums;
    using NSubstitute;

    /// <summary>
    /// Handles meterCharge saver tests
    /// </summary>
    [TestClass]
    public class MeterChargeSaverTests
    {
        #region Private fields

        /// <summary>
        /// The meter reader factory
        /// </summary>
        private readonly IMeterReaderFactory _meterReaderFactory;

        /// <summary>
        /// The storage factory
        /// </summary>
        private readonly IStorageFactory _storageFactory;

        /// <summary>
        /// the storage
        /// </summary>
        private readonly IData _storage;

        /// <summary>
        /// The MeterChargeSaver sut (substitute)
        /// </summary>
        private readonly MeterChargeSaver _sut;

        #endregion

        #region Public constructors

        public MeterChargeSaverTests()
        {
            _storageFactory = Substitute.For<IStorageFactory>();
            _storage = Substitute.For<IData>();
            _storageFactory.GetStorageType().Returns(_storage);
            _meterReaderFactory = Substitute.For<IMeterReaderFactory>();
            _sut = new MeterChargeSaver(_meterReaderFactory, _storageFactory);
        }

        #endregion

        #region Public methods

        [TestMethod]
        public void Test_CalculateChargeForMeterReadingsAndSave()
        {
            //Arrange

            var meterModel = new Meter
            { Id = Guid.NewGuid().ToString(), MeterType = MeterType.Water, Readings = new List<int> { 98 } };

            var meters = new List<Meter>()
            {
                meterModel

            };

            var expectedEntity = new MeterReader()
            {
                MeterType = MeterType.Water,
                Consumption = 98,
                Cost = 3,
                Charge = 294
            };


            foreach (var meter in meters)
            {
                _storage.SetMeterName(Arg.Any<Meter>()).Returns("Meter-XXXXXXXXXXXXXXX");

                foreach (var reading in meter.Readings)
                {
                    var meterReader = _meterReaderFactory.GetMeterReaderType(Arg.Any<MeterType>());
                    meterReader.GetReading(Arg.Any<int>()).Returns(expectedEntity);

                    _storage.SaveConsumption(Arg.Any<MeterReader>());

                }
            }

            //Act
            _sut.CalculateChargeForMeterReadingsAndSave(meters);

            //Assert
            _storage.ReceivedWithAnyArgs(1).SetMeterName(meterModel);
            _meterReaderFactory.ReceivedWithAnyArgs(1).GetMeterReaderType(MeterType.Water);
            _storage.ReceivedWithAnyArgs(1).SaveConsumption(expectedEntity);

        }

        #endregion
    }
}
