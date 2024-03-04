﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MakiYumpuSAC.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateTime FechaGeneracionPedido { get; set; }

    public DateTime FechaEntrega { get; set; }

    public int IdCliente { get; set; }

    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "")]
    public string? EstadoPedidoId { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
