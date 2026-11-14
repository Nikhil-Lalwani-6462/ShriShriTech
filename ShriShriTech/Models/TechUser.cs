using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class TechUser
{
    public int UserId { get; set; }

    public int? ClientId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? ContactNo { get; set; }

    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }

    public string? Designation { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public int? PinCode { get; set; }

    public string? StoreAddress { get; set; }

    public string? State { get; set; }

    public virtual ClientAdmin? Client { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SaleBill> SaleBills { get; set; } = new List<SaleBill>();

    public virtual ICollection<UserBrand> UserBrands { get; set; } = new List<UserBrand>();
}
