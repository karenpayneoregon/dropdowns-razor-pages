﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace ColumnSortApplication.Models;

public partial class SupplierRegion
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; }

    public virtual ICollection<Suppliers> Suppliers { get; } = new List<Suppliers>();
}