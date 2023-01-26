using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMuseoMVC.Controllers
{
    public class ArtistaController : Controller
    {

        // GET: Artista
        public ActionResult listado()
        {
            DALArtista oArtista = new DALArtista();
            ModelState.Clear();

            return View(oArtista.listarArtista());
        }

        public ActionResult listadoInactivo()
        {
            DALArtista oArtista = new DALArtista();
            ModelState.Clear();

            return View(oArtista.listarInactivo());
        }

        public ActionResult insertarArtista(EntidadArtista Artista)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DALArtista oArtista = new DALArtista();

                    if (oArtista.insertarArtista(Artista))
                    {
                        ViewBag.Mensaje = "Artista ingresado con éxto";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error en el ingreso del Artista";
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
        public ActionResult modificarArtista(int artista_id)
        {
            DALArtista oArtista = new DALArtista();

            return View(oArtista.listarArtista().Find(est => est.Artista_id == artista_id));
        }

        [HttpPost]
        public ActionResult modificarArtista(int artista_id, EntidadArtista artista)
        {
            DALArtista oArtista = new DALArtista();

            oArtista.modificarArtista(artista);

            return RedirectToAction("listado");

        }

        public ActionResult eliminarArtista(int artista_id)
        {
            try
            {
                DALArtista oArtista = new DALArtista();

                if (oArtista.eliminarArtista(artista_id))
                {
                    ViewBag.Mensaje = "Artista eliminado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al eliminar el Artista";
                }

                return RedirectToAction("listado");

            }
            catch
            {
                return View();
            }

        }

        public ActionResult activarArtista(int artista_id)
        {
            try
            {
                DALArtista oArtista = new DALArtista();

                if (oArtista.activarArtista(artista_id))
                {
                    ViewBag.Mensaje = "Artista activado";
                }
                else
                {
                    ViewBag.Mensaje = "Hubo problemas al activar el Artista";
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