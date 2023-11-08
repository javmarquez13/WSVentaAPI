using System;
using System.Collections.Generic;

namespace WSVentaAPI;

public partial class Client
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
