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
    public partial class frmIntlStudents : Form
    {
        allData data;
        public frmIntlStudents(allData inData)
        {
            InitializeComponent();
            data = inData;
            try
            {
                for (int i = 0; i < data.names.Count; i++)
                {
                    txtNames.Text = txtNames.Text + data.names[i];
                    if (i != data.names.Count - 1)
                    {
                        txtNames.Text = txtNames.Text + Environment.NewLine;
                    }
                }
                for (int i = 0; i < data.targets.Count; i++)
                {
                    txtTarget.Text = txtTarget.Text + data.targets[i];
                    if (i != data.targets.Count - 1)
                    {
                        txtTarget.Text = txtTarget.Text + Environment.NewLine;
                    }
                }
                
            }
            catch
            {

            }
        }

        private void frmStudents_Load(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (txtNames.Text != "")
            {
                List<string> namesTemp = new List<string>();
                for (int i = 0; i < txtNames.Lines.Length; i++)
                {
                    string line = txtNames.Lines[i];
                    // if (line != "")
                    //{
                    namesTemp.Add(line);
                    //}

                }
                data.names = namesTemp;
                List<string> targetsTemp = new List<string>();
                for (int i = 0; i < txtTarget.Lines.Length; i++)
                {
                    string line = txtTarget.Lines[i];
                    // if (line != "")
                    // {
                    targetsTemp.Add(line);
                    // }
                }
                data.targets = targetsTemp;
                data.IntilaiseAllStudentRecords();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter student names");
            }
            
        }

        private void txtNames_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
