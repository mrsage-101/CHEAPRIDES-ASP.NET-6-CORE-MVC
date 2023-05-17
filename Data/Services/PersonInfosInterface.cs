using CHEAPRIDES.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHEAPRIDES.Data.Services
{
    public interface PersonInfosInterface
    {
        // get all personinfos
        Task<IEnumerable<PersonInfo>> GetAll();

        // get single personinfo
        Task<PersonInfo?> GetByIdAsync(int id);

        // add data to database
        Task AddAsync(PersonInfo personInfo);
        
        // functionality to update
        Task<PersonInfo> UpdateAsync(int id, PersonInfo newpersonInfo);
        
        // Delete method
        Task DeleteAsync(int id);
    }
}
