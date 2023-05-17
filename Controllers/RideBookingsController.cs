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
        public async Task<IActionResult> Index()
        {
            var ridebook = await _context.RideBookings.ToListAsync();
            return View(ridebook);
        }
    }
}
