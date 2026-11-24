
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Modulos
{
    public class RepuestosModel : PageModel
    {
        private IRepuestosPresentacion IRepuestosPresentacion;
        private IProductosPresentacion IProductosPresentacion;

        public RepuestosModel(
            IRepuestosPresentacion IRepuestosPresentacion,
            IProductosPresentacion IProductosPresentacion)
        {
            this.IRepuestosPresentacion = IRepuestosPresentacion;
            this.IProductosPresentacion = IProductosPresentacion;
            this.Filtro = new Repuestos();
            this.ListaProductos = new List<Productos>();
        }

        [BindProperty] public List<Repuestos> Lista { get; set; }
        [BindProperty] public List<Productos> ListaProductos { get; set; }
        [BindProperty] public Repuestos? Filtro { get; set; }
        [BindProperty] public Repuestos? Actual { get; set; }
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
                Filtro!.Numero_Parte = Filtro.Numero_Parte ?? "";
                Filtro.Descripcion = Filtro.Descripcion ?? "";

                Lista = this.IRepuestosPresentacion.Buscar(Filtro!);
                ListaProductos = this.IProductosPresentacion.Consultar();
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
                Actual = new Repuestos();
                Actual.Fecha_Modificacion = DateTime.Now;
                ListaProductos = this.IProductosPresentacion.Consultar();
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
                    Actual = IRepuestosPresentacion.Insertar(Actual!);
                else
                    Actual = IRepuestosPresentacion.Actualizar(Actual!);
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

                Actual = IRepuestosPresentacion.Borrar(Actual!);
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
