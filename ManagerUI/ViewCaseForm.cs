using ManagerLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerUI
{
    public partial class ViewCaseForm : Form
    {
        long caseID;
        Case @case;

        public ViewCaseForm(long id)
        {
            //Initialises UI elements, sets the case id variable and instantiates some required repositories
            InitializeComponent();
            caseID = id;
            CaseRepository caseRepo = new CaseRepository();
            CaseManagerRepository caseManagerRepo = new CaseManagerRepository();

            //Sets the @case variable
            @case = caseRepo.GetCaseByID(caseID);

            //Makes the case manager combo box display all the case managers in the database
            comboBoxCaseManager.ValueMember = null;
            comboBoxCaseManager.DisplayMember = "LastName";
            comboBoxCaseManager.DataSource = caseManagerRepo.GetAllCaseManagers();
        }

        /// <summary>
        /// Fills all the UI elements with the relevant data from the case when the form is loaded
        /// </summary>
        private void ViewCaseForm_Load(object sender, EventArgs e)
        {
            ViewController viewController = new ViewController();

            //Sets all the text of the textboxes
            textBoxHQ.Text = @case.HQCaseNumber;
            textBoxIncident.Text = @case.IncidentNumber;
            textBoxGroup.Text = @case.GroupNumber;
            comboBoxRegion.Text = @case.Region.ToString();
            textBoxCourt.Text = @case.Court.CourtName;
            textBoxCourtCode.Text = @case.Court.CourtCode;
            textBoxOffenceDate.Text = @case.DateOfOffence.ToString();
            textBoxInvestDate.Text = @case.DateFirstInvestigated.ToString();
            textBoxSubmitDate.Text = @case.DateSubmitted.ToString();
            textBoxOffencePlace.Text = @case.PlaceOfOffence;
            textBoxActionDate.Text = @case.FurtherActionBy.ToString();
            textBoxReviewDate.Text = @case.ReviewDate.ToString();
            textBoxSolicitor.Text = @case.Solicitor;
            textBoxInsFName.Text = @case.Inspector.FirstName;
            textBoxInsLName.Text = @case.Inspector.LastName;
            textBoxInsNum.Text = @case.Inspector.NumberCode;
            textBoxMobile.Text = @case.Inspector.MobileNumber;
            textBoxASN.Text = @case.ASN;
            comboBoxCaseStatus.Text = @case.Status.ToString();
            
            //These must be to strings using if statements (so there can be spaces between seperate words)
            if (@case.Status == CaseStatus.FurtherAction)
            {
                comboBoxCaseStatus.Text = "Further Action";
            }
            else if (@case.Status == CaseStatus.NoProceedings)
            {
                comboBoxCaseStatus.Text = "No Proceedings";
            }

            //Sets the correct case manager in the combo box
            comboBoxCaseManager.SelectedIndex = (int)@case.CaseManager.ID-1;

            //Converts from boolean values to 'open' / 'closed'
            if (@case.IsOpen)
            {
                comboBoxState.Text = "Open";
            }
            else if (!@case.IsOpen)
            {
                comboBoxState.Text = "Closed";
            }

            //Converts animal and offender lists into values that can be used in a list view table
            List<ListViewItem> animalItems = viewController.ConvertAnimalsToItems(@case.Animals);
            List<ListViewItem> offenderItems = viewController.ConvertOffendersToItems(@case.Offenders);

            //Inserts all animals into the animal list view table
            for (int i = 0; i < animalItems.Count; i++)
            {
                listViewAnimals.Items.Add(animalItems[i]);
            }

            //Inserts all offenders into the offender list view table
            for (int i = 0; i < offenderItems.Count; i++)
            {
                listViewOffenders.Items.Add(offenderItems[i]);
            }
        }

        /// <summary>
        /// Pushes all the changes made to the database (by creating a new case object based on the contents of the UI elements) when the update button is pressed
        /// </summary>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            AddController addController = new AddController();

            addController.UpdateCase(@case, textBoxActionDate, textBoxReviewDate, textBoxSolicitor, comboBoxCaseStatus, comboBoxState, textBoxASN, comboBoxCaseManager);
        }

        /// <summary>
        /// Opens the case's checklist or creates a new one if the case doesn't already have one
        /// </summary>
        private void buttonChecklist_Click(object sender, EventArgs e)
        {
            try
            {
                //If the case has a checklist then open it
                if (@case.Checklist != null)
                {
                    ChecklistForm checklistForm = new ChecklistForm(@case.Checklist);
                    checklistForm.Show();
                }

                //Otherwise create a new checklist, add it to the database, link it to this case, update the database so it knows of the link, then show the checklist
                else if (@case.Checklist == null)
                {
                    ChecklistRepository checklistRepo = new ChecklistRepository();
                    CaseRepository caseRepo = new CaseRepository();
                    Checklist tempChecklist = new Checklist();

                    long checklistID = checklistRepo.AddChecklist(tempChecklist);

                    @case.Checklist = checklistRepo.GetChecklistByID(checklistID);

                    caseRepo.UpdateCase(@case);

                    ChecklistForm checklistForm = new ChecklistForm(@case.Checklist);

                    checklistForm.Show();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occured - " + ex.Message);
            }
        }

        /// <summary>
        /// Open the create summons window when the create summons button is pressed
        /// </summary>
        private void buttonCreateSummons_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSummonsForm summonsForm = new CreateSummonsForm(@case);
                summonsForm.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occured - " + ex.Message);
            }
        }

        /// <summary>
        /// Open the create caution window when the create caution button is pressed
        /// </summary>
        private void buttonCreateCaution_Click(object sender, EventArgs e)
        {
            try
            {
                CreateCautionForm cautionForm = new CreateCautionForm(@case);
                cautionForm.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occured - " + ex.Message);
            }
        }
    }
}
