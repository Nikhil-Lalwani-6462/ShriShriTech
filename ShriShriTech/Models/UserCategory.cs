using System;
using System.Collections.Generic;

namespace ShriShriTech.Models;

public partial class UserCategory
{
    public int Ucid { get; set; }

    public int? CatId { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual Category? Cat { get; set; }
}
