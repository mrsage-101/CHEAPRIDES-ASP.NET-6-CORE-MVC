using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CHEAPRIDES.Data.Services;
using CHEAPRIDES.Models;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CHEAPRIDES.Controllers
{
    public class PersonLoginsController : Controller
    {
        private readonly PersonLoginsInterface _service;

        public PersonLoginsController(PersonLoginsInterface service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Index(string username, string password)
        {
            var personLogin = await _service.GetByCredentialsAsync(username, password);

            if (personLogin != null)
            {
                if (personLogin.type == "A")
                { return RedirectToAction("Index", "PersonInfos"); }

            }

            // Login failed, display an error message or perform other actions
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

    }
}
