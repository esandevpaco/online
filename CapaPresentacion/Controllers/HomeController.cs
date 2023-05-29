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
            ViewBag.dato = lista;

            return View();
        }


         [HttpPost]
        public async Task<JsonResult> Insert(string nombre)
        {
            bool result = await _Persons.N_InsertarEmpleados(nombre);

            return Json(result);
          
        }


    }
}