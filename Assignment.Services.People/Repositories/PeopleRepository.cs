using Assignment.Services.People.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Services.People.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IDatabase _redisDb;
        private const string HashName = "Person";//redis hash

        public PeopleRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            _redisDb = connectionMultiplexer.GetDatabase();
        }

        public void AddPerson(Person person)
        {
            var json = JsonConvert.SerializeObject(person);
            var encodedJson = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            _redisDb.HashSet(HashName, new HashEntry[] { new HashEntry(person.PersonId, encodedJson) });
        }

        public IEnumerable<Person> GetAllPeople()
        {
            var hashes = _redisDb.HashGetAll(HashName);
            var people = hashes.Select(x =>
            JsonConvert.DeserializeObject<Person>(
               Encoding.UTF8.GetString(Convert.FromBase64String(x.Value))
                ));

            return people;
        }

        public Person GetPersonById(int PersonId)
        {
            var personString = _redisDb.HashGet(HashName, PersonId).ToString();
            personString = Encoding.UTF8.GetString(Convert.FromBase64String(personString));

            if (personString == null)
            {
                return null;
            }

            Person person = JsonConvert.DeserializeObject<Person>(personString);

            return person;
        }

        public bool RemovePersonById(int PersonId)
        {
            bool isDeleted = _redisDb.HashDelete(HashName, PersonId);

            return isDeleted;
        }
    }
}
