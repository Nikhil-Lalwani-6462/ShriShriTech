using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class SaleItem
{
    public int Sliid { get; set; }

    public string? SerialNo { get; set; }

    public int? SaleId { get; set; }

    public int? Pid { get; set; }

    public string? FromLocation { get; set; }

    public bool? IsDisplay { get; set; }

    public string? ReturnedAt { get; set; }

    public string? ReturnedReason { get; set; }

    public string? SaleStatus { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual Product? PidNavigation { get; set; }

    public virtual SaleBill? Sale { get; set; }
}
