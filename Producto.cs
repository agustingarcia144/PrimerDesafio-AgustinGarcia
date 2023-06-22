using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Specialized;

public class Producto
    {
        private int _id;
        private string _descripciones;
        private decimal _costo;
        private decimal _precioVenta;
        private int _stock;
        private int _idUsuario;

        public int Id { get; set; }
        public string Descripciones { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

    public List<Producto> Productos;

    public Producto()
    {
        Productos = new List<Producto>();
    }

    public static List<Producto> ListarProductos()
    {
        String connectionString = "Server=AG-DESKTOP\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";
        var ListaProductos = new List<Producto>();

        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var producto = new Producto();
                            producto.Id = Convert.ToInt32(reader["Id"]);
                            producto.Descripciones = reader["Descripciones"].ToString();
                            producto.Costo = Convert.ToDecimal(reader["Costo"]);
                            producto.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(reader["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

                            ListaProductos.Add(producto);
                        }
                    }
                }
            } 
            connection.Close();

        }

        return ListaProductos;
    }


    }