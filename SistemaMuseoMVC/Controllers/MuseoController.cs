using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMuseoMVC.Controllers
{
    public class MuseoController : Controller
    {
        // GET: Museo
        public ActionResult listado()
        {
            DALMuseo oMuseo = new DALMuseo();
            ModelState.Clear();

            return View(oMuseo.listarMuseo());
        }

       

        public ActionResult listadoInactivo()
        {
            DALMuseo oMuseo = new DALMuseo();
            ModelState.Clear();

            return View(oMuseo.listarInactivo());
        }

        public ActionResult insertarMuseo(EntidadMuseo museo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DALMuseo oMuseo = new DALMuseo();

                    if (oMuseo.insertarMuseo(museo))
                    {
                        ViewBag.Mensaje = "Museo ingresado con éxto";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error en el ingreso del MUseo";
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

        //uso protocolo GET clientes/modificarMuseo/5
        public ActionResult modificarMuseo(int museo_id)
        {
            DALMuseo oMuseo = new DALMuseo();

            return View(oMuseo.listarMuseo().Find(est => est.Museo_id == museo_id));
        }

        [HttpPost]
        public ActionResult modificarMuseo(int museo_id, EntidadMuseo museo)
        {
            DALMuseo oMuseo = new DALMuseo();

            oMuseo.modificarMuseo(museo);

            return RedirectToAction("listado");

        }

        public ActionResult eliminarMuseo(int museo_id)
        {
            try
            {
                DALMuseo oMuseo = new DALMuseo();

                if (oMuseo.eliminarMuseo(museo_id))
                {
                    ViewBag.Mensaje = "Museo eliminado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al eliminar el Museo";
                }

                return RedirectToAction("listado");

            }
            catch
            {
                return View();
            }

        }

        public ActionResult activarMuseo(int museo_id)
        {
            try
            {
                DALMuseo oMuseo = new DALMuseo();

                if (oMuseo.activarMuseo(museo_id))
                {
                    ViewBag.Mensaje = "Museo activado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al activar el Museo";
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