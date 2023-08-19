using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Cedula { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Ubicacion { get; set; }

    public string? Celular { get; set; }

    public string? Clave { get; set; }

    public int? TipoDeUsuario { get; set; }

    public virtual ICollection<Adopcion> Adopcions { get; set; } = new List<Adopcion>();

    public virtual ICollection<Donacion> Donacions { get; set; } = new List<Donacion>();

    public virtual ICollection<Rescate> Rescates { get; set; } = new List<Rescate>();

    public virtual TiposUsuario? TipoDeUsuarioNavigation { get; set; }
}
