
using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class CuotasModel : PageModel
    {
        private ICuotasPresentacion ICuotasPresentacion;
        private IFinanciamientosPresentacion IFinanciamientosPresentacion;

        public CuotasModel(
            ICuotasPresentacion ICuotasPresentacion,
            IFinanciamientosPresentacion IFinanciamientosPresentacion)
        {
            this.ICuotasPresentacion = ICuotasPresentacion;
            this.IFinanciamientosPresentacion = IFinanciamientosPresentacion;
        }

        [BindProperty] public List<Cuotas> Lista { get; set; } = new();
        [BindProperty] public Cuotas? Filtro { get; set; }
        [BindProperty] public Cuotas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public List<Financiamientos> ListaFinanciamientos { get; set; } = new();

        public void OnGet()
        {
            OnPostBtConsultar();
        }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new Cuotas();

                Lista = ICuotasPresentacion.Buscar(Filtro);
                ListaFinanciamientos = IFinanciamientosPresentacion.Consultar();

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
            try
            {
                Actual = new Cuotas();
                ListaFinanciamientos = IFinanciamientosPresentacion.Consultar();
                Formulario = true;
                Borrar = false;
                Lista = ICuotasPresentacion.Consultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    ICuotasPresentacion.Insertar(Actual);
                else
                    ICuotasPresentacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                ListaFinanciamientos = IFinanciamientosPresentacion.Consultar();
                Formulario = true;
                Lista = ICuotasPresentacion.Consultar();
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = ICuotasPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                ListaFinanciamientos = IFinanciamientosPresentacion.Consultar();
                Formulario = true;
                Borrar = false;
                Lista = ICuotasPresentacion.Consultar();
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
                Actual = ICuotasPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                ListaFinanciamientos = IFinanciamientosPresentacion.Consultar();
                Borrar = true;
                Formulario = false;
                Lista = ICuotasPresentacion.Consultar();
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
                ICuotasPresentacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
