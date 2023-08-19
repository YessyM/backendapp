using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class TiposUsuario
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
