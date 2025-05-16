using EmpresaProyect.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaProyect.Repositories
{
    public class EmpleadosRepository
    {
        EmpresaContext context= new EmpresaContext();
        public void InsertEmpleado(Empleados e)
        { 
            context.Empleados.Add(e);
            context.SaveChanges();
        }

        public void RemoveEmpleado(Empleados e)
        {
            context.Empleados.Remove(e);
            context.SaveChanges();
        }

        public void UpdateEmpleado(Empleados e)
        {
            var empleadoExistente = context.Empleados.Find(e.Id);

            context.Entry(empleadoExistente).CurrentValues.SetValues(e);
            context.SaveChanges();
        }
    }
}
