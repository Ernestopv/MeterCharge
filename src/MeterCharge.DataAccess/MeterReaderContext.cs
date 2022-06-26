// <copyright file="MeterReaderContext.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess
{
    using System.Data.Entity;
    using Mapper;
    using Schema.Models;

    /// <summary>
    /// Meter reader context
    /// </summary>
    public class MeterReaderContext : DbContext
    {
        #region Public fields

        /// <summary>
        /// Meter Readers
        /// </summary>
        public DbSet<MeterReaderDto> MeterReaders { get; set; }

        #endregion

        #region public constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="MeterReaderContext"/> class.
        /// </summary>
        public MeterReaderContext():base("name=MetersDb")
        {
            
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// On model creating 
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MeterReaderMap());
        }

        #endregion

    }
}
