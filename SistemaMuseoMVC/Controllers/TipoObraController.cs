using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMuseoMVC.Controllers
{
    public class TipoObraController : Controller
    {
        // GET: TipoObra
        public ActionResult listado()
        {
            DALTipoObra oTipoObra = new DALTipoObra();
            ModelState.Clear();

            return View(oTipoObra.listarTipoObra());
        }

        public ActionResult listadoInactivo()
        {
            DALTipoObra oTipoObra = new DALTipoObra();
            ModelState.Clear();

            return View(oTipoObra.listarInactivado());
        }

        public ActionResult insertarTipoObra(EntidadTipoObra tipoObra)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DALTipoObra oTipoObra = new DALTipoObra();

                    if (oTipoObra.insertarTipoObra(tipoObra))
                    {
                        ViewBag.Mensaje = "TipoObra ingresado con éxto";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error en el ingreso del TipoObra";
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

        //uso protocolo GET clientes/modificarTipoObra/5
        public ActionResult modificarTipoObra(int tipoObra_id)
        {
            DALTipoObra oTipoObra = new DALTipoObra();

            return View(oTipoObra.listarTipoObra().Find(est => est.TipoObra_id == tipoObra_id));
        }

        [HttpPost]
        public ActionResult modificarTipoObra(int tipoObra_id, EntidadTipoObra tipoObra)
        {
            DALTipoObra oTipoObra = new DALTipoObra();

            oTipoObra.modificarTipoObra(tipoObra);

            return RedirectToAction("listado");

        }

        public ActionResult eliminarTipoObra(int tipoObra_id)
        {
            try
            {
                DALTipoObra oTipoObra = new DALTipoObra();

                if (oTipoObra.eliminarTipoObra(tipoObra_id))
                {
                    ViewBag.Mensaje = "TipoObra eliminado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al eliminar el TipoObra";
                }

                return RedirectToAction("listado");

            }
            catch
            {
                return View();
            }

        }
        public ActionResult activarTipoObra(int tipoObra_id)
        {
            try
            {
                DALTipoObra oTipoObra = new DALTipoObra();

                if (oTipoObra.activarTipoObra(tipoObra_id))
                {
                    ViewBag.Mensaje = "TipoObra activado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al activar el TipoObra";
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