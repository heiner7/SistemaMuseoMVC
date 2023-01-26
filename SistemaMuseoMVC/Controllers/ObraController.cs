using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMuseoMVC.Controllers
{
    public class ObraController : Controller
    {
        // GET: Obra
        public ActionResult listado()
        {
            DALObra oObra = new DALObra();
            ModelState.Clear();

            return View(oObra.listarObra());
        }

        public ActionResult listadoInactivo()
        {
            DALObra oObra = new DALObra();
            ModelState.Clear();

            return View(oObra.listarInactivo());
        }

        public ActionResult insertarObra(EntidadObra obra)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DALObra oObra = new DALObra();

                    if (oObra.insertarObra(obra))
                    {
                        ViewBag.Mensaje = "Obra ingresado con éxto";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error en el ingreso del Obra";
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

        //uso protocolo GET clientes/modificarObra/5
        public ActionResult modificarObra(int obra_id)
        {
            DALObra oObra = new DALObra();

            return View(oObra.listarObra().Find(est => est.Obra_id == obra_id));
        }

        [HttpPost]
        public ActionResult modificarObra(int obra_id, EntidadObra obra)
        {
            DALObra oObra = new DALObra();

            oObra.modificarObra(obra);

            return RedirectToAction("listado");

        }

        public ActionResult eliminarObra(int obra_id)
        {
            try
            {
                DALObra oObra = new DALObra();

                if (oObra.eliminarObra(obra_id))
                {
                    ViewBag.Mensaje = "Obra eliminado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al eliminar la Obra";
                }

                return RedirectToAction("listado");

            }
            catch
            {
                return View();
            }

        }

        public ActionResult activarObra(int obra_id)
        {
            try
            {
                DALObra oObra = new DALObra();

                if (oObra.activarObra(obra_id))
                {
                    ViewBag.Mensaje = "Obra activado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al activar el Obra";
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