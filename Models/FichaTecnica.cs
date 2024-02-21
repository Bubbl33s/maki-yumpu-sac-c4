using System;
using System.Collections.Generic;

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

    public virtual ICollection<DetalleFt> DetalleFts { get; set; } = new List<DetalleFt>();

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<ImgFichaTecnica> ImgFichaTecnicas { get; set; } = new List<ImgFichaTecnica>();
}
