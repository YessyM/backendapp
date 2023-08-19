using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class Rescate
{
    public int Idrescate { get; set; }

    public string? NombreDeRescatista { get; set; }

    public string? ApellidoDeRescatista { get; set; }

    public string? CorreoDeRescatista { get; set; }

    public string? CelularDeRescatista { get; set; }

    public string? DescripcionRescate { get; set; }

    public byte[]? Imagen { get; set; }

    public int? Idusuario { get; set; }

    public int? Idanimal { get; set; }

    public virtual Animal? IdanimalNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
