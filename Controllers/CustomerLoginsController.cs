using CHEAPRIDES.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace CHEAPRIDES.Controllers
{
        public class CustomerLoginsController : Controller
        {
            private readonly PersonLoginsInterface _service;

            public CustomerLoginsController(PersonLoginsInterface service)
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
                    if (personLogin.type == 'C')
                    {
                        return RedirectToAction("CustomerRideMain", "CarRegShows");
                    }
                }

                // Login failed, display an error message or perform other actions
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }
}
