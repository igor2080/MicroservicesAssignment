using Assignment.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Client.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetPersonById(int PersonId);
        Task AddPerson(Person person);
        Task<bool> RemovePersonById(int id);
    }
}
