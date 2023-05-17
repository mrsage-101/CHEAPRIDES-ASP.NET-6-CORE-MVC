using CHEAPRIDES.Models;
using Microsoft.EntityFrameworkCore;

namespace CHEAPRIDES.Data.Services
{
    public class PersonLoginsService : PersonLoginsInterface
    {
        private readonly AppDbContext _context;

        public PersonLoginsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PersonLogin?> GetByCredentialsAsync(string username, string password)
        {
            var result = await _context.PersonLogin.FirstOrDefaultAsync(n => n.Username == username && n.Password == password);
            return result;
        }
    }
}
