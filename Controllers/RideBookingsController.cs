using Microsoft.AspNetCore.Mvc;
using CHEAPRIDES.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using CHEAPRIDES.Data;
using Microsoft.EntityFrameworkCore;

namespace CHEAPRIDES.Controllers
{
    public class RideBookingsController : Controller
    {
        private readonly AppDbContext _context;

        public RideBookingsController(AppDbContext context)
        {
            _context = context;
        }

        // async will run in the background, allowing the application to continue processing other requests
        // await is used to wait for the database query to complete and retrieve the data before returning it as a list to the view
        /*public async Task<IActionResult> Index()
        {
            var ridebook = await _context.RideBookings.ToListAsync();
            return View(ridebook);
        }*/

        [HttpGet]
        public IActionResult Book(int id)
        {
            return View();
        }
        [HttpPost, ActionName("Book")]
        public async Task<IActionResult> BookConfirmed(int id, [Bind("Pickuplocation, Droplocation, Fare")] RideBooking rideBooking)
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

            return View(rideBooking);
        }
    }
}
