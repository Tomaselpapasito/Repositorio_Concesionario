
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class EmpleadosModel : PageModel
    {
        private IEmpleadosNegocio IEmpleadosAplicacion;
        private IPersonasNegocio IPersonasAplicacion;
        private ICargosNegocio ICargosAplicacion;

        public EmpleadosModel(
            IEmpleadosNegocio IEmpleadosAplicacion,
            IPersonasNegocio IPersonasAplicacion,
            ICargosNegocio ICargosAplicacion)
        {
            this.IEmpleadosAplicacion = IEmpleadosAplicacion;
            this.IPersonasAplicacion = IPersonasAplicacion;
            this.ICargosAplicacion = ICargosAplicacion;

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
            PersonasLista = IPersonasAplicacion.Consultar();
            CargosLista = ICargosAplicacion.Consultar();
        }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Carnet = Filtro.Carnet ?? "";

                Lista = IEmpleadosAplicacion.Buscar(Filtro!);
                CargarSelectores();
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
                    Actual = IEmpleadosAplicacion.Insertar(Actual!);
                else
                    Actual = IEmpleadosAplicacion.Actualizar(Actual!);
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

                Actual = IEmpleadosAplicacion.Borrar(Actual!);
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
