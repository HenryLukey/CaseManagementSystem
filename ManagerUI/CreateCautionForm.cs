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
    public partial class CreateCautionForm : Form
    {
        Case @case;

        public CreateCautionForm(Case caseObject)
        {
            //Initialises UI elements and sets the @case value to equal to the given case object
            InitializeComponent();
            @case = caseObject;
        }

        /// <summary>
        /// Uses the TemplatePopulater class to create a new caution document in Google Drive using the URL from the URL textbox
        /// </summary>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //Immediately disables the button so the user doesn't create several copies of the same document
                buttonCreate.Enabled = false;

                //Creates a TemplatePopulator and uses it to create the caution document
                TemplatePopulator templatePopulator = new TemplatePopulator();
                templatePopulator.PopulateCaution((Offender)comboBoxOffenders.SelectedItem, textBoxFolderURL.Text, @case.ASN);

                //Tells the user that the document has been created
                labelSuccessful.Text = "Successfully created";
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occured - " + ex.Message);
            }
        }

        /// <summary>
        /// Prepares the offender combo box to contain all the offenders in the case
        /// </summary>
        private void CreateCautionForm_Load(object sender, EventArgs e)
        {
            comboBoxOffenders.ValueMember = null;
            comboBoxOffenders.DataSource = @case.Offenders;
            comboBoxOffenders.DisplayMember = "LastName";
        }
    }
}
