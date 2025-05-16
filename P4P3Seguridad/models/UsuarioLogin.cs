using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4P3Seguridad.models
{
    public class UsuarioLogin
    {
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;

        public int Resultado {  get; set; }
    }
}
