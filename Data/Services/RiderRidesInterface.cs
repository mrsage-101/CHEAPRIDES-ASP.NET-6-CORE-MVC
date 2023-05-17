using CHEAPRIDES.Models;

namespace CHEAPRIDES.Data.Services
{
    public interface RiderRidesInterface
    {
        IEnumerable<CarRegShow> GetCarRegistrationsByUserId(int userId);

        // add data to database
        Task AddAsync(CarRegShow carRegShow);

        // identify whether the carid is there or not
        Task<CarRegShow?> GetByIdAsync(int id);

        // get all personinfos
        Task<IEnumerable<CarRegShow>> GetAll(int id);

        // functionality to update
        public Task<CarRegShow> UpdateAsync(int id, CarRegShow updatedcar);

        // Delete method
        Task DeleteAsync(int id);
    }
}
