using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MakiYumpuSAC.Models;

public partial class MaterialBase
{
    public int IdMaterialBase { get; set; }

    [Required(ErrorMessage = "Ingrese el código del material")]
    public string? CodigoMaterial { get; set; }
    
    public string? DescMaterial { get; set; }

    [DefaultValue(true)]
    public bool Activo { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
