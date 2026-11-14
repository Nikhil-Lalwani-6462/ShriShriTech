using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class SaleBill
{
    public int SaleId { get; set; }

    public int? UserId { get; set; }

    public string? CustomerName { get; set; }

    public int? CustomerContact { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CustomerCity { get; set; }

    public int? PinCode { get; set; }

    public string? CustomerDistrict { get; set; }

    public string? CustomerState { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyGst { get; set; }

    public int? TotalBillQty { get; set; }

    public int? TotalBillPrice { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual TechUser? User { get; set; }
}
