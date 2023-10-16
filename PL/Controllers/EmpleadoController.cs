using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View( new ML.Empleado());
        }
    }
}