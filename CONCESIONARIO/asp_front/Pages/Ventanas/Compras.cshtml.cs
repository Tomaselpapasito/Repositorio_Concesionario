
using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class ComprasModel : PageModel
    {
        private IComprasPresentacion IComprasPresentacion;
        private IProveedoresPresentacion IProveedoresPresentacion;

        public ComprasModel(
            IComprasPresentacion IComprasPresentacion,
            IProveedoresPresentacion IProveedoresPresentacion)
        {
            this.IComprasPresentacion = IComprasPresentacion;
            this.IProveedoresPresentacion = IProveedoresPresentacion;
        }

        [BindProperty] public List<Compras> Lista { get; set; } = new();
        [BindProperty] public List<Proveedores> ListaProveedores { get; set; } = new();
        [BindProperty] public Compras? Filtro { get; set; }
        [BindProperty] public Compras? Actual { get; set; }
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
                Filtro ??= new Compras();
                Filtro.Numero_Factura ??= "";

                Lista = IComprasPresentacion.Buscar(Filtro);
                ListaProveedores = IProveedoresPresentacion.Consultar();

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
            Actual = new Compras();
            Formulario = true;
            Borrar = false;
            Lista = IComprasPresentacion.Consultar();
            ListaProveedores = IProveedoresPresentacion.Consultar();
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    IComprasPresentacion.Insertar(Actual);
                else
                    IComprasPresentacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true;
                Lista = IComprasPresentacion.Consultar();
                ListaProveedores = IProveedoresPresentacion.Consultar();
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IComprasPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Formulario = true;
                Borrar = false;
                Lista = IComprasPresentacion.Consultar();
                ListaProveedores = IProveedoresPresentacion.Consultar();
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
                Actual = IComprasPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Borrar = true;
                Formulario = false;
                Lista = IComprasPresentacion.Consultar();
                ListaProveedores = IProveedoresPresentacion.Consultar();
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
                IComprasPresentacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
