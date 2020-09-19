using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //CourseApp.Models.Request model;
          Models.Request model = new Models.Request();
            model.Name = "Ramazan";
            model.Email = "ramazanorhanor@hotmail.com";
            model.Phone = "12345678";
            model.Message = "Kursa Katılmak istiyorum ";
            return View(model);
        }
    }
}