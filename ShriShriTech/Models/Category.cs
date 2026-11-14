using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class Category
{
    public int CatId { get; set; }

    public string? CatName { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual ICollection<CategoryBrand> CategoryBrands { get; set; } = new List<CategoryBrand>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
}
