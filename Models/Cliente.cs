using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MakiYumpuSAC.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "Ingrese su nombre")]
    public string? NombreCompletoCliente { get; set; }

    [Required(ErrorMessage = "Ingrese su correo")]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    public string? CorreoCliente { get; set; }

    [Required(ErrorMessage = "Seleccione su país")]
    public string? PaisCliente { get; set; }

    [DefaultValue(true)]
    public bool Activo { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
