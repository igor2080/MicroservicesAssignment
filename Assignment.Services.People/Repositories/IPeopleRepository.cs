using Assignment.Services.People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Services.People.Repositories
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(int PersonId);
        void AddPerson(Person person);
        bool RemovePersonById(int id);
    }
}
