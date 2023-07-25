﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindExampleApp4.Data;
using NorthWindExampleApp4.Models;
using System;
using System.Collections.Generic;

namespace NorthWindExampleApp4.Data.Configurations
{
    public partial class TerritoriesConfiguration : IEntityTypeConfiguration<Territories>
    {
        public void Configure(EntityTypeBuilder<Territories> entity)
        {
            entity.HasKey(e => e.TerritoryID).IsClustered(false);

            entity.HasIndex(e => e.RegionID, "IX_Territories_RegionID");

            entity.Property(e => e.TerritoryID).HasMaxLength(20);
            entity.Property(e => e.TerritoryDescription)
            .IsRequired()
            .HasMaxLength(50)
            .IsFixedLength();

            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
            .HasForeignKey(d => d.RegionID)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Territories_Region");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Territories> entity);
    }
}
