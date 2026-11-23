
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Modulos
{
    public class InventariosModel : PageModel
    {
        private IInventariosNegocio IInventariosAplicacion;
        private IMotosNegocio IMotosAplicacion;

        public InventariosModel(
            IInventariosNegocio IInventariosAplicacion,
            IMotosNegocio IMotosAplicacion)
        {
            this.IInventariosAplicacion = IInventariosAplicacion;
            this.IMotosAplicacion = IMotosAplicacion;
            this.Filtro = new Inventarios();
            this.ListaMotos = new List<Motos>();
        }

        [BindProperty] public List<Inventarios> Lista { get; set; }
        [BindProperty] public List<Motos> ListaMotos { get; set; }
        [BindProperty] public Inventarios? Filtro { get; set; }
        [BindProperty] public Inventarios? Actual { get; set; }
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
                Filtro!.Ubicacion = Filtro.Ubicacion ?? "";

                Lista = this.IInventariosAplicacion.Buscar(Filtro!);
                ListaMotos = this.IMotosAplicacion.Consultar();
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
                Formulario = true;
                Actual = new Inventarios
                {
                    Fecha_Ingreso = DateTime.Today
                };

                ListaMotos = this.IMotosAplicacion.Consultar();
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
                    Actual = IInventariosAplicacion.Insertar(Actual!);
                else
                    Actual = IInventariosAplicacion.Actualizar(Actual!);
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
                Formulario = true;
                OnPostBtConsultar();

                Actual = Lista.FirstOrDefault(
                    x => x.ID == Convert.ToInt32(data));
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
                Borrar = true;
                OnPostBtConsultar();

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

                Actual = IInventariosAplicacion.Borrar(Actual!);
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
