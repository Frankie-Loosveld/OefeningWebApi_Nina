using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OefeningWebApi.Controllers
{
    public class GetalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
