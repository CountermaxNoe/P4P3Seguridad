using System;
using System.Collections.Generic;

namespace EmpresaProyect.models;

public partial class Secciones
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal SueldoMaximo { get; set; }

    public int NumeroEmpleados { get; set; }

    public byte? Eliminado { get; set; }

    public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();
}
