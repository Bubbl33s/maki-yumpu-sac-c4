using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MakiYumpuSAC.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCompletoCliente { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
    public string? CorreoCliente { get; set; }

    public string? PaisCliente { get; set; }

    [DefaultValue(true)]
    public bool Activo { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
