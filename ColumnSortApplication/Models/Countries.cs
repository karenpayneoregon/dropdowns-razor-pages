﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System.ComponentModel.DataAnnotations;

namespace ColumnSortApplication.Models;

public partial class Countries
{
    public int CountryIdentifier { get; set; }
    [Display(Name = "Country")]
    public string Name { get; set; }

    public virtual ICollection<Customers> Customers { get; } = new List<Customers>();

    public virtual ICollection<Employees> Employees { get; } = new List<Employees>();

    public virtual ICollection<Suppliers> Suppliers { get; } = new List<Suppliers>();
}