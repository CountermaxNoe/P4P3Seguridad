using System;
using System.Collections.Generic;

namespace P4P3Seguridad.models;

public partial class Usuarios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Contrasena { get; set; } = null!;
}