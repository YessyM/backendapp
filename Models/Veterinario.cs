using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class Veterinario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public string? Especialidad { get; set; }

    public int? UbicacionId { get; set; }

    public virtual Ubicacion? Ubicacion { get; set; }

    public virtual ICollection<Visitasveterinario> Visitasveterinarios { get; set; } = new List<Visitasveterinario>();
}
