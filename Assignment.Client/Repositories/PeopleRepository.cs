using Assignment.Client.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Client.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IDatabase _redisDb;
        private const string HashName = "Person";//redis hash

        public PeopleRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            _redisDb = connectionMultiplexer.GetDatabase();
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

            if (personString == null)
            {
                return null;
            }

            personString = Encoding.UTF8.GetString(Convert.FromBase64String(personString));

            Person person = JsonConvert.DeserializeObject<Person>(personString);

            return person;
        }
    }
}
