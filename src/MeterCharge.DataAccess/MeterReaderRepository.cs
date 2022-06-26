// <copyright file="MeterReaderRepository.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

using MeterCharge.DataAccess.Interfaces;
using MeterCharge.Schema.Models;

namespace MeterCharge.DataAccess
{
    public class MeterReaderRepository: IMeterReaderRepository
    {

        public void SaveMeterRead(MeterReaderDto meterReaderEntity)
        {
            using (var context = new MeterReaderContext())
            {
                context.MeterReaders.Add(meterReaderEntity);
                context.SaveChanges();
            }
        }

    }
}
