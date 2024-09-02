using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiciosMC.Controllers
{
    [Authorize(Policy = "USUARIO_ADMIN")]
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
