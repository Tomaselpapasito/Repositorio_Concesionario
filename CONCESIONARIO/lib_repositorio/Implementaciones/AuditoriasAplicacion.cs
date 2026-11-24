using lib_repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using lib_dominio.Interfaces;
namespace lib_repositorio.Implementaciones
{
    public class AuditoriasAplicacion : IAuditorias
    {


        public T CrearAuditoria<T>(int objeto, string accion, string Detalles, int usuario) where T: IAuditoria, new()
        {
            return new T
            {
                ID = 0,
                Objeto = objeto,
                Fecha = DateTime.Now,
                Accion = accion,
                Detalles = Detalles,
                Usuario = usuario
            };
        }
    }
}
