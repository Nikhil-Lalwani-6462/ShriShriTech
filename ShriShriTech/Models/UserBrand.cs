using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class UserBrand
{
    public int Ubid { get; set; }

    public int? UserId { get; set; }

    public int? Bid { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual Brand? BidNavigation { get; set; }

    public virtual TechUser? User { get; set; }
}
