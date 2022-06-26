// <copyright file="IData.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>



namespace MeterCharge.DataAccess.Interfaces
{
    using Models;

    public interface IData
    {   void SaveConsumption(MeterReader result);
        string SetMeterName(Meter meter);
    }
}
