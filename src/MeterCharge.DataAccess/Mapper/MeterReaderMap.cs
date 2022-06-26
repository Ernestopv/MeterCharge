// <copyright file="MeterReaderMap.cs" company="Kamstrup Spain, S. L.">
// Copyright (c) Kamstrup. All rights reserved.
// </copyright>

namespace MeterCharge.DataAccess.Mapper
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Schema.Models;

    /// <summary>
    /// Handles the mapping of MeterReader schema model to db 
    /// </summary>
    public class MeterReaderMap : EntityTypeConfiguration<MeterReaderDto>
    {

        /// <summary>
        /// Initialises a new instance of the <see cref="MeterReaderMap"/> class.
        /// </summary>
        public MeterReaderMap()
        {

            this.HasKey(m => m.Guid);
            this.Property(m => m.MeterName).HasMaxLength(50).IsRequired();
            this.Property(m => m.Timestamp).HasColumnType("DateTime");
            this.Property(m => m.MeterType).HasMaxLength(15);
            this.Property(m => m.Consumption).HasColumnType("int");
            this.Property(m => m.Cost).HasColumnType("int");
            this.Property(m => m.Charge).HasColumnType("int");


            this.ToTable("MeterReader", "dbo");
            this.Property(m => m.Guid).HasColumnName("Guid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.MeterName).HasColumnName("Meter_Name");
            this.Property(m => m.Timestamp).HasColumnName("Timestamp");
            this.Property(m => m.MeterType).HasColumnName("Meter_Type");
            this.Property(m => m.Consumption).HasColumnName("Consumption");
            this.Property(m => m.Cost).HasColumnName("Cost");
            this.Property(m => m.Charge).HasColumnName("Charge");

        }
    }
}
