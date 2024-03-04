using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MakiYumpuSAC.Models;

public partial class CardexMaterial
{
    [Key]
    public int IdMaterial { get; set; }

    [Required(ErrorMessage = "Ingrese el tipo")]
    public bool Tipo { get; set; }

    [Required(ErrorMessage = "La cantidad es requerida")]
    public decimal Cantidad { get; set; }

    public decimal Stock { get; set; }

    public short? Conos { get; set; }

    public virtual Material IdMaterialNavigation { get; set; } = null!;
}
