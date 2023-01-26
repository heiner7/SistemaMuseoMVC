using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMuseoMVC.Controllers
{
    public class TipoMuseoController : Controller
    {
        // GET: TipoMuseo
        public ActionResult listado()
        {
            DALTipoMuseo oTipoMuseo = new DALTipoMuseo();
            ModelState.Clear();

            return View(oTipoMuseo.listarTipoMuseo());
        }

        public ActionResult listadoInactivo()
        {
            DALTipoMuseo oTipoMuseo = new DALTipoMuseo();
            ModelState.Clear();

            return View(oTipoMuseo.listarInactivo());
        }

        public ActionResult insertarTipoMuseo(EntidadTipoMuseo tipoMuseo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DALTipoMuseo oTipoMuseo = new DALTipoMuseo();

                    if (oTipoMuseo.insertarTipoMuseo(tipoMuseo))
                    {
                        ViewBag.Mensaje = "TipoMuseo ingresado con éxto";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error en el ingreso del TipoMuseo";
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

        //uso protocolo GET clientes/modificarTipoMuseo/5
        public ActionResult modificarTipoMuseo(int tipoMuseo_id)
        {
            DALTipoMuseo oTipoMuseo = new DALTipoMuseo();

            return View(oTipoMuseo.listarTipoMuseo().Find(est => est.TipoMuseo_id == tipoMuseo_id));
        }

        [HttpPost]
        public ActionResult modificarTipoMuseo(int tipoMuseo_id, EntidadTipoMuseo tipoMuseo)
        {
            DALTipoMuseo oTipoMuseo = new DALTipoMuseo();

            oTipoMuseo.modificarTipoMuseo(tipoMuseo);

            return RedirectToAction("listado");

        }

        public ActionResult eliminarTipoMuseo(int tipoMuseo_id)
        {
            try
            {
                DALTipoMuseo oTipoMuseo = new DALTipoMuseo();

                if (oTipoMuseo.eliminarTipoMuseo(tipoMuseo_id))
                {
                    ViewBag.Mensaje = "TipoMuseo eliminado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al eliminar el TipoMuseo";
                }

                return RedirectToAction("listado");

            }
            catch
            {
                return View();
            }

        }

        public ActionResult activarTipoMuseo(int tipoMuseo_id)
        {
            try
            {
                DALTipoMuseo oTipoMuseo = new DALTipoMuseo();

                if (oTipoMuseo.activarTipoMuseo(tipoMuseo_id))
                {
                    ViewBag.Mensaje = "TipoMuseo activado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al activado el TipoMuseo";
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