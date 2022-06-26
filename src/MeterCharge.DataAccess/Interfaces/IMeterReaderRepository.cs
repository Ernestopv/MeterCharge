// <copyright file="IMeterReaderRepository.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

using MeterCharge.Schema.Models;

namespace MeterCharge.DataAccess.Interfaces
{
    public interface IMeterReaderRepository
    {
        void SaveMeterRead(MeterReaderDto meterReaderEntity);
    }
}
