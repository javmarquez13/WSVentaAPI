using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WSVentaAPI.Models;

public partial class Product
{  
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? UnitPrice { get; set; }

    public decimal? Cost { get; set; }

    public virtual ICollection<Concept> Concepts { get; set; } = new List<Concept>();
}
