using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MakiYumpuSAC.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string ApPatUsuario { get; set; } = null!;

    public string? ApMatUsuario { get; set; }

    public string NombresUsuario { get; set; } = null!;

    public string DniUsuario { get; set; } = null!;

    public string LoginUsuario { get; set; } = null!;

    public string PasswordUsuario { get; set; } = null!;

    public DateTime FechaNacUsuario { get; set; }

    public bool EsAdmin { get; set; }

    [DefaultValue(true)]
    public bool Activo { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
