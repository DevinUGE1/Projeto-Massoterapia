using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Massoterapia.Areas.Admin.Controllers
{

    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QuemSomos ()
        {
            return View();
        }

        public IActionResult Oquee()
        {
            return View();
        }
    }
}
