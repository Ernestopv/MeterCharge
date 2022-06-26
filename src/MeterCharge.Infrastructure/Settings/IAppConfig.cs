// <copyright file="IAppConfig.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.Infrastructure.Settings
{
    public interface IAppConfig
    {
        T Get<T>(string key);
    }
}
