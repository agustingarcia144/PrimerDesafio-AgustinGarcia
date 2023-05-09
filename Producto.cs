using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerDesafio
{
    public class Producto
    {
        private int _id;
        private String _descripcion;
        private int _costo;
        private int _precioVenta;
        private int _stock;
        private int _idUsuario;

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int costo { get; set; }
        public int PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
