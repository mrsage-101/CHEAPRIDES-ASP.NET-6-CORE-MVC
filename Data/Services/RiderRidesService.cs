using CHEAPRIDES.Models;
using Microsoft.EntityFrameworkCore;

namespace CHEAPRIDES.Data.Services
{
    public class RiderRidesService : RiderRidesInterface
    {
        private readonly AppDbContext _dbContext;

        public RiderRidesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CarRegShow> GetCarRegistrationsByUserId(int userId)
        {
            // Retrieve the car registrations by the user with the given userId
            var carRegistrations = _dbContext.CarRegShows.Include(cr => cr.PersonInfos1)
                                             .ToList();

            return carRegistrations.Where(cr => cr.PersonInfos1.pId == userId)
                                   .ToList();
        }

        public async Task AddAsync(CarRegShow carRegShow)
        {
            await _dbContext.CarRegShows.AddAsync(carRegShow);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CarRegShow?> GetByIdAsync(int id)
        {
            var result = await _dbContext.CarRegShows
                            .FirstOrDefaultAsync(cr => cr.Carid == id);
            return result;
        }


        public async Task<IEnumerable<CarRegShow>> GetAll(int id)
        {
            var result = await _dbContext.CarRegShows
                                .Where(cr => cr.pId == id)
                                .ToListAsync();
            return result;
        }
    }
}
