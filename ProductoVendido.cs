using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductoVendido
    {
        private int _id;
        private int _idProducto;
        private int _stock;
        private int _idVenta;


        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }

    public List<ProductoVendido> ProductosVendido;

    public ProductoVendido()
    {
        ProductosVendido = new List<ProductoVendido>();
    }

    public static List<ProductoVendido> ListarProductoVendido()
    {
        String connectionString = "Server=AG-DESKTOP\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        var query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido";
        var ListaProductoVendido = new List<ProductoVendido>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ProductoVendido = new ProductoVendido();
                            ProductoVendido.Id = Convert.ToInt32(reader["Id"]);
                            ProductoVendido.Stock = Convert.ToInt32(reader["Stock"]);
                            ProductoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                            ProductoVendido.IdVenta = Convert.ToInt32(reader["IdVenta"]);

                            ListaProductoVendido.Add(ProductoVendido);
                        }
                    }
                }
            }
            connection.Close();

        }

        return ListaProductoVendido;
    }
}