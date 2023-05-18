using CHEAPRIDES.Data.Services;
using CHEAPRIDES.Models;
using Microsoft.AspNetCore.Mvc;

namespace CHEAPRIDES.Controllers
{
    public class RiderLoginsController : Controller
    {
        private readonly PersonLoginsInterface _service;

        public RiderLoginsController(PersonLoginsInterface service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var personLogin = await _service.GetByCredentialsAsync(username, password);

            if (personLogin != null)
            {
                if (personLogin.type == "R")
                {
                    return RedirectToAction("RiderRides", "CarRegShows", new { personLogin.pId });
                }
            }

            // Login failed, display an error message or perform other actions
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([Bind("Name,Username,Password,Address,Contact,type")] PersonInfo personInfo)
        {
            if (!ModelState.IsValid)
            {
                // Return the view with the invalid model state
                return View(personInfo);
            }

            var personLogin = MapPersonInfoToPersonLogin(personInfo);


            // Set the PersonLogins property of the personInfo object
            personInfo.PersonLogins = personLogin;


            await _service.AddAsync(personInfo);
            return RedirectToAction(nameof(Index));
        }

        private PersonLogin MapPersonInfoToPersonLogin(PersonInfo personInfo)
        {
            return new PersonLogin
            {
                Username = personInfo.Username,
                Password = personInfo.Password,
                type = personInfo.type
            };
        }
    }
}
