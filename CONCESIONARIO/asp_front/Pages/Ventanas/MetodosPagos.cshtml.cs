
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class MetodosPagosModel : PageModel
    {
        private IMetodosPagosPresentacion IMetodosPagosPresentacion;

        public MetodosPagosModel(IMetodosPagosPresentacion IMetodosPagosPresentacion)
        {
            this.IMetodosPagosPresentacion = IMetodosPagosPresentacion;
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

                Lista = IMetodosPagosPresentacion.Buscar(Filtro);

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
            Lista = IMetodosPagosPresentacion.Consultar();
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    IMetodosPagosPresentacion.Insertar(Actual);
                else
                    IMetodosPagosPresentacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true;
                Lista = IMetodosPagosPresentacion.Consultar();
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IMetodosPagosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Formulario = true;
                Borrar = false;
                Lista = IMetodosPagosPresentacion.Consultar();
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
                Actual = IMetodosPagosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Borrar = true;
                Formulario = false;
                Lista = IMetodosPagosPresentacion.Consultar();
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
                IMetodosPagosPresentacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
