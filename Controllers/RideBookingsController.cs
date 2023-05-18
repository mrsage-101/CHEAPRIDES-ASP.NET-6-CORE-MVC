using Microsoft.AspNetCore.Mvc;
using CHEAPRIDES.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using CHEAPRIDES.Data;
using Microsoft.EntityFrameworkCore;
using CHEAPRIDES.Data.Services;

namespace CHEAPRIDES.Controllers
{
    public class RideBookingsController : Controller
    {
        private readonly AppDbContext _context;

        public RideBookingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            return View();
        }
        [HttpPost, ActionName("Book")]
        public async Task<IActionResult> BookConfirmed(int id, [Bind("Pickuplocation, Droplocation, Fare, Name")] RideBooking rideBooking)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the car from the database based on the provided id
                var car = await _context.CarRegShows.FindAsync(id);
                if (car == null)
                {
                    return NotFound();
                }

                // Update the availability of the car to false
                car.avialability = false;

                // Save changes to the database
                _context.Update(car);
                await _context.SaveChangesAsync();

                // Add the booking details to the ridebooking table
                rideBooking.Carid = car.Carid;

                _context.RideBookings.Add(rideBooking);
                await _context.SaveChangesAsync();

                return RedirectToAction("CustomerRideMain", "CarRegShows"); // Redirect to the home page or a confirmation page
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                      .Select(e => e.ErrorMessage)
                                      .ToList();
            return View(rideBooking);
        }

        // get details
        public async Task<IActionResult> Details(int id)
        {

            var bookDetails = await GetByIdAsync(id);
            //var carDetaillist = carDetails.ToList();
            if (bookDetails == null)
            {
                return View("Empty");
            }
            else
            {
                return View(bookDetails);
            }
        }

        public async Task<RideBooking?> GetByIdAsync(int id)
        {
            var result = await _context.RideBookings
                            .FirstOrDefaultAsync(cr => cr.Bookingid == id);
            return result;
        }
    }
}
