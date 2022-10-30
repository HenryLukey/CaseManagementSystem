using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    //Declares a new Enum variable called Status.
    public enum Status
    {
        SO,
        SE,
        PB,
        Fosterer,
        PTS,
        Dead,
        RTO,
        WithOwner,
        ReturnedToWild,
        Rehomed
    }

    //creates a new class called Animal and declares all of it's properties.
    public class Animal
    {
        public long ID { get; set; }
        public string ExhibitNumber { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string OriginalName { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        //stored as a string because the date is not written in any set certain format on the front sheet.
        public string Date { get; set; } 
        public string CurrentLocation { get; set; }
        public bool SignedOver { get; set; }
        public bool PTS { get; set; }
        public bool Dead { get; set; }
    }
}
