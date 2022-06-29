// <copyright file="Program.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge
{
    using DataAccess;
    using DataAccess.Factories.Implementations;
    using DataAccess.Factories.Interfaces;
    using DataAccess.Interfaces;
    using Factories.Implementations;
    using Factories.Interfaces;
    using Infrastructure.Settings;
    using Microsoft.Practices.Unity;
    using Models;
    using Models.Enums;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //The lightweight extensible dependency injection container
            var container = new UnityContainer();
         
         
            var appConfig = new AppConfig();
            container.RegisterInstance<IAppConfig>(appConfig);
            container.RegisterType<IMeterReaderFactory, MeterReaderFactory>();
            container.RegisterType<IStorageFactory, StorageFactory>();
            container.RegisterType<IMeterReaderRepository, MeterReaderRepository>();

            container.Resolve<AppConfig>();
            container.Resolve<MeterReaderRepository>();
            var meterReaderFactory = container.Resolve<MeterReaderFactory>();
            var storageFactory = container.Resolve<StorageFactory>();

            //Meter readings
            var m1 = new Meter { Id = Guid.NewGuid().ToString(), MeterType = MeterType.Electricity, Readings = new List<int> { 97, 50 } };
            var m2 = new Meter { Id = Guid.NewGuid().ToString(), MeterType = MeterType.Heating, Readings = new List<int> { 55, 87 } };
            var m3 = new Meter { Id = Guid.NewGuid().ToString(), MeterType = MeterType.Water, Readings = new List<int> { 98, 86 } };

            var list1 = new List<Meter> { m1, m2, m3 };

            // Calculate
            new MeterChargeSaver(meterReaderFactory, storageFactory).CalculateChargeForMeterReadingsAndSave(list1);

        }
    }
}