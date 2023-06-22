// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

string nombreUsuario = "tcasazza";
string contrasena = "password";

Console.WriteLine("------Productos-------");

List<Producto> listaProductos = Producto.ListarProductos();

foreach (Producto producto in listaProductos)
{
    Console.WriteLine("ID : " + producto.Id.ToString());
    Console.WriteLine("Descripciones : " + producto.Descripciones.ToString());
    Console.WriteLine("Costo : " + producto.Costo.ToString());
    Console.WriteLine("Precio Venta : " + producto.PrecioVenta.ToString());
    Console.WriteLine("Stock : " + producto.Stock.ToString());
    Console.WriteLine("ID Usuario : " + producto.IdUsuario.ToString());
}

Console.WriteLine("------Usuarios-------");

List<Usuario> listaUsuarios = Usuario.ListarUsuarios();

foreach (Usuario usuario in listaUsuarios)
{
    Console.WriteLine("ID : " + usuario.Id.ToString());
    Console.WriteLine("Nombre : " + usuario.Nombre.ToString());
    Console.WriteLine("Apellido : " + usuario.Apellido.ToString());
    Console.WriteLine("Nombre de Usuario : " + usuario.NombreUsuario.ToString());
    Console.WriteLine("Mail : " + usuario.Mail.ToString());
    Console.WriteLine("Contraseña : " + usuario.Contraseña.ToString());
}

Console.WriteLine("------Productos Vendidos-------");

List<ProductoVendido> listaProductosVendidos = ProductoVendido.ListarProductoVendido();

foreach (ProductoVendido productoVendido in listaProductosVendidos)
{
    Console.WriteLine("ID : " + productoVendido.Id.ToString());
    Console.WriteLine("ID Producto : " + productoVendido.IdProducto.ToString());
    Console.WriteLine("Stock : " + productoVendido.Stock.ToString());
    Console.WriteLine("ID Venta : " + productoVendido.IdVenta.ToString());
}

Console.WriteLine("------Ventas-------");

List<Venta> listaVentas = Venta.ListarVenta();

foreach (Venta venta in listaVentas)
{
    Console.WriteLine("ID : " + venta.Id.ToString());
    Console.WriteLine("Comentarios : " + venta.Comentarios.ToString());
    Console.WriteLine("ID Usuario : " + venta.IdUsuario.ToString());
}

if(Usuario.IniciarSesion(nombreUsuario, contrasena) == null)
{
    Console.WriteLine("Inicio de sesion fallido");
}else
{
    Console.WriteLine("Inicio de sesion exitoso");
}