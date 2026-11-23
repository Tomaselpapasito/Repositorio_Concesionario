
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Modulos
{
    public class ModelosMotosModel : PageModel
    {
        private IModelosMotosNegocio IModelosMotosAplicacion;

        public ModelosMotosModel(IModelosMotosNegocio IModelosMotosAplicacion)
        {
            this.IModelosMotosAplicacion = IModelosMotosAplicacion;
            this.Filtro = new ModelosMotos();
        }

        [BindProperty] public List<ModelosMotos> Lista { get; set; }
        [BindProperty] public ModelosMotos? Filtro { get; set; }
        [BindProperty] public ModelosMotos? Actual { get; set; }
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
                Filtro!.Nombre = Filtro.Nombre ?? "";
                Filtro.Tipo_motor = Filtro.Tipo_motor ?? "";
                Filtro.Transmision = Filtro.Transmision ?? "";

                Lista = this.IModelosMotosAplicacion.Buscar(Filtro!);
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
                Actual = new ModelosMotos();
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
                    Actual = IModelosMotosAplicacion.Insertar(Actual!);
                else
                    Actual = IModelosMotosAplicacion.Actualizar(Actual!);
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

                Actual = IModelosMotosAplicacion.Borrar(Actual!);
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
