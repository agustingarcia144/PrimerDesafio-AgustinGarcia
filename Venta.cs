using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Venta
    {
        private int _id;
        private String _comentarios;
        private int _idUsuario;

        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

    public List<Venta> Ventas;

    public Venta()
    {
        Ventas = new List<Venta>();
    }

    public static List<Venta> ListarVenta()
    {
        String connectionString = "Server=AG-DESKTOP\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        var query = "SELECT Id, Comentarios, IdUsuario FROM Venta";
        var ListaVenta = new List<Venta>();

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
                            var Venta = new Venta();
                            Venta.Id = Convert.ToInt32(reader["Id"]);
                            Venta.Comentarios = reader["Comentarios"].ToString();
                            Venta.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

                            ListaVenta.Add(Venta);
                        }
                    }
                }
            }
            connection.Close();

        }

        return ListaVenta;
    }
}
