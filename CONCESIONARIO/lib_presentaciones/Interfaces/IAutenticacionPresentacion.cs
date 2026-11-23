using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAutenticacionPresentacion
    {
        Task<SesionUsuario> IniciarSesion(
            CredencialesUsuario credenciales
        );
    }
}