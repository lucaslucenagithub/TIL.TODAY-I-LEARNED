using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Usuario.Models;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }        
        
        [HttpGet("throwExceptionTeste")]
        public IActionResult GetExceptionTeste()
        {
            throw new Exception("Teste");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUsuarios(int id)
        {
            throw new NotImplementedException();
        }
    }
}
