using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    //Declares a new Enum variable called Region.
    public enum Region
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }

    //Declares a new Enum variable called CaseStatus.
    public enum CaseStatus
    {
        Caution,
        NoProceedings,
        Summons,
        FurtherAction
    }

    //creates a new class called Case and declares all of it's properties.
    public class Case
    {
        public long ID { get; set; }
        public string HQCaseNumber { get; set; }
        public string IncidentNumber { get; set; }
        public string GroupNumber { get; set; }
        public Region Region { get; set; }
        public Inspector Inspector { get; set; }
        public Court Court { get; set; }
        public DateTime DateOfOffence { get; set; }
        public DateTime DateFirstInvestigated { get; set; }
        public DateTime DateSubmitted { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public List<Offender> Offenders { get; set; } = new List<Offender>();
        public string PlaceOfOffence { get; set; }
        public string ASN { get; set; }
        public CaseManager CaseManager { get; set; }
        public bool IsOpen { get; set; }
        public CaseStatus Status { get; set; }
        public DateTime FurtherActionBy { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Solicitor { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public Checklist Checklist { get; set; }
    }
}
