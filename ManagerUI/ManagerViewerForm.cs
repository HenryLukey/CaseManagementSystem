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
    public partial class ManagerViewerForm : Form
    {
        public ManagerViewerForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Inspector inspector = new Inspector();
            InspectorRepository repository = new InspectorRepository();

            inspector.FirstName = FirstNameBox.Text;
            inspector.LastName = LastNameBox.Text;
            inspector.NumberCode = NumberCodeBox.Text;
            inspector.MobileNumber = MobileBox.Text;

            repository.AddInspector(inspector);

            FirstNameBox.Clear();
            LastNameBox.Clear();
            NumberCodeBox.Clear();
            MobileBox.Clear();
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            InspectorRepository repository = new InspectorRepository();

            Inspector inspector = repository.GetInspectorByID(Int64.Parse(IDBox.Text));

            FirstNameBoxReadOnly.Text = inspector.FirstName;
            LastNameBoxReadOnly.Text = inspector.LastName;
            NumberCodeBoxReadOnly.Text = inspector.NumberCode;
            MobileBoxReadOnly.Text = inspector.MobileNumber;

            IDBox.Clear();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Inspector inspector = new Inspector();
            InspectorRepository repository = new InspectorRepository();

            inspector.ID = Int64.Parse(IDBox2.Text);
            inspector.FirstName = FirstNameBox2.Text;
            inspector.LastName = LastNameBox2.Text;
            inspector.NumberCode = NumberCodeBox2.Text;
            inspector.MobileNumber = MobileBox2.Text;

            repository.UpdateInspector(inspector);

            IDBox2.Clear();
            FirstNameBox2.Clear();
            LastNameBox2.Clear();
            NumberCodeBox2.Clear();
            MobileBox2.Clear();
        }
    }
}
