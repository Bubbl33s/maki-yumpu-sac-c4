using System;
using System.Collections.Generic;

namespace MakiYumpuSAC.Models;

public partial class ImgFichaTecnica
{
    public int IdImgFt { get; set; }

    public int IdFichaTecnica { get; set; }

    public string RutaImagen { get; set; } = null!;

    public virtual FichaTecnica IdFichaTecnicaNavigation { get; set; } = null!;
}
