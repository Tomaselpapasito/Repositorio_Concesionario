
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class EmpleadosModel : PageModel
    {
        private IEmpleadosPresentacion IEmpleadosPresentacion;
        private IPersonasPresentacion IPersonasPresentacion;
        private ICargosPresentacion ICargosPresentacion;

        public EmpleadosModel(
            IEmpleadosPresentacion IEmpleadosPresentacion,
            IPersonasPresentacion IPersonasPresentacion,
            ICargosPresentacion ICargosPresentacion)
        {
            this.IEmpleadosPresentacion = IEmpleadosPresentacion;
            this.IPersonasPresentacion = IPersonasPresentacion;
            this.ICargosPresentacion = ICargosPresentacion;

            this.Filtro = new Empleados();
        }

        [BindProperty] public List<Empleados> Lista { get; set; }
        [BindProperty] public List<Personas> PersonasLista { get; set; }
        [BindProperty] public List<Cargos> CargosLista { get; set; }
        [BindProperty] public Empleados? Filtro { get; set; }
        [BindProperty] public Empleados? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet()
        {
            OnPostBtConsultar();
        }

        private void CargarSelectores()
        {
            PersonasLista = IPersonasPresentacion.Consultar();
            CargosLista = ICargosPresentacion.Consultar();
        }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new Empleados();

                Filtro.Carnet ??= "";

                Lista = IEmpleadosPresentacion.Buscar(Filtro);
                PersonasLista = IPersonasPresentacion.Consultar();
                CargosLista = ICargosPresentacion.Consultar();
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
                CargarSelectores();
                Formulario = true;
                Actual = new Empleados();
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
                    Actual = IEmpleadosPresentacion.Insertar(Actual!);
                else
                    Actual = IEmpleadosPresentacion.Actualizar(Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                OnPostBtConsultar();
                Formulario = true;

                Actual = Lista.FirstOrDefault(
                    x => x.ID == Convert.ToInt32(data));

                CargarSelectores();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                OnPostBtConsultar();
                Borrar = true;

                Actual = Lista.FirstOrDefault(
                    x => x.ID == Convert.ToInt32(data));
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
                if (Actual!.ID == 0)
                    return;

                Actual = IEmpleadosPresentacion.Borrar(Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}
