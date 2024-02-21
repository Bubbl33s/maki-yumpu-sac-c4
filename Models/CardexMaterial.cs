using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MakiYumpuSAC.Models;

public partial class CardexMaterial
{
    [Key]
    public int IdMaterial { get; set; }

    public bool Tipo { get; set; }

    public decimal Cantidad { get; set; }

    public decimal Stock { get; set; }

    public short? Conos { get; set; }

    public virtual Material IdMaterialNavigation { get; set; } = null!;
}
