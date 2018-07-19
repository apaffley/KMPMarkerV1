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
    public partial class frmViewResults : Form
    {
        KMPControl control;
        allData data;
        public frmViewResults(KMPControl inControl)
        {
            control = inControl;
            data = control.GetKMP();
            InitializeComponent();
            AddNamesAndGrades();
        }

        private void AddNamesAndGrades()
        {
            foreach (FeedbackData d in data.AllFeedBackData)
            {
                txtNames.Text = txtNames.Text + d.studentName + Environment.NewLine;
            }
            foreach (FeedbackData d in data.AllFeedBackData)
            {
                txtGrades.Text = txtGrades.Text + d.acheivedGrade + Environment.NewLine; ;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
