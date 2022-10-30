using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerLibrary;

namespace ManagerUI
{
    public partial class AddCaseForm : Form
    {
        
        public AddCaseForm()
        {
            //Initialises the UI and prepares the case manager sorting comboBox to contain all the case managers in our database
            InitializeComponent();
            CaseManagerRepository caseManagerRepo = new CaseManagerRepository();
            comboBoxCaseManager.DisplayMember = "LastName";
            comboBoxCaseManager.DataSource = caseManagerRepo.GetAllCaseManagers();
        }


        /// <summary>
        /// Calls the AddAnimalToTable method when the add animal button is pressed, using data from the relevant text boxes / combo boxes
        /// </summary>
        private void buttonAddAnimal_Click(object sender, EventArgs e)
        {
            string[] textInfo = { textBoxExNo.Text, textBoxSpecies.Text, textBoxBreed.Text, textBoxOGName.Text, textBoxDesc.Text, comboBoxAniStatus.Text,
                                  textBoxAniDate.Text, textBoxAniLocation.Text, comboBoxSignedOver.Text, comboBoxPTS.Text, comboBoxDead.Text };

            AddAnimalToTable(textInfo);
        }

        /// <summary>
        /// Takes a string array and adds its data to the animal list view table
        /// </summary>
        private void AddAnimalToTable(string[] textInfo)
        {
            //Converts the array to a ListViewItem and adds it to the animal list view table
            ListViewItem item = new ListViewItem(textInfo);
            listViewAnimals.Items.Add(item);

            //Clears the textboxes and comboboxes the user inserted data into
            textBoxExNo.Clear();
            textBoxSpecies.Clear();
            textBoxBreed.Clear();
            textBoxOGName.Clear();
            textBoxDesc.Clear();
            textBoxAniDate.Clear();
            textBoxAniLocation.Clear();
            comboBoxSignedOver.SelectedIndex = -1;
            comboBoxAniStatus.SelectedIndex = -1;
            comboBoxPTS.SelectedIndex = -1;
            comboBoxDead.SelectedIndex = -1;
        }

        /// <summary>
        /// Calls the AddOffenderToTable method when the add offender button is pressed, using data from the relevant text boxes / combo boxes
        /// </summary>
        private void buttonAddOffender_Click(object sender, EventArgs e)
        {
            string[] textInfo = { textBoxOffenderFNames.Text, textBoxOffenderLName.Text, textBoxOffenderAddress.Text, textBoxOffenderPCode.Text, textBoxOffenderNIN.Text,
                                  textBoxOffenderJob.Text, textBoxOffenderDOB.Text, comboBoxOffenderGender.Text};

            AddOffenderToTable(textInfo);
        }

        /// <summary>
        /// Takes a string array and adds its data to the offender list view table
        /// </summary>
        private void AddOffenderToTable(string[] textInfo)
        {
            //Converts the array to a ListViewItem and adds it to the offender list view table
            ListViewItem item = new ListViewItem(textInfo);
            listViewOffenders.Items.Add(item);

            //Clears the textboxes and comboboxes the user inserted data into
            textBoxOffenderFNames.Clear();
            textBoxOffenderLName.Clear();
            textBoxOffenderAddress.Clear();
            textBoxOffenderPCode.Clear();
            textBoxOffenderNIN.Clear();
            textBoxOffenderJob.Clear();
            textBoxOffenderDOB.Clear();
            comboBoxOffenderGender.SelectedIndex = -1;
        }

        /// <summary>
        /// Adds all the data in the UI elements to the SQL database
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Creates an AddController instance
            AddController addController = new AddController();

            //Calls the AddCase method passing in all the textbox/combobox data as parameters
            addController.AddCase(textBoxHQ.Text, textBoxIncident.Text, textBoxGroup.Text, comboBoxRegion.Text, textBoxCourt.Text, textBoxCourtCode.Text, textBoxOffenceDate.Text, textBoxInvestDate.Text, textBoxSubmitDate.Text, textBoxOffencePlace.Text, textBoxActionDate.Text, textBoxReviewDate.Text, textBoxSolicitor.Text, comboBoxCaseStatus.Text, comboBoxState.Text, textBoxInsFName.Text, textBoxInsLName.Text, textBoxInsNum.Text, textBoxMobile.Text, comboBoxCaseManager, textBoxASN.Text, listViewAnimals, listViewOffenders);
        }

        /// <summary>
        /// Fills all the UI elements with information from a pre-existing front sheet document stored on Google Drive
        /// </summary>
        private void buttonFillout_Click(object sender, EventArgs e)
        {
            try
            {
                //Creates a new FrontSheet instance and populates it's properties using the URL of a front sheet (written in the URL textbox)
                DataManager dataManager = new DataManager();
                FrontSheet frontSheet = dataManager.GetFrontSheetFromURL(textBoxFillout.Text);

                //Makes all UI elements display the relevant data from the front sheet
                textBoxHQ.Text = frontSheet.HQCaseNumber;
                textBoxIncident.Text = frontSheet.IncidentNumber;
                textBoxGroup.Text = frontSheet.Group;
                comboBoxRegion.Text = frontSheet.Region;
                textBoxCourt.Text = frontSheet.CourtName;
                textBoxCourtCode.Text = frontSheet.CourtCode;
                textBoxOffenceDate.Text = frontSheet.DateOfOffence;
                textBoxInvestDate.Text = frontSheet.DateFirstInvestigated;
                textBoxSubmitDate.Text = frontSheet.DateSubmitted;
                textBoxOffencePlace.Text = frontSheet.PlaceOfOffence;
                comboBoxState.Text = "Open";
                textBoxInsFName.Text = frontSheet.InspectorFirstName;
                textBoxInsLName.Text = frontSheet.InspectorLastName;
                textBoxInsNum.Text = frontSheet.IncidentNumber;
                textBoxMobile.Text = frontSheet.InspectorMobile;

                //Adds all the animal objects to the listview table
                for (int i = 0; i < frontSheet.Animals.Count; i++)
                {
                    string status = frontSheet.Animals[i].Status.ToString();
                    string signedOver = "";
                    string pts = "";
                    string dead = "";

                    if (frontSheet.Animals[i].SignedOver == true)
                    {
                        signedOver = "Yes";
                    }
                    else if (frontSheet.Animals[i].SignedOver == false)
                    {
                        signedOver = "No";
                    }

                    if (frontSheet.Animals[i].PTS == true)
                    {
                        pts = "Yes";
                    }
                    else if (frontSheet.Animals[i].PTS == false)
                    {
                        pts = "No";
                    }

                    if (frontSheet.Animals[i].Dead == true)
                    {
                        dead = "Yes";
                    }
                    else if (frontSheet.Animals[i].Dead == false)
                    {
                        dead = "No";
                    }

                    string[] animalInfo = { frontSheet.Animals[i].ExhibitNumber, frontSheet.Animals[i].Species, frontSheet.Animals[i].Breed, frontSheet.Animals[i].OriginalName,
                                  frontSheet.Animals[i].Description, status, frontSheet.Animals[i].Date, frontSheet.Animals[i].CurrentLocation, signedOver, pts, dead };

                    AddAnimalToTable(animalInfo);
                }

                //Adds the offender to the list view table
                string[] offenderInfo = { frontSheet.OffenderFirstNames, frontSheet.OffenderLastName, frontSheet.OffenderAddress, frontSheet.OffenderPostcode,
                                      frontSheet.OffenderNINumber, frontSheet.OffenderOccupation, frontSheet.OffenderDateOfBirth, frontSheet.OffenderGender };

                AddOffenderToTable(offenderInfo);
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("An error occured - " + ex.Message);
            }
        }
    }
}
