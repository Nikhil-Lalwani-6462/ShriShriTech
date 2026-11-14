using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class Brand
{
    public int Bid { get; set; }

    public string? Bname { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual ICollection<CategoryBrand> CategoryBrands { get; set; } = new List<CategoryBrand>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<UserBrand> UserBrands { get; set; } = new List<UserBrand>();
}
