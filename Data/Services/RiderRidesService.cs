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

        public async Task<CarRegShow> UpdateAsync(int id, CarRegShow updatedcar)
        {
            var existingcarInfo = await _dbContext.CarRegShows.FindAsync(id);

            if (existingcarInfo == null)
            {
                // Handle the case when the PersonInfo with the specified ID is not found
                throw new Exception("PersonInfo not found");
            }


            existingcarInfo.cName = updatedcar.cName;
            existingcarInfo.cModel = updatedcar.cModel;
            existingcarInfo.cMake = updatedcar.cMake;
            existingcarInfo.cRegNum = updatedcar.cRegNum;
            existingcarInfo.avialability = updatedcar.avialability;

            await _dbContext.SaveChangesAsync();

            return existingcarInfo;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbContext.CarRegShows.FirstOrDefaultAsync(n => n.Carid == id);
            if (result != null)
            {
                _dbContext.CarRegShows.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        // retrieve all cars where avialability is true
        public async Task<IEnumerable<CarRegShow>> GetCarsTru()
        {
            var result = await _dbContext.CarRegShows.Where(c => c.avialability).ToListAsync();
            return result;
        }
    }
}