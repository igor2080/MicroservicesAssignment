using Assignment.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Client.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _client;
        private const string Route = "people";

        public PersonService(HttpClient client)
        {
            _client = client;
        }

        public async Task AddPerson(Person person)
        {
            var json = JsonConvert.SerializeObject(person);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PostAsync($"{Route}/AddPerson/", content);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var request = await _client.GetAsync($"{Route}/GetAll");
            var response = await request.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<IEnumerable<Person>>(response);
        }

        public async Task<Person> GetPersonById(int PersonId)
        {
            var request = await _client.GetAsync($"{Route}/Get/{PersonId}");
            var response = await request.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Person>(response);
        }

        public async Task<bool> RemovePersonById(int id)
        {
            var request = await _client.DeleteAsync($"{Route}/DeletePerson/{id}");
            var response = await request.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<bool>(response);
        }
    }
}
