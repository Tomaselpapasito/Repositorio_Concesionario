using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using lib_dominio.Entidades;
namespace lib_dominio.Interfaces
{
    public interface IAuditorias
    {

        public T CrearAuditoria<T>(int tabla, string accion, string detalles, int usuario
    ) where T : IAuditoria, new();
    
    }
}