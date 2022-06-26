// <copyright file="IFileHandler.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterCharge.Models;

namespace MeterCharge.Infrastructure.Helpers.Interfaces
{
    public interface IFileHandler
    {
        void CreateFileIfExists();

        void CreateColumnsOnFileText(string fileName);

        void WriteMeterReaderDetails(MeterReader result);
    }
}
