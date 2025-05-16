using System;
using System.Collections.Generic;

namespace EmpresaProyect.models;

public partial class Empleados
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Sueldo { get; set; }

    public int IdSeccion { get; set; }

    public byte? Eliminado { get; set; }

    public virtual Secciones IdSeccionNavigation { get; set; } = null!;
}
