using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Client.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
    }
}
