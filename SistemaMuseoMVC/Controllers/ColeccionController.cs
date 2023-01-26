using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMuseoMVC.Controllers
{
    public class ColeccionController : Controller
    {
        // GET: Coleccion
        public ActionResult listado()
        {
            DALColeccion oColeccion = new DALColeccion();
            ModelState.Clear();

            return View(oColeccion.listarColeccion());
        }

        public ActionResult listadoInactivo()
        {
            DALColeccion oColeccion = new DALColeccion();
            ModelState.Clear();

            return View(oColeccion.listarInactivo());
        }

        public ActionResult insertarColeccion(EntidadColeccion coleccion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DALColeccion oColeccion = new DALColeccion();

                    if (oColeccion.insertarColeccion(coleccion))
                    {
                        ViewBag.Mensaje = "Coleccion ingresado con éxto";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error en el ingreso de Coleccion";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ex = null;
            }
            return View();

        }

        //uso protocolo GET clientes/modificarColeccion/5
        public ActionResult modificarColeccion(int coleccion_id)
        {
            DALColeccion oColeccion = new DALColeccion();

            return View(oColeccion.listarColeccion().Find(est => est.Coleccion_id == coleccion_id));
        }

        [HttpPost]
        public ActionResult modificarColeccion(int coleccion_id, EntidadColeccion coleccion)
        {
            DALColeccion oColeccion = new DALColeccion();

            oColeccion.modificarColeccion(coleccion);

            return RedirectToAction("listado");

        }

        public ActionResult eliminarColeccion(int coleccion_id)
        {
            try
            {
                DALColeccion oColeccion = new DALColeccion();

                if (oColeccion.eliminarColeccion(coleccion_id))
                {
                    ViewBag.Mensaje = "Coleccion eliminado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al eliminar la Coleccion";
                }

                return RedirectToAction("listado");

            }
            catch
            {
                return View();
            }

        }

        public ActionResult activarColeccion(int coleccion_id)
        {
            try
            {
                DALColeccion oColeccion = new DALColeccion();

                if (oColeccion.activarColeccion(coleccion_id))
                {
                    ViewBag.Mensaje = "Coleccion activado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al activar el Coleccion";
                }

                return RedirectToAction("listado");

            }
            catch
            {
                return View();
            }

        }
    }
}