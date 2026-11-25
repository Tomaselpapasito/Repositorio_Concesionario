
using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class VentasModel : PageModel
    {
        private IVentasPresentacion IVentasPresentacion;
        private IClientesPresentacion IClientesPresentacion;
        private IEmpleadosPresentacion IEmpleadosPresentacion;
        private IPersonasPresentacion IPersonasPresentacion;

        public VentasModel(
            IVentasPresentacion IVentasPresentacion,
            IClientesPresentacion IClientesPresentacion,
            IEmpleadosPresentacion IEmpleadosPresentacion,
            IPersonasPresentacion IPersonasPresentacion)
        {
            this.IVentasPresentacion = IVentasPresentacion;
            this.IClientesPresentacion = IClientesPresentacion;
            this.IEmpleadosPresentacion = IEmpleadosPresentacion;
            this.IPersonasPresentacion = IPersonasPresentacion;
        }

        [BindProperty] public List<Ventas> Lista { get; set; } = new();
        [BindProperty] public List<Clientes> ListaClientes { get; set; } = new();
        [BindProperty] public List<Empleados> ListaEmpleados { get; set; } = new();
        [BindProperty] public List<Personas> ListaPersonas { get; set; } = new();
        [BindProperty] public Ventas? Filtro { get; set; }
        [BindProperty] public Ventas? Actual { get; set; }
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
                Filtro ??= new Ventas();
                Lista = IVentasPresentacion.Buscar(Filtro);

                ListaClientes = IClientesPresentacion.Consultar();
                ListaEmpleados = IEmpleadosPresentacion.Consultar();
                ListaPersonas = IPersonasPresentacion.Consultar();

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
            Actual = new Ventas();
            Formulario = true;
            Borrar = false;
            Lista = IVentasPresentacion.Consultar();

            ListaClientes = IClientesPresentacion.Consultar();
            ListaEmpleados = IEmpleadosPresentacion.Consultar();
            ListaPersonas = IPersonasPresentacion.Consultar();
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    IVentasPresentacion.Insertar(Actual);
                else
                    IVentasPresentacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true;
                Lista = IVentasPresentacion.Consultar();

                ListaClientes = IClientesPresentacion.Consultar();
                ListaEmpleados = IEmpleadosPresentacion.Consultar();
                ListaPersonas = IPersonasPresentacion.Consultar();
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IVentasPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Formulario = true;
                Borrar = false;
                Lista = IVentasPresentacion.Consultar();

                ListaClientes = IClientesPresentacion.Consultar();
                ListaEmpleados = IEmpleadosPresentacion.Consultar();
                ListaPersonas = IPersonasPresentacion.Consultar();
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
                Actual = IVentasPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Borrar = true;
                Formulario = false;
                Lista = IVentasPresentacion.Consultar();

                ListaClientes = IClientesPresentacion.Consultar();
                ListaEmpleados = IEmpleadosPresentacion.Consultar();
                ListaPersonas = IPersonasPresentacion.Consultar();
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
                IVentasPresentacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
