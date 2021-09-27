using Assignment.Client.Models;
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

        public ClientController(IPersonService service)
        {
            _personService = service;
        }

        [HttpGet]
        public async Task Get()
        {
            await _personService.AddPerson(new Person {PersonId=new Random().Next(2,1001),Age=20,Date=DateTime.Now,Name="Name",Occupation="Job" });
            //var result = await _personService.GetPersonById(1);
            //var result = await _personService.RemovePersonById(1);
            //var result = await _personService.GetAll();
        }

    }
}
