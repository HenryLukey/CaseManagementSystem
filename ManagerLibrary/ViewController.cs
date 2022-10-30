using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerLibrary
{
    public class ViewController
    {
        /// <summary>
        /// Converts a list of animal objects into items that can be displayed in a ListBox
        /// </summary>
        public List<ListViewItem> ConvertAnimalsToItems(List<Animal> animals)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            //For every animal in the list convert necessary properties to be strings then add them to an array
            for (int i = 0; i < animals.Count; i++)
            {
                string signedOver = "";
                string pts = "";
                string dead = "";

                if (animals[i].SignedOver)
                {
                    signedOver = "Yes";
                }
                else if (!animals[i].SignedOver)
                {
                    signedOver = "No";
                }
                if (animals[i].PTS)
                {
                    pts = "Yes";
                }
                else if (!animals[i].PTS)
                {
                    pts = "No";
                }
                if (animals[i].Dead)
                {
                    dead = "Yes";
                }
                else if (!animals[i].Dead)
                {
                    dead = "No";
                }
                //Create an array from all the string properties
                string[] textInfo = { animals[i].ExhibitNumber, animals[i].Species, animals[i].Breed, animals[i].OriginalName, animals[i].Status.ToString(), 
                                      animals[i].Date.ToString(), animals[i].CurrentLocation, signedOver, pts, dead, animals[i].Description };
                //Create a new item from the string array
                ListViewItem item = new ListViewItem(textInfo);
                items.Add(item);
            }
            return items;
        }

        /// <summary>
        /// Converts a list of offender objects into items that can be displayed in a ListBox
        /// </summary>
        public List<ListViewItem> ConvertOffendersToItems(List<Offender> offenders)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            //For every offender in the list add its properties to a string array then create an item from that array and add it to a list of items
            for (int i = 0; i < offenders.Count; i++)
            {
                string[] textInfo = { offenders[i].FirstNames, offenders[i].LastName, offenders[i].Address, offenders[i].Postcode, offenders[i].NINumber, 
                                      offenders[i].Occupation, offenders[i].DateOfBirth.ToString(), offenders[i].Gender.ToString() };

                ListViewItem item = new ListViewItem(textInfo);

                items.Add(item);
            }

            return items;
        }
    }
}
