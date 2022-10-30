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
    public partial class ChecklistForm : Form
    {
        Checklist checklist;

        public ChecklistForm(Checklist checkList)
        {
            //Initialises the UI elements and creates a new blank checklist object if the given one is null
            InitializeComponent();

            if (checkList == null)
            {
                checklist = new Checklist();
            }
            else if (checkList != null)
            {
                checklist = checkList;
            }
        }

        /// <summary>
        /// Updates the properties of the checklist object based on the UI checkboxes and updates the database using this checklist object
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            ChecklistRepository checklistRepo = new ChecklistRepository();

            //Sets the checklist properties to equal the boolean value of the respective checkbox
            checklist.Wilberforce = checkBoxWilberforce.Checked;
            checklist.Infos = checkBoxInfos.Checked;
            checklist.ASNRequested = checkBoxASNRequested.Checked;
            checklist.ASNReceived = checkBoxASNReceived.Checked;
            checklist.SharingRights = checkBoxSharing.Checked;
            checklist.HearingDate = checkBoxHearing.Checked;
            checklist.DeliveryReceipt = checkBoxDeliveryReceipt.Checked;
            checklist.AuthorisationReceived = checkBoxAuthorisationReceived.Checked;
            checklist.Diary = checkBoxDiary.Checked;
            checklist.Inform = checkBoxInform.Checked;
            checklist.HearingSent = checkBoxACRO.Checked;
            checklist.SummonsServed = checkBoxSummonsServed.Checked;
            checklist.BriefSent = checkBoxBrief.Checked;

            //Calls the update method from the Checklist Repository using the updated object as a parameter
            checklistRepo.UpdateChecklist(checklist);

            this.Close();
        }

        /// <summary>
        /// Sets all the UI checkboxes to be ticked or unticked based on the boolean values of the checklist object
        /// </summary>
        private void ChecklistForm_Load(object sender, EventArgs e)
        {
            checkBoxWilberforce.Checked = checklist.Wilberforce;
            checkBoxInfos.Checked = checklist.Infos;
            checkBoxASNRequested.Checked = checklist.ASNRequested;
            checkBoxASNReceived.Checked = checklist.ASNReceived;
            checkBoxSharing.Checked = checklist.SharingRights;
            checkBoxHearing.Checked = checklist.HearingDate;
            checkBoxDeliveryReceipt.Checked = checklist.DeliveryReceipt;
            checkBoxAuthorisationReceived.Checked = checklist.AuthorisationReceived;
            checkBoxDiary.Checked = checklist.Diary;
            checkBoxInform.Checked = checklist.Inform;
            checkBoxACRO.Checked = checklist.HearingSent;
            checkBoxSummonsServed.Checked = checklist.SummonsServed;
            checkBoxBrief.Checked = checklist.BriefSent;
        }
    }
}
