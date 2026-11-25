
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class FinanciamientosModel : PageModel
    {
        private IFinanciamientosPresentacion IFinanciamientosPresentacion;
        private IVentasPresentacion IVentasPresentacion;

        public FinanciamientosModel(
            IFinanciamientosPresentacion IFinanciamientosPresentacion,
            IVentasPresentacion IVentasPresentacion)
        {
            this.IFinanciamientosPresentacion = IFinanciamientosPresentacion;
            this.IVentasPresentacion = IVentasPresentacion;
        }

        [BindProperty] public List<Financiamientos> Lista { get; set; } = new();
        [BindProperty] public Financiamientos? Filtro { get; set; }
        [BindProperty] public Financiamientos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public List<Ventas> ListaVentas { get; set; } = new();

        public void OnGet()
        {
            OnPostBtConsultar();
        }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new Financiamientos();
                Filtro.Estado ??= "";

                Lista = IFinanciamientosPresentacion.Buscar(Filtro);
                ListaVentas = IVentasPresentacion.Consultar();

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
            Actual = new Financiamientos();
            ListaVentas = IVentasPresentacion.Consultar();
            Formulario = true;
            Borrar = false;
            Lista = IFinanciamientosPresentacion.Consultar();
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    IFinanciamientosPresentacion.Insertar(Actual);
                else
                    IFinanciamientosPresentacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                ListaVentas = IVentasPresentacion.Consultar();
                Formulario = true;
                Lista = IFinanciamientosPresentacion.Consultar();
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IFinanciamientosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                ListaVentas = IVentasPresentacion.Consultar();
                Formulario = true;
                Borrar = false;
                Lista = IFinanciamientosPresentacion.Consultar();
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
                Actual = IFinanciamientosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                ListaVentas = IVentasPresentacion.Consultar();
                Borrar = true;
                Formulario = false;
                Lista = IFinanciamientosPresentacion.Consultar();
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
                IFinanciamientosPresentacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
