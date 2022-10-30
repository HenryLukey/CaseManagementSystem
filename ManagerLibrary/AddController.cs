using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerLibrary
{
    public class AddController
    {
        /// <summary>
        /// Creates a new instance of the Case class and assigns it's properties the respective values of the parameters. Then calls the AddCase method from a new instance of
        /// CaseRepository with the new case variable as it's parameter. This is done to add a layer of abstraction between the CaseRepository and the UI.
        /// </summary>
        public void AddCase(string hqNum, string incidentNum, string group, string region, string court, string courtCode, string offenceDate, string investDate, string submitDate, string place, string actionDate, string reviewDate, string solictor, string status, string state, string inspectorFirstName, string inspectorLastName, string inspectorNum, string inspectorMobile, ComboBox caseManagerComboBox, string ASN, ListView animalListView, ListView offenderListView)
        {
            //Checks if required fields have been popualted
            if (!String.IsNullOrEmpty(hqNum) && !String.IsNullOrEmpty(court) && !String.IsNullOrEmpty(courtCode) && !String.IsNullOrEmpty(inspectorFirstName) && !String.IsNullOrEmpty(inspectorLastName) && !String.IsNullOrEmpty(inspectorNum) && caseManagerComboBox.SelectedItem != null)
            {
                try
                {
                    Case @case = new Case();

                    CaseRepository caseRepo = new CaseRepository();

                    //creates a new instance of Court and populates it's variables
                    Court tempCourt = new Court();
                    tempCourt.CourtName = court;
                    tempCourt.CourtCode = courtCode;

                    //creates new instance of Inspector and populates it's variables
                    Inspector tempInspector = new Inspector();
                    tempInspector.FirstName = inspectorFirstName;
                    tempInspector.LastName = inspectorLastName;
                    tempInspector.NumberCode = inspectorNum;
                    tempInspector.MobileNumber = inspectorMobile;

                    @case.HQCaseNumber = hqNum;
                    @case.IncidentNumber = incidentNum;
                    @case.GroupNumber = group;
                    //if the region parameter isn't null then the case's region parameter will be set to the region parameter parsed as an Enum.
                    if (!String.IsNullOrEmpty(region))
                    {
                        @case.Region = (Region)Enum.Parse(typeof(Region), region);
                    }
                    @case.Court = tempCourt;
                    //if the offenceDate parameter then the case's offence date will be set to the offenceDate parameter parsed as a DateTime.
                    if (!String.IsNullOrEmpty(offenceDate))
                    {
                        @case.DateOfOffence = Convert.ToDateTime(offenceDate);
                    }
                    //if the investDate parameter then the case's offence date will be set to the investDate parameter parsed as a DateTime.
                    if (!String.IsNullOrEmpty(investDate))
                    {
                        @case.DateFirstInvestigated = Convert.ToDateTime(investDate);
                    }
                    //if the submitDate parameter then the case's offence date will be set to the submitDate parameter parsed as a DateTime.
                    if (!String.IsNullOrEmpty(submitDate))
                    {
                        @case.DateSubmitted = Convert.ToDateTime(submitDate);
                    }
                    @case.PlaceOfOffence = place;
                    //if the actionDate parameter then the case's offence date will be set to the actionDate parameter parsed as a DateTime.
                    if (!String.IsNullOrEmpty(actionDate))
                    {
                        @case.FurtherActionBy = Convert.ToDateTime(actionDate);
                    }
                    //if the reviewDate parameter then the case's offence date will be set to the reviewDate parameter parsed as a DateTime.
                    if (!String.IsNullOrEmpty(reviewDate))
                    {
                        @case.ReviewDate = Convert.ToDateTime(reviewDate);
                    }
                    @case.ASN = ASN;
                    @case.Solicitor = solictor;
                    //if the status parameter isn't null then the case's region parameter will be set to the status parameter parsed as an Enum.
                    if (!String.IsNullOrEmpty(status))
                    {
                        @case.Status = (CaseStatus)Enum.Parse(typeof(CaseStatus), status);
                    }
                    @case.Inspector = tempInspector;
                    //sets the cases CaseManager property to be equal to the case manager selected by the user.
                    @case.CaseManager = (CaseManager)caseManagerComboBox.SelectedItem;
                    //calls a seperate function to extract every animal/offender from the respective ListView element.
                    @case.Animals = GetAnimalsFromListView(animalListView);
                    @case.Offenders = GetOffendersFromListView(offenderListView);

                    if (state == "Open")
                    {
                        @case.IsOpen = true;
                    }
                    else if (state == "Closed")
                    {
                        @case.IsOpen = false;
                    }

                    //calls the AddCase function from the CaseRepository instance (this will push the case to the SQL database).
                    caseRepo.AddCase(@case);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("An error occured - " + ex.Message);
                }
            }

            //Displays error message if not all required fields are filled out
            else
            {
                MessageBox.Show("An error occured - please make sure all required fields are filled out");
            }
            
        }
        
        /// <summary>
        /// Takes a ListView Winforms element and extracts the data from it to return a list of animal objects.
        /// </summary>
        public List<Animal> GetAnimalsFromListView(ListView listView)
        {
            List<Animal> animalList = new List<Animal>();

            for (int i = 0; i < listView.Items.Count; i++)
            {
                ListViewItem tempItem = listView.Items[i];

                Animal animal = new Animal();

                List<string> stringData = new List<string>();
                List<string> columnInfo = new List<string>();

                //goes through every subitem in the current ListViewItem and appends them to a list.
                for (int x = 0; x < tempItem.SubItems.Count; x++)
                {
                    columnInfo.Add(tempItem.SubItems[x].ToString());
                }

                //splits the subitems into string arrays and takes the second element from the array (this is the actual information we need).
                for (int y = 0; y < columnInfo.Count; y++)
                {
                    string[] splitString = columnInfo[y].Split('{', '}');
                    stringData.Add(splitString[1]);
                }

                //assigns the animal properties their respective values from the stringData list.
                animal.ExhibitNumber = stringData[0];
                animal.Species = stringData[1];
                animal.Breed = stringData[2];
                animal.OriginalName = stringData[3];
                animal.Description = stringData[4];
                //had to be parsed because the data is formated as a string originally.
                animal.Status = (Status)Enum.Parse(typeof(Status), stringData[5]);
                animal.Date = stringData[6];
                animal.CurrentLocation = stringData[7];

                if (stringData[8] == "Yes")
                {
                    animal.SignedOver = true;
                }
                else if (stringData[8] == "No")
                {
                    animal.SignedOver = false;
                }

                if (stringData[9] == "Yes")
                {
                    animal.PTS = true;
                }
                else if (stringData[9] == "No")
                {
                    animal.PTS = false;
                }

                if (stringData[10] == "Yes")
                {
                    animal.Dead = true;
                }
                else if (stringData[10] == "No")
                {
                    animal.Dead = false;
                }

                animalList.Add(animal);
            }

            return animalList;
        }

        /// <summary>
        /// Takes a ListView Winforms element and extracts the data from it to return a list of offender objects.
        /// </summary>
        public List<Offender> GetOffendersFromListView(ListView listView)
        {
            List<Offender> offenderList = new List<Offender>();

            for (int i = 0; i < listView.Items.Count; i++)
            {
                ListViewItem tempItem = listView.Items[i];

                Offender offender = new Offender();

                List<string> stringData = new List<string>();
                List<string> columnInfo = new List<string>();

                //goes through every subitem in the current ListViewItem and appends them to a list.
                for (int x = 0; x < tempItem.SubItems.Count; x++)
                {
                    columnInfo.Add(tempItem.SubItems[x].ToString());
                }

                //splits the subitems into string arrays and takes the second element from the array (this is the actual information we need).
                for (int y = 0; y < columnInfo.Count; y++)
                {
                    string[] splitString = columnInfo[y].Split('{', '}');
                    stringData.Add(splitString[1]);
                }

                //assigns the animal properties their respective values from the stringData list.
                offender.FirstNames = stringData[0];
                offender.LastName = stringData[1];
                offender.Address = stringData[2];
                offender.Postcode = stringData[3];
                offender.NINumber = stringData[4];
                offender.Occupation = stringData[5];
                offender.DateOfBirth =Convert.ToDateTime(stringData[6]);
                //had to be parsed from a string to an enum.
                offender.Gender = (Gender)Enum.Parse(typeof(Gender), stringData[7]);
                offenderList.Add(offender);
            }

            return offenderList;
        }

        /// <summary>
        /// Creates a new instance of the Case class and assigns it's properties the respective values of the parameters. Then calls the UpdateCase method from a new instance of
        /// CaseRepository with the new case variable as it's parameter. This is done to add a layer of abstraction between the CaseRepository and the UI.
        /// </summary>
        public void UpdateCase(Case @case, TextBox textBoxActionDate, TextBox textBoxReviewDate, TextBox textBoxSolicitor, ComboBox comboBoxCaseStatus, ComboBox comboBoxState, TextBox textBoxASN, ComboBox comboBoxCaseManager)
        {
            try
            {
                CaseRepository caseRepo = new CaseRepository();

                @case.Solicitor = textBoxSolicitor.Text;
                @case.ASN = textBoxASN.Text;

                //if these parameters aren't null then the case's respective properties will be set to the parameter parsed as an DateTime or Enum.
                if (!String.IsNullOrEmpty(textBoxActionDate.Text))
                {
                    @case.FurtherActionBy = Convert.ToDateTime(textBoxActionDate.Text);
                }
                if (!String.IsNullOrEmpty(textBoxReviewDate.Text))
                {
                    @case.ReviewDate = Convert.ToDateTime(textBoxReviewDate.Text);
                }
                if (!String.IsNullOrEmpty(comboBoxCaseStatus.Text))
                {
                    @case.Status = (CaseStatus)Enum.Parse(typeof(CaseStatus), comboBoxCaseStatus.Text.Replace(" ", ""));
                }
                if (comboBoxState.Text == "Open")
                {
                    @case.IsOpen = true;
                }
                else if (comboBoxState.Text == "Closed")
                {
                    @case.IsOpen = false;
                }
                @case.CaseManager = (CaseManager)comboBoxCaseManager.SelectedItem;

                //Calls the UpdateCase from the instance of CaseRepository.
                caseRepo.UpdateCase(@case);
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occured - " + ex.Message);
            }
        }
    }
}
