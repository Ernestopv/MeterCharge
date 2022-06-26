// <copyright file="HeatingTests.cs" company="Kamstrup Spain, S. L.">
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

    /// <summary>
    /// Handles the Heating calculation tests
    /// </summary>
    [TestClass]
    public class HeatingTests
    {
        #region Private fields

        /// <summary>
        /// the heating meter
        /// </summary>
        private readonly IMeterReader _heatingMeter;

        #endregion

        #region Public constructors

        /// <summary>
        ///  Initialises a new instance of the <see cref="HeatingTests"/> class.
        /// </summary>
        public HeatingTests()
        {
            _heatingMeter = new Heating();
        }

        #endregion

        #region Public methods

        [TestMethod]
        public void Calculate_Heating_Reading_consumption()
        {
            //Arrange
            const int consumption = 55;
            var expectedResult = new MeterReader()
            {
                MeterType = MeterType.Heating,
                Charge = 275,
                Cost = 5,
                Consumption = 55
            };

            //Act
            var result = _heatingMeter.GetReading(consumption);

            //Assert

            result.Should().BeEquivalentTo(expectedResult);

        }

        #endregion
    }
}
