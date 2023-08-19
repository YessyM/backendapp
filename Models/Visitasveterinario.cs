using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class Visitasveterinario
{
    public int Id { get; set; }

    public int? AnimalId { get; set; }

    public int? VeterinarioId { get; set; }

    public DateTime? FechaVisita { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Veterinario? Veterinario { get; set; }
}
