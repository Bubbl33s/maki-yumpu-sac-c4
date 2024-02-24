﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MakiYumpuSAC.Models;

public partial class Material
{
    public int IdMaterial { get; set; }

    public int IdMaterialBase { get; set; }

    public string IdPantone { get; set; } = null!;

    public string Hebras { get; set; } = null!;

    [DefaultValue(true)]
    public bool Activo { get; set; }

    public virtual ICollection<DetalleFt> DetalleFts { get; set; } = new List<DetalleFt>();

    public virtual ICollection<DetalleOc> DetalleOcs { get; set; } = new List<DetalleOc>();

    public virtual MaterialBase? IdMaterialBaseNavigation { get; set; } = null!;
}