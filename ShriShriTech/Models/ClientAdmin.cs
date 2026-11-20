using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class ClientAdmin
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string? ContactNo { get; set; }

    public string StoreName { get; set; } = null!;

    public string GstNo { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateOnly CreatedAt { get; set; }

    public virtual ICollection<TechUser> TechUsers { get; set; } = new List<TechUser>();
}
