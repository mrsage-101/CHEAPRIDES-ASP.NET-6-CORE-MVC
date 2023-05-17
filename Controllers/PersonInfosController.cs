using CHEAPRIDES.Data;
using CHEAPRIDES.Data.Services;
using CHEAPRIDES.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CHEAPRIDES.Controllers
{
    public class PersonInfosController : Controller
    {
        private readonly PersonInfosInterface _service;

        public PersonInfosController(PersonInfosInterface service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            // it will store all data inside var data which is in DbSet<PersonInfo> Persons
            var persondata = await _service.GetAll();
            return View(persondata);
        }

        // register new personinfo (admin)
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Username,Password,Address,Contact,type")] PersonInfo personInfo)
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

        //Get Actor/Details/1,C
        public async Task<IActionResult> Details(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null)
            {
                return View("Empty");
            }
            else
            {
                return View(personDetails);
            }
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


        // Edit 
        public async Task<IActionResult> Edit(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null)
            {
                return View("Empty");
            }
            return View(personDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("pId,Name,Username,Password,Address,Contact,type")] PersonInfo personInfo)
        {
            if (!ModelState.IsValid)
            {
                // Return the view with the invalid model state
                return View(personInfo);
            }

            // Update the PersonInfo and associated PersonLogin
            await _service.UpdateAsync(id, personInfo);

            return RedirectToAction(nameof(Index));
        }


        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null)
            {
                return View("Empty");
            }
            return View(personDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null)
            {
                return View("Empty");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
