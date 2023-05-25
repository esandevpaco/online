using CapaEntidades.PEU;
using CapaNegocio.PEU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class HomeController : Controller
    {
        private N_PEU_Persons _Persons = new N_PEU_Persons();
       
        public async Task<ActionResult> Index()
        {

            var lista = await _Persons.N_listEmpleados();
            ViewData["lista"] = lista;

            return View();
        }

        public JsonResult Estudiantes()
        {

            var lista = _Persons.N_listEmpleados();
            

            return Json(lista,JsonRequestBehavior.AllowGet);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}