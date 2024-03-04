using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MakiYumpuSAC.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "Ingrese apellido paterno")]
    public string ApPatUsuario { get; set; } = null!;

    public string? ApMatUsuario { get; set; }

    [Required(ErrorMessage = "Ingrese nombres")]
    public string NombresUsuario { get; set; } = null!;

    [Required(ErrorMessage = "Ingrese DNI")]
    public string DniUsuario { get; set; } = null!;

    [Required(ErrorMessage = "Ingrese el usuario")]
    public string LoginUsuario { get; set; } = null!;

    [Required(ErrorMessage = "Ingrese la contraseña")]
    public string PasswordUsuario { get; set; } = null!;

    public DateTime FechaNacUsuario { get; set; }

    public bool EsAdmin { get; set; }

    [DefaultValue(true)]
    public bool Activo { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
