using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MakiYumpuSAC.Models;

public partial class DetallePedido
{
    public int IdDetPedido { get; set; }

    public int IdPedido { get; set; }

    [MaxLength(50)]
    public string? DescPrenda { get; set; }

    [MaxLength(200)]
    public string? DetallesPrenda { get; set; }

    public int CantidadPrenda { get; set; }

    [DefaultValue(0.0)]
    public decimal PrecioUnitario { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual ICollection<FichaTecnica> FichasTecnicas { get; set; } = new List<FichaTecnica>();

}
