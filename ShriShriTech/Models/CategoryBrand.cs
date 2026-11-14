using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class CategoryBrand
{
    public int Cbid { get; set; }

    public int? CatId { get; set; }

    public int? Bid { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual Brand? BidNavigation { get; set; }

    public virtual Category? Cat { get; set; }
}
