using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    //Declares a new Enum variable called Gender.
    public enum Gender
    {
        Female,
        Male
    }

    //creates a new class called Offender and declares all of it's properties.
    public class Offender
    {
        public long ID { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string NINumber { get; set; }
        public string Occupation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
