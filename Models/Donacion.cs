using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class Donacion
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaDonacion { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
