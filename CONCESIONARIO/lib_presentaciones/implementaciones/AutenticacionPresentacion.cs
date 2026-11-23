using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class AutenticacionPresentacion : IAutenticacionPresentacion
    {
        private IComunicaciones IComunicaciones;

        public AutenticacionPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<SesionUsuario> IniciarSesion(
            CredencialesUsuario credenciales)
        {
            return await this.IComunicaciones.Ejecutar<SesionUsuario>(
                "Autenticacion/IniciarSesion",
                credenciales
            );
        }
    }
}