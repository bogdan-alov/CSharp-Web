using Microsoft.EntityFrameworkCore;
using SimpleMvc.App.ViewModels;
using SimpleMvc.Data;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using SimpleMvc.Framework.Interfaces.Generic;
using System.Collections.Generic;
using System.Linq;
using SimpleMvc.Data.Models;

namespace SimpleMvc.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            

            return View();
        }

    }
}