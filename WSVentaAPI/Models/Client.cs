using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WSVentaAPI.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
