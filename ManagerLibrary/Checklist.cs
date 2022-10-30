using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    //creates a new class called Checklist and declares all of it's properties.
    public class Checklist
    {
        public long ID { get; set; }
        public bool Wilberforce { get; set; }
        public bool Infos { get; set; }
        public bool ASNRequested { get; set; }
        public bool ASNReceived { get; set; }
        public bool SharingRights { get; set; }
        public bool HearingDate { get; set; }
        public bool DeliveryReceipt { get; set; }
        public bool AuthorisationReceived { get; set; }
        public bool Diary { get; set; }
        public bool Inform { get; set; }
        public bool HearingSent { get; set; }
        public bool SummonsServed { get; set; }
        public bool BriefSent { get; set; }
    }
}
