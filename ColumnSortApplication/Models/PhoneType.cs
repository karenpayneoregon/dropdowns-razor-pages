﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace ColumnSortApplication.Models;

public partial class PhoneType
{
    public int PhoneTypeIdenitfier { get; set; }

    public string PhoneTypeDescription { get; set; }

    public virtual ICollection<ContactDevices> ContactDevices { get; } = new List<ContactDevices>();
}