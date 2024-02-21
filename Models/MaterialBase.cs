using System;
using System.Collections.Generic;

namespace MakiYumpuSAC.Models;

public partial class MaterialBase
{
    public string IdMaterialBase { get; set; } = null!;

    public string? DescMaterial { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
