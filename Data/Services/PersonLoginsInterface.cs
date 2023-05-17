using CHEAPRIDES.Models;

namespace CHEAPRIDES.Data.Services
{
    public interface PersonLoginsInterface
    {
        // check person is in database or not
        Task<PersonLogin?> GetByCredentialsAsync(string username, string password);
    }
}
