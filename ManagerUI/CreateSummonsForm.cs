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
    public partial class CreateSummonsForm : Form
    {
        Case @case;

        public CreateSummonsForm(Case caseObject)
        {
            InitializeComponent();
            @case = caseObject;
        }

        /// <summary>
        /// Prepares the offender combo box to contain all the offenders in the case
        /// </summary>
        private void CreateSummons_Load(object sender, EventArgs e)
        {
            comboBoxOffenders.ValueMember = null;
            comboBoxOffenders.DataSource = @case.Offenders;
            comboBoxOffenders.DisplayMember = "LastName";
        }

        /// <summary>
        /// Uses the TemplatePopulater class to create a new summons document in Google Drive using the URL from the URL textbox
        /// </summary>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //Immediately disables the button so the user doesn't create several copies of the same document
                buttonCreate.Enabled = false;

                //Creates a TemplatePopulator and uses it to create the summons document
                TemplatePopulator templatePopulator = new TemplatePopulator();
                templatePopulator.PopulateSummons((Offender)comboBoxOffenders.SelectedItem, textBoxFolderURL.Text, @case.ASN);

                //Tells the user that the document has been created
                labelSuccessful.Text = "Successfully created";
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occured - " + ex.Message);
            }
        }
    }
}
