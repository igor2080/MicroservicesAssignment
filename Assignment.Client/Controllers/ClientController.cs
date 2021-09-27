using Assignment.Client.Models;
using Assignment.Client.Repositories;
using Assignment.Client.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IPeopleRepository _peopleRepository;

        public ClientController(IPersonService service, IPeopleRepository peopleRepository)
        {
            _personService = service;
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //local reads
            //var result = _peopleRepository.GetAllPeople();
            //var result = _peopleRepository.GetPersonById(5);

            //====

            //api reads
            //await _personService.AddPerson(new Person {PersonId=new Random().Next(2,1001),Age=20,Date=DateTime.Now,Name="Name",Occupation="Job" });
            //var result = await _personService.GetPersonById(1);
            //var result = await _personService.RemovePersonById(1);
            //var result = await _personService.GetAll();
        }

    }
}
