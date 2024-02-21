using System;
using System.Collections.Generic;

namespace MakiYumpuSAC.Models;

public partial class OrdenCompra
{
    public int IdOcm { get; set; }

    public DateTime FechaOc { get; set; }

    public bool EstadoOc { get; set; }

    public virtual ICollection<DetalleOc> DetalleOcs { get; set; } = new List<DetalleOc>();
}
