using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMPMakerC
{
    public partial class frmEditStudents : Form
    {
        KMPControl control;
        allData data;
        int counter = 0;
        public frmEditStudents(KMPControl inControl)
        {
            control = inControl;
            data = inControl.GetCurrentKMP();
            InitializeComponent();
        }

        private void frmEditStudents_Load(object sender, EventArgs e)
        {

            txtName.Text = data.names[counter];
            txtTarget.Text = data.targets[counter];
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (counter < data.names.Count - 1)
            {
                counter++;
                txtName.Text = data.names[counter];
                txtTarget.Text = data.targets[counter];

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            counter = data.names.Count;
            data.names.Add("");
            data.targets.Add("");
            txtName.Text = "New Student";
            txtTarget.Text = "";
            data.AddNewRecord("", "");
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text == "New Student")
            {
                txtName.Text = "";
            }
            data.names[counter] = txtName.Text;
            data.updateFeedbackNameandTarget(counter, txtName.Text, txtTarget.Text);
        }

        private void txtTarget_TextChanged(object sender, EventArgs e)
        {
            data.targets[counter] = txtTarget.Text;
            data.updateFeedbackNameandTarget(counter, txtName.Text, txtTarget.Text);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                txtName.Text = data.names[counter];
                txtTarget.Text = data.targets[counter];

            }
        }
    }
}
