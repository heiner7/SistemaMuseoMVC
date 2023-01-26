using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMuseoMVC.Controllers
{
    public class EntradaController : Controller
    {
        // GET: Entrada
        public ActionResult listado()
        {
            DALEntrada oEntrada = new DALEntrada();
            ModelState.Clear();

            return View(oEntrada.listarEntrada());
        }

        public ActionResult insertarEntrada(EntidadEntrada entrada)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DALEntrada oEntrada = new DALEntrada();

                    if (oEntrada.insertarEntrada(entrada))
                    {
                        ViewBag.Mensaje = "Entrada ingresado con éxto";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error en el ingreso del Entrada";
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
    }
}