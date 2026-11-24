
using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class PagosModel : PageModel
    {
        private IPagosPresentacion IPagosPresentacion;

        public PagosModel(IPagosPresentacion IPagosPresentacion)
        {
            this.IPagosPresentacion = IPagosPresentacion;
        }

        [BindProperty] public List<Pagos> Lista { get; set; } = new();
        [BindProperty] public Pagos? Filtro { get; set; }
        [BindProperty] public Pagos? Actual { get; set; }
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
                Filtro ??= new Pagos();

                Lista = IPagosPresentacion.Buscar(Filtro);

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
            Actual = new Pagos();
            Formulario = true;
            Borrar = false;
            Lista = IPagosPresentacion.Consultar();
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    IPagosPresentacion.Insertar(Actual);
                else
                    IPagosPresentacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true;
                Lista = IPagosPresentacion.Consultar();
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IPagosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Formulario = true;
                Borrar = false;
                Lista = IPagosPresentacion.Consultar();
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
                Actual = IPagosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Borrar = true;
                Formulario = false;
                Lista = IPagosPresentacion.Consultar();
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
                IPagosPresentacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
