using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MakiYumpuSAC.Models;

public partial class OrdenCompra
{
    public int IdOcm { get; set; }

    public DateTime FechaOc { get; set; }

    [DefaultValue(true)]
    public bool EstadoOc { get; set; }

    public virtual ICollection<DetalleOc> DetalleOcs { get; set; } = new List<DetalleOc>();
}
