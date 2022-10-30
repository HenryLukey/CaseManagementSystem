using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    //creates a new class called FrontSheet and declares all of it's properties.
    public class FrontSheet
    {
        public string HQCaseNumber { get; set; }
        public string IncidentNumber { get; set; }
        public string Region { get; set; }
        public string Group { get; set; }
        public string DateOfOffence { get; set; }
        public string DateFirstInvestigated { get; set; }
        public string DateSubmitted { get; set; }
        public string CourtName { get; set; }
        public string CourtCode { get; set; }
        public string InspectorFirstName { get; set; }
        public string InspectorLastName { get; set; }
        public string InspectorNumber { get; set; }
        public string InspectorMobile { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public string OffenderLastName { get; set; }
        public string OffenderFirstNames { get; set; }
        public string OffenderAddress { get; set; }
        public string OffenderPostcode { get; set; }
        public string OffenderOccupation { get; set; }
        public string OffenderDateOfBirth { get; set; }
        public string OffenderNINumber { get; set; }
        public string OffenderGender { get; set; }
        public string PlaceOfOffence { get; set; }

    }
}
