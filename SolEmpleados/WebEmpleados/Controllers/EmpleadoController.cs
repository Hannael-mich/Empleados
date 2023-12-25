using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEmpleados.Datos;
using WebEmpleados.Models;

namespace WebEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            //obtengo el modelo de la vista que es una lista de empleados
            List<E_Empleado> lista = new List<E_Empleado>();
            try
            {
                D_Empleado datos = new D_Empleado();
                lista = datos.ObtenerTodos();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message; 
            }
            return View("Consulta", lista);
        }

        public ActionResult IrAgregar() 
        {
            return View("Agregar");
        }

        public ActionResult Agregar(E_Empleado empleado)
        {
            try
            {
                D_Empleado datos = new D_Empleado();

                bool existe = datos.ExisteNumeroEmpleado(empleado.NumeroEmpleado);
                if (existe == true)
                {
                    TempData["error"] = $"El numero de empleado {empleado.NumeroEmpleado} ya existe en la base de datos";
                }
                else 
                {
                    datos.Agregar(empleado);
                    TempData["mensaje"] = $"El empleado {empleado.IdEmpleado} fue agregado correctamente";
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Eliminar (int idEmpleado)
        {
            try
            {
                D_Empleado datos = new D_Empleado();
                datos.Eliminar(idEmpleado);
                TempData["mensaje"] = $"Se elimino correctamente el empleado con id {idEmpleado}";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult ObtenerParaEditar(int idEmpleado)
        {
            try
            {
                D_Empleado datos = new D_Empleado();

                E_Empleado empleado = datos.obtenerEmpleadoPorId(idEmpleado);
                return View("Editar", empleado);
            }
            catch (Exception ex )
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Editar(E_Empleado empleado)
        {
            try
            {
                D_Empleado datos = new D_Empleado();
                datos.Editar(empleado);
                TempData["mensaje"] = $"Se edito correctamente el empleado con el id {empleado.IdEmpleado}";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                
            }
            return RedirectToAction("Index");
        }

        public ActionResult Buscar (string texto)
        {
            try
            {
                D_Empleado datos = new D_Empleado();
                List<E_Empleado> lista = datos.Buscar(texto);
                return View("Consulta", lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}