using Assignment.Services.People.Models;
using Assignment.Services.People.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Controllers
{
    [Route("people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet("GetAll", Name = "GetAll")]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var people = _peopleRepository.GetAllPeople();

            return Ok(people);
        }

        [HttpGet("Get/{PersonId}", Name = "Get")]
        public ActionResult<Person> Get(int PersonId)
        {
            var person = _peopleRepository.GetPersonById(PersonId);

            return Ok(person);
        }

        [HttpPost("AddPerson", Name = "AddPerson")]
        public ActionResult<Person> Post(Person person)
        {
            _peopleRepository.AddPerson(person);

            return Ok();
        }

        [HttpDelete("DeletePerson/{PersonId}", Name ="DeletePerson")]
        public ActionResult Delete(int PersonId)
        {
            bool result = _peopleRepository.RemovePersonById(PersonId);

            return Ok(result);
        }
    }
}
