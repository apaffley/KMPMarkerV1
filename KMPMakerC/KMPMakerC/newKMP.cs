using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMPMakerC
{
    public partial class newKMP : Form
    {
        KMPControl controller;
        
        public newKMP(KMPControl inControl)
        {
            controller = inControl;
            InitializeComponent();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            OKButtonGo();
        }

        private void txtKMPName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
            {
                OKButtonGo();
            }
        }

        private void OKButtonGo()
        {
            if (txtKMPName.Text != "")
            {
                List<string> topics = new List<string>();
                topics.Add(txtCovered1.Text);
                topics.Add(txtCovered2.Text);
                controller.CreateNewKMP(txtKMPName.Text,txtTeacherName.Text,topics,txtFacultyName.Text, monthCalendar1.SelectionStart);
                frmIntlStudents form2 = new frmIntlStudents(controller.GetKMP());
                form2.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Please enter a KMP name");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newKMP_Load(object sender, EventArgs e)
        {
            txtFacultyName.Text = "Computer Science";
            monthCalendar1.SetDate(DateTime.Now);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
