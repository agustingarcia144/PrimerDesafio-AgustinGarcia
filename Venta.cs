using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerDesafio
{
    public class Venta
    {
        private int _id;
        private String _comentarios;
        private int _idUsuario;

        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }
    }
}
