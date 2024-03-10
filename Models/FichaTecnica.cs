using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MakiYumpuSAC.Models;

public partial class FichaTecnica
{
    public int IdFichaTecnica { get; set; }

    public string? DescPrenda { get; set; }

    public DateTime FechaFt { get; set; }

    public int IdCliente { get; set; }

    public string? OtrosMaterialesDesc { get; set; }

    public decimal? PesoPrenda { get; set; }

    public string? TallaPrenda { get; set; }

    public string TejidoDesc { get; set; } = null!;

    public string ArmadoDesc { get; set; } = null!;

    public string AcabadosDesc { get; set; } = null!;

    public string? VaporizadoDesc { get; set; }

    [DefaultValue(true)]
    public bool Activo { get; set; }

    public int IdDetallePedido { get; set; }

    public virtual ICollection<DetalleFt> DetalleFts { get; set; } = new List<DetalleFt>();

    public virtual ICollection<ImgFichaTecnica> ImgFichaTecnicas { get; set; } = new List<ImgFichaTecnica>();

    public virtual DetallePedido IdDetallePedidoNavigation { get; set; } = null!;
}
