// <copyright file="WaterTests.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Tests.Implementations
{
    using FluentAssertions;
    using Interfaces;
    using MeterCharge.Implementations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Models.Enums;

    [TestClass]
    public class WaterTests
    {
        #region Private fields

        /// <summary>
        /// the water meter
        /// </summary>
        private readonly IMeterReader _waterMeter;

        #endregion

        #region Public constructors

        /// <summary>
        ///  Initialises a new instance of the <see cref="WaterTests"/> class.
        /// </summary>
        public WaterTests()
        {
            _waterMeter = new Water();
        }

        #endregion

        #region Public methods

        [TestMethod]
        public void Calculate_Water_Reading_Consumption()
        {
            //Arrange
            const int consumption = 98;
            var expectedResult = new MeterReader()
            {
                MeterType = MeterType.Water,
                Charge = 294,
                Cost = 3,
                Consumption = 98
            };

            //Act
            var result = _waterMeter.GetReading(consumption);

            //Assert

            result.Should().BeEquivalentTo(expectedResult);

        }

        #endregion
    }
}
