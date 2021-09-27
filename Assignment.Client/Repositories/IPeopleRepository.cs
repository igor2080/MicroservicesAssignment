using Assignment.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Client.Repositories
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(int PersonId);
    }
}
