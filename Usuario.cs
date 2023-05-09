using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerDesafio
{
    public class Usuario
    {
        private int _id;
        private String _nombre;
        private String _apellido;
        private String _nombreUsuario;
        private String _contraseña;
        private String _mail;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

    }
}