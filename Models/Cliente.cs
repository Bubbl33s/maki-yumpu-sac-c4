using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MakiYumpuSAC.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "Ingrese su nombre")]
    [MaxLength(50)]
    public string? NombreCompletoCliente { get; set; }

    [Required(ErrorMessage = "Ingrese su correo")]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    [MaxLength(30)]
    public string? CorreoCliente { get; set; }

    [Required(ErrorMessage = "Seleccione su país")]
    [MaxLength(30)]
    public string? PaisCliente { get; set; }

    [DefaultValue(false)]
    public bool Activo { get; set; }
    
    [DefaultValue(false)]
    public bool Revisado { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
