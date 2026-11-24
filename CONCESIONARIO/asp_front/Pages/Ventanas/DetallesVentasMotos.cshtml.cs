
using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class DetallesVentasMotosModel : PageModel
    {
        private IDetallesVentasMotosPresentacion IDetallesVentasMotosPresentacion;

        public DetallesVentasMotosModel(IDetallesVentasMotosPresentacion IDetallesVentasMotosPresentacion)
        {
            this.IDetallesVentasMotosPresentacion = IDetallesVentasMotosPresentacion;
        }

        [BindProperty] public List<DetallesVentasMotos> Lista { get; set; } = new();
        [BindProperty] public DetallesVentasMotos? Filtro { get; set; }
        [BindProperty] public DetallesVentasMotos? Actual { get; set; }
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
                Filtro ??= new DetallesVentasMotos();
                Lista = IDetallesVentasMotosPresentacion.Buscar(Filtro);

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
            Actual = new DetallesVentasMotos();
            Formulario = true;
            Borrar = false;
            Lista = IDetallesVentasMotosPresentacion.Consultar();
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    IDetallesVentasMotosPresentacion.Insertar(Actual);
                else
                    IDetallesVentasMotosPresentacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true;
                Lista = IDetallesVentasMotosPresentacion.Consultar();
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IDetallesVentasMotosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Formulario = true;
                Borrar = false;
                Lista = IDetallesVentasMotosPresentacion.Consultar();
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
                Actual = IDetallesVentasMotosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Borrar = true;
                Formulario = false;
                Lista = IDetallesVentasMotosPresentacion.Consultar();
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
                IDetallesVentasMotosPresentacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
