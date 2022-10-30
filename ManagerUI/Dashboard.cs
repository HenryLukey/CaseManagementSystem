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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            //Makes the case manager sorting combobox contain all the case managers from the database (as well as an 'all' option)
            comboBoxStatus.SelectedIndex = 0;
            CaseManagerRepository caseManagerRepo = new CaseManagerRepository();
            comboBoxCaseManager.ValueMember = null;
            comboBoxCaseManager.DisplayMember = "LastName";
            List<CaseManager> caseManagers = new List<CaseManager>();
            caseManagers = caseManagerRepo.GetAllCaseManagers();
            CaseManager all = new CaseManager();
            all.FirstName = "###";
            all.LastName = "All managers";
            caseManagers.Insert(0, all);
            comboBoxCaseManager.DataSource = caseManagers;
        }

        /// <summary>
        /// Updates the case list box when the search button is pressed
        /// </summary>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            UpdateCasesListBox();
        }

        /// <summary>
        /// Filters and sorts cases by the terms / options selected by the user and updates the list box to contain only these cases
        /// </summary>
        private void UpdateCasesListBox()
        {
            //Filters the cases by the relevant terms
            CaseFilter filter = new CaseFilter();
            string selectedStatus = comboBoxStatus.SelectedItem.ToString();
            List<Case> cases = filter.GetCases(textBoxSearch.Text, (CaseManager)comboBoxCaseManager.SelectedItem, selectedStatus);

            //Updates the list box
            listBoxCases.ValueMember = null;
            listBoxCases.DataSource = null;
            listBoxCases.Items.Clear();
            listBoxCases.DataSource = filter.OrderCases(cases, comboBoxOrderBy.Text);
            listBoxCases.DisplayMember = "HQCaseNumber";
        }

        /// <summary>
        /// Opens the add case screen when the new case button is pressed
        /// </summary>
        private void buttonNewCase_Click(object sender, EventArgs e)
        {
            openChildForm(new AddCaseForm());
        }

        private Form activeForm = null;


        /// <summary>
        /// Opens a form on a section of the current screen, this way the hotbar on the left remains and there is only 1 tab open
        /// </summary>
        private void openChildForm(Form childForm)
        {
            //If there's currently a form open then close it
            if (activeForm != null)
            {
                activeForm.Close();
            }

            //Open the given form on the main section of the screen
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Opens the view case panel for the case selected by the user
        /// </summary>
        private void listBoxCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If the user has selected a case
            if (listBoxCases.SelectedItem != null)
            {
                try
                {
                    //Open the selected case
                    Case tempCase = (Case)listBoxCases.SelectedItem;
                    long caseID = tempCase.ID;
                    openChildForm(new ViewCaseForm(caseID));
                }

                catch (Exception ex)
                {
                    MessageBox.Show("An error occured - " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Updates the case list box when the ordering combo box option changes
        /// </summary>
        private void comboBoxOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCasesListBox();
        }

        /// <summary>
        /// Updates the case list box when the user selects a status to sort by
        /// </summary>
        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCasesListBox();
        }

        /// <summary>
        /// Updates the case list box when the user selects a case manager to sort by
        /// </summary>
        private void comboBoxCaseManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCasesListBox();
        }
    }
}
