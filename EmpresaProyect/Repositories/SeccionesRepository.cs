using EmpresaProyect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaProyect.Repositories
{
    public class SeccionesRepository
    {
        EmpresaContext context = new();

        public IEnumerable<Secciones> GetAll()
        {
            return context.Secciones.Where(x=>x.Eliminado==0).OrderBy(x => x.Nombre);
        }

        public void InsertSeccion(Secciones s)
        {
            context.Secciones.Add(s);
            context.SaveChanges();
        }

        public void RemoveSeccion(Secciones s)
        {
            if (context.Secciones.Find(s.Id).Empleados.Count == 0)
            {
                context.Secciones.Remove(s);
            }
            else
            {
                s.Eliminado = 1;
            }
            context.SaveChanges();
        }

        public void UpdateSecciones(Secciones s)
        {

        }

    }
}
