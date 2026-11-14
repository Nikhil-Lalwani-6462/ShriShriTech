using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class Product
{
    public int Pid { get; set; }

    public int? UserId { get; set; }

    public int? CatId { get; set; }

    public int? BrandId { get; set; }

    public string? Model { get; set; }

    public int? StoreQty { get; set; }

    public int? WarehouseQty { get; set; }

    public bool? Isdisplay { get; set; }

    public int? Nlc { get; set; }

    public int? SellingPrice { get; set; }

    public bool? IsActive { get; set; }

    public bool? TotalPrice { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public decimal? Ton { get; set; }

    public string? Tool { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Cat { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual TechUser? User { get; set; }
}
