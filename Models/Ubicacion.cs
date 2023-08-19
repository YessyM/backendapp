using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class Ubicacion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public virtual ICollection<Veterinario> Veterinarios { get; set; } = new List<Veterinario>();
}
