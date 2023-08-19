using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class Adopcion
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? AnimalId { get; set; }

    public DateTime? FechaAdopcion { get; set; }

    public string? ComentariosAdicionales { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
