using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using P4P3Seguridad.models;
using P4P3Seguridad.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace P4P3Seguridad.Repositories
{
    public class UsuariosRepository
    {
        SeguridadContext context = new();

        public void Insert(Usuarios u)
        {
            context.Database.ExecuteSqlRaw(
            "EXEC spRegistrarUsuarios @p0, @p1, @p2, @p3",
            u.Nombre,
            u.Correo,
            u.Rol,
            u.Contrasena);
        }

        public Usuarios Secion(string correo)
        {
            return context.Usuarios.First(x => x.Correo == correo);
        }

        public int Login(UsuarioLogin u)
        {
            var resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            context.Database.ExecuteSqlRaw("EXEC SpValidarLogin @Correo, @Contrasena, @Resultado OUTPUT",
                                           new SqlParameter("@Correo", u.Correo),
                                           new SqlParameter("@Contrasena", u.Contrasena),
                                           resultadoParam);

            return (int)resultadoParam.Value;
        }

        public bool Validar(Usuarios u, out string? error)
        {
            List<string> listaerrores = new();

            if (string.IsNullOrWhiteSpace(u.Nombre)) 
            {
                listaerrores.Add("Agregue un nombre");
            }
            if (u.Nombre != null)
            {
                if (context.Usuarios.Any(user => user.Nombre == u.Nombre))
                {
                    listaerrores.Add("El nombre ya está registrado.");
                }
            }
            if (string.IsNullOrWhiteSpace(u.Correo))
            {
                listaerrores.Add("Agregue un Correo");
            }
            if (string.IsNullOrWhiteSpace(u.Rol))
            {
                listaerrores.Add("Agregue un Rol");
            }
            if (string.IsNullOrWhiteSpace(u.Contrasena))
            {
                listaerrores.Add("Agregue una contraseña");
            }

            if (u.Correo != null)
            {
                if (!EsCorreoValido(u.Correo))
                {
                    listaerrores.Add("El correo no tiene un formato válido.");
                }
            }

            if (u.Correo != null)
            {
                if (context.Usuarios.Any(user => user.Correo == u.Correo))
                {
                    listaerrores.Add("El correo ya está registrado.");
                }
            }


            error = string.Join(Environment.NewLine, listaerrores);
            return listaerrores.Count != 0;
        }
        public bool EsCorreoValido(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patron);
        }
    }
}
