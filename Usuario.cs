using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    public List<Usuario> Usuarios;

    public Usuario()
    {
        Usuarios = new List<Usuario>();
    }

    public static List<Usuario> ListarUsuarios()
    {
        String connectionString = "Server=AG-DESKTOP\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        var query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail 
                                   FROM Usuario";
        var ListaUsuarios = new List<Usuario>();

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
                            var Usuario = new Usuario();
                            Usuario.Id = Convert.ToInt32(reader["Id"]);
                            Usuario.Nombre = reader["Nombre"].ToString();
                            Usuario.Apellido = reader["Apellido"].ToString();
                            Usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                            Usuario.Contraseña = reader["Contraseña"].ToString();
                            Usuario.Mail = reader["Mail"].ToString();

                            ListaUsuarios.Add(Usuario);
                        }
                    }
                }
            }
            connection.Close();

        }

        return ListaUsuarios;
    }

    public static Usuario IniciarSesion(string nombreUsuario, string contrasena)

    {
        String connectionString = "Server=AG-DESKTOP\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";

        using (var connection = new SqlConnection(connectionString))

        {

            connection.Open();

            var query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contrasena";

            using (var command = new SqlCommand(query, connection))

            {

                command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                command.Parameters.AddWithValue("@contrasena", contrasena);

                using (var reader = command.ExecuteReader())

                {

                    if (reader.Read())

                    {

                        return new Usuario

                        {

                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            NombreUsuario = reader["NombreUsuario"].ToString(),
                            Contraseña = reader["Contraseña"].ToString(),
                            Mail = reader["Mail"].ToString()

                        };

                    }

                    else

                    {

                        return null;

                    }

                }

            }

        }

    }
}
