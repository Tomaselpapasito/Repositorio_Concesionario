using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using System.ComponentModel;

Console.WriteLine("presentacion_csn");

try
{
    IConexion iconexion = new Conexion();
    iconexion.StringConexion = DatosGenerales.ObtenerStringConexion();
    var lista = iconexion.Personas!.ToList();
    foreach (var elemento in lista) 
    {
        Console.WriteLine(elemento.Nombre + " El mas makina");
    }
}
catch(Exception ex)
{
    Console.WriteLine( "No se conecta ;( ");
    Console.WriteLine(ex.ToString());

}