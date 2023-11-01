using System;
using System.Collections.Generic;

namespace WSVentaAPI.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
