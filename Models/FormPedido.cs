using System;
using System.Collections.Generic;

namespace MakiYumpuSAC.Models;

public partial class FormPedido
{
    public int IdFormPedido { get; set; }

    public string NombreCompletoCliente { get; set; } = null!;

    public string? CorreoCliente { get; set; }

    public string? PaisCliente { get; set; }

    public DateTime Fecha { get; set; }

    public virtual ICollection<DetalleFormPedido> DetalleFormPedidos { get; set; } = new List<DetalleFormPedido>();

    public virtual ICollection<ImgFormPedido> ImgFormPedidos { get; set; } = new List<ImgFormPedido>();
}
