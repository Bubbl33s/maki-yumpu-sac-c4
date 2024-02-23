using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MakiYumpuSAC.Models;

public partial class MaterialBase
{
    public int IdMaterialBase { get; set; }

    public string? CodigoMaterial { get; set; }

    public string? DescMaterial { get; set; }

    [DefaultValue(true)]
    public bool Activo { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
