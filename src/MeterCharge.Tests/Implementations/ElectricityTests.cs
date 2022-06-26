// <copyright file="ElectricityTests.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Tests.Implementations
{
    using System;
    using FluentAssertions;
    using Interfaces;
    using MeterCharge.Implementations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Models.Enums;

    /// <summary>
    /// Handles the calculation tests for Electricity
    /// </summary>
    [TestClass]
    public class ElectricityTests
    {
        #region Private fields

        /// <summary>
        /// The meter reader for electricity
        /// </summary>
        private IMeterReader _electricityMeter;

        #endregion

        #region Public Methods

        [TestMethod]
        public void Calculate_Heating_Reading_consumption_HalfPrice_at_offPeakHrs_before_8()
        {
            //Arrange
            // half price at off peak hours: before 8 and after 20.
            // time = 25/06/2022 7:32:05 before 8 am 
            var dateTime = new DateTime(2022, 06, 25, 7, 32, 5);
            _electricityMeter = new Electricity(dateTime);

            const int consumption = 97;


            var expectedResult = new MeterReader()
            {
                MeterType = MeterType.Electricity,
                Charge = 194,
                Cost = 2,
                Consumption = 97
            };

            //Act
            var result = _electricityMeter.GetReading(consumption);

            //Assert

            result.Should().BeEquivalentTo(expectedResult);

        }


        [TestMethod]
        public void Calculate_Heating_Reading_consumption_HalfPrice_at_offPeakHrs_After_20()
        {
            //Arrange
            // half price at off peak hours: before 8 and after 20.
            // time = 25/06/2022 22:32:05 After 20 pm 
            var dateTime = new DateTime(2022, 06, 25, 22, 32, 5);
            _electricityMeter = new Electricity(dateTime);

            const int consumption = 97;


            var expectedResult = new MeterReader()
            {
                MeterType = MeterType.Electricity,
                Charge = 194,
                Cost = 2,
                Consumption = 97
            };

            //Act
            var result = _electricityMeter.GetReading(consumption);

            //Assert

            result.Should().BeEquivalentTo(expectedResult);

        }

        [TestMethod]
        public void Calculate_Heating_Reading_consumption_NormalHours()
        {
            //Arrange
            // half price at off peak hours: before 8 and after 20.
            // time = 25/06/2022 13:32:05 Normal hours
            var dateTime = new DateTime(2022, 06, 25, 13, 32, 5);
            _electricityMeter = new Electricity(dateTime);

            const int consumption = 97;

            var expectedResult = new MeterReader()
            {
                MeterType = MeterType.Electricity,
                Charge = 388,
                Cost = 4,
                Consumption = 97
            };

            //Act
            var result = _electricityMeter.GetReading(consumption);

            //Assert

            result.Should().BeEquivalentTo(expectedResult);

        }

        #endregion
    }
}
