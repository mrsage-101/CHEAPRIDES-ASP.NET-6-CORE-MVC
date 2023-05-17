using Microsoft.AspNetCore.Mvc;
using CHEAPRIDES.Data.Services;
using CHEAPRIDES.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;


namespace CHEAPRIDES.Controllers
{
    public class CarRegShowsController : Controller
    {
        private readonly RiderRidesInterface _riderRidesService;
        private static int _counter; private static int _counter2;
        int temp; private static int i;
        public CarRegShowsController(RiderRidesInterface riderRidesService)
        {
            _riderRidesService = riderRidesService;
            i++;

            _counter++;
            if (i >= 1)
            { _counter2++; }
        }

        // get all cars registered by the user who logged in, filtered based on id
        public IActionResult RiderRides(int pId)
        {
            temp = pId;
            if (_counter == 1)
            {
                HttpContext.Session.SetInt32("pId", temp);
            }
            var pid = HttpContext.Session.GetInt32("pId");

            if (pid.HasValue)
            {
                var carRegistrations = _riderRidesService.GetCarRegistrationsByUserId(pid.Value);
                var carRegistrationList = carRegistrations.ToList();
                return View(carRegistrationList);
            }
            return RedirectToAction("Error");
        }

        // Create functionality is going to be here 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("cName,cModel,cMake,cRegNum,pId,type")] CarRegShow carRegShow)
        {
            if (!ModelState.IsValid)
            {
                // Return the view with the invalid model state
                var pid = HttpContext.Session.GetInt32("pId");
                if (pid.HasValue)
                {
                    var carRegistrations = _riderRidesService.GetCarRegistrationsByUserId(pid.Value);
                    var carRegistrationList = carRegistrations.ToList();
                    return View(carRegistrationList);
                }
                else
                {
                    // Handle the case when pid is null
                    // For example, redirect to a different action or display an error message
                    return RedirectToAction("Error");
                }
            }


            await _riderRidesService.AddAsync(carRegShow);

            return RedirectToAction(nameof(RiderRides));
        }


        // get details
        public async Task<IActionResult> Details(int id)
        {

            var carDetails = await _riderRidesService.GetByIdAsync(id);
            //var carDetaillist = carDetails.ToList();
            if (carDetails == null)
            {
                return View("Empty");
            }
            else
            {
                return View(carDetails);
            }
        }

        // ...

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var carDetails = await _riderRidesService.GetByIdAsync(id);
            if (carDetails == null)
            {
                return View("Empty");
            }
            return View(carDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("cName,cModel,cMake,cRegNum")] CarRegShow carRegShow)
        {
            if (!ModelState.IsValid)
            {
                return View(carRegShow);
            }

            await _riderRidesService.UpdateAsync(id, carRegShow);

            return RedirectToAction(nameof(RiderRides));
        }

        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _riderRidesService.GetByIdAsync(id);
            if (carDetails == null)
            {
                return View("Empty");
            }
            return View(carDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDetails = await _riderRidesService.GetByIdAsync(id);
            if (carDetails == null)
            {
                return View("Empty");
            }

            await _riderRidesService.DeleteAsync(id);

            return RedirectToAction(nameof(RiderRides));
        }
    }
}
