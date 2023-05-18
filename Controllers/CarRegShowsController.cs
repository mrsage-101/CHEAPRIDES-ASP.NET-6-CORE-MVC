using Microsoft.AspNetCore.Mvc;
using CHEAPRIDES.Data.Services;
using CHEAPRIDES.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CHEAPRIDES.Controllers
{
    public class CarRegShowsController : Controller
    {
        private readonly RiderRidesInterface _riderRidesService;
        private static int _counter; private static int _counter2;
        int temp; private static int i;

        private static int _carid; private static int _userid;
        public CarRegShowsController(RiderRidesInterface riderRidesService)
        {
            _riderRidesService = riderRidesService;
            i++;

            _counter++;
            _counter2++;

            
            /*_counter++;
            if (i >= 1)
            { _counter2++; }*/
        }

        // get all cars registered by the user who logged in, filtered based on id
        public IActionResult RiderRides(int pId)
        {
            if (pId == 0)
            {

            }
            else
            {
                _userid = pId;
            }
            var pid = HttpContext.Session.GetInt32("pId");

            if (pid == null)
            {

                // Set the session ID only if it hasn't been set before
                HttpContext.Session.SetInt32("pId", _userid);
            }
            else
            {
                HttpContext.Session.SetInt32("pId", _userid);
            }

            var savedPid = HttpContext.Session.GetInt32("pId");
            if (savedPid.HasValue)
            {
                var carRegistrations = _riderRidesService.GetCarRegistrationsByUserId(savedPid.Value);
                var carRegList = carRegistrations.ToList();
                return View(carRegList);
            }


            return RedirectToAction("Error");
        }

        // Create functionality is going to be here 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("cName,cModel,cMake,cRegNum,pId,type,avialability")] CarRegShow carRegShow)
        {
            if (!ModelState.IsValid)
            {
                // Return the view with the invalid model state
                var pid = HttpContext.Session.GetInt32("pId");
                if (pid.HasValue)
                {
                    return View(carRegShow);
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
        public async Task<IActionResult> Edit(int id, [Bind("cName,cModel,cMake,cRegNum,type,avialability")] CarRegShow carRegShow)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                      .Select(e => e.ErrorMessage)
                                      .ToList();
                return View(carRegShow);
            }

            await _riderRidesService.UpdateAsync(id, carRegShow);

            return RedirectToAction(nameof(RiderRides));
        }


        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _riderRidesService.GetByIdDELAsync(id);
            if (carDetails == null)
            {
                return RedirectToAction(nameof(RiderRides));
            }
            return View(carDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDetails = await _riderRidesService.GetByIdDELAsync(id);
            if (carDetails == null)
            {
                return RedirectToAction(nameof(RiderRides));
            }

            await _riderRidesService.DeleteAsync(id);

            return RedirectToAction(nameof(RiderRides));
        }

        // This will take to view of Book in View RideBookings - RideBookings\Book.cshtml
        [HttpGet]
        public async Task<IActionResult> CustomerRideMain()
        {
            var carRecommend = await _riderRidesService.GetCarsTru();
            return View(carRecommend);
        }


        public async Task<IActionResult> History(int id)
        {
            if (id == 0)
            {

            }
            else
            {
                _carid = id;
            }

            var pid = HttpContext.Session.GetInt32("pId");
            // 2 
            if (pid != null)
            {

                // Set the session ID only if it hasn't been set before
                HttpContext.Session.SetInt32("pId", _carid);
            }

            var savedPid = HttpContext.Session.GetInt32("pId");
            if (savedPid.HasValue)
            {
                var bookings = _riderRidesService.GetBookingByUserId(savedPid.Value);
                var bookingList = bookings.ToList();
                return View(bookingList);
            }


            return RedirectToAction("Error");
        }


        /*public async Task<IActionResult> History(int id)
        {
            if (_counter2 == 1)
            {
                HttpContext.Session.SetInt32("pId", id);
            }
            var pid = HttpContext.Session.GetInt32("pId");
            var bookings = _riderRidesService.GetBookingByUserId(pid.Value);
            var bookingList = bookings.ToList();
            return View(bookingList);
        }*/



        /* public IActionResult History(int Carid)
         {
             if (Carid == 0)
             {
                 var bookings = _riderRidesService.GetBookingByUserId(Carid);
                 var bookingList = bookings.ToList();
                 return View(bookingList);
             }
             return RedirectToAction(nameof(RiderRides));
         }*/
    }
}