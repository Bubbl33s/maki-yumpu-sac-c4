using System;
using System.Collections.Generic;

namespace MakiYumpuSAC.Models;

public partial class DetalleOc
{
    public int IdOcm { get; set; }

    public int IdMaterial { get; set; }

    public decimal Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual Material IdMaterialNavigation { get; set; } = null!;

    public virtual OrdenCompra IdOcmNavigation { get; set; } = null!;
}
