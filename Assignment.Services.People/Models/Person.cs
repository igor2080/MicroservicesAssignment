using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Services.People.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public int Age { get; set; }
        public string Occupation { get; set; }
    }
}
