
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class MetodosPagosModel : PageModel
    {
        private IMetodosPagosNegocio IMetodosPagosAplicacion;

        public MetodosPagosModel(IMetodosPagosNegocio IMetodosPagosAplicacion)
        {
            this.IMetodosPagosAplicacion = IMetodosPagosAplicacion;
        }

        [BindProperty] public List<MetodosPagos> Lista { get; set; } = new();
        [BindProperty] public MetodosPagos? Filtro { get; set; }
        [BindProperty] public MetodosPagos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet()
        {
            OnPostBtConsultar();
        }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new MetodosPagos();
                Filtro.Nombre ??= "";
                Filtro.Tipo ??= "";

                Lista = IMetodosPagosAplicacion.Buscar(Filtro);

                Formulario = false;
                Borrar = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            Actual = new MetodosPagos();
            Formulario = true;
            Borrar = false;
            Lista = IMetodosPagosAplicacion.Consultar();
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    IMetodosPagosAplicacion.Insertar(Actual);
                else
                    IMetodosPagosAplicacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true;
                Lista = IMetodosPagosAplicacion.Consultar();
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IMetodosPagosAplicacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Formulario = true;
                Borrar = false;
                Lista = IMetodosPagosAplicacion.Consultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(int data)
        {
            try
            {
                Actual = IMetodosPagosAplicacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Borrar = true;
                Formulario = false;
                Lista = IMetodosPagosAplicacion.Consultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                IMetodosPagosAplicacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
