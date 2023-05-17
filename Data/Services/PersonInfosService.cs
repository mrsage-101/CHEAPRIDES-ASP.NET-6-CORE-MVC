using CHEAPRIDES.Models;
using Microsoft.EntityFrameworkCore;

namespace CHEAPRIDES.Data.Services
{
    public class PersonInfosService : PersonInfosInterface
    {
        private readonly AppDbContext _context;
        public PersonInfosService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(PersonInfo personInfo)
        {
            await _context.Persons.AddAsync(personInfo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Persons.FirstOrDefaultAsync(n => n.pId == id);
            if (result != null)
            {
                _context.Persons.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PersonInfo>> GetAll()
        {
            var result = await _context.Persons.ToListAsync();
            return result;
        }

        public async Task<PersonInfo?> GetByIdAsync(int id)
        {
            var result = await _context.Persons.FirstOrDefaultAsync(n => n.pId == id);
            return result;
        }

        public async Task<PersonInfo> UpdateAsync(int id, PersonInfo newPersonInfo)
        {
            var existingPersonInfo = await _context.Persons.FindAsync(id);

            if (existingPersonInfo == null)
            {
                // Handle the case when the PersonInfo with the specified ID is not found
                throw new Exception("PersonInfo not found");
            }
            // Update the properties of the existing PersonInfo
            existingPersonInfo.Name = newPersonInfo.Name;
            existingPersonInfo.Username = newPersonInfo.Username;
            existingPersonInfo.Password = newPersonInfo.Password;
            existingPersonInfo.Address = newPersonInfo.Address;
            existingPersonInfo.Contact = newPersonInfo.Contact;
            existingPersonInfo.type = newPersonInfo.type;
            // Update the associated PersonLogin
            var existingPersonLogin = await _context.PersonLogin.FindAsync(existingPersonInfo.pId);

            if (existingPersonLogin != null)
            {
                // Update the properties of the existing PersonLogin
                existingPersonLogin.Username = newPersonInfo.Username;
                existingPersonLogin.Password = newPersonInfo.Password;
                existingPersonLogin.type = newPersonInfo.type;
            }

            await _context.SaveChangesAsync();

            return existingPersonInfo;
        }
    }
}
