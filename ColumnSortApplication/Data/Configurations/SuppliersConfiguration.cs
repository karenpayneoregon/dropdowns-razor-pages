﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindExampleApp4.Data;
using System;
using System.Collections.Generic;
using ColumnSortApplication.Models;

namespace NorthWindExampleApp4.Data.Configurations
{
    public partial class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers>
    {
        public void Configure(EntityTypeBuilder<Suppliers> entity)
        {
            entity.HasKey(e => e.SupplierID);

            entity.HasIndex(e => e.CountryIdentifier, "IX_Suppliers_CountryIdentifier");

            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName)
            .IsRequired()
            .HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.HomePage).HasColumnType("ntext");
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.Street).HasMaxLength(60);

            entity.HasOne(d => d.CountryIdentifierNavigation).WithMany(p => p.Suppliers)
            .HasForeignKey(d => d.CountryIdentifier)
            .HasConstraintName("FK_Suppliers_Countries");

            entity.HasOne(d => d.RegionNavigation).WithMany(p => p.Suppliers)
            .HasForeignKey(d => d.RegionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Suppliers_SupplierRegion1");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Suppliers> entity);
    }
}
