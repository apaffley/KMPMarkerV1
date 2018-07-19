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
    public partial class frmFonts : Form
    {
        fontSizes allSizes;
        public frmFonts(fontSizes inFont)
        {
            InitializeComponent();
            allSizes = inFont;
        }

        private void frmFonts_Load(object sender, EventArgs e)
        {
            txtWWWList.Text = allSizes.wwwList.ToString();
            txtTIFList.Text = allSizes.tifList.ToString();
            txtComments.Text = allSizes.comments.ToString();
            txtTIFs.Text = allSizes.tifComments.ToString();
            txtStudents.Text = allSizes.studentNames.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                allSizes.wwwList = float.Parse(txtWWWList.Text);
                allSizes.tifList = float.Parse(txtTIFList.Text);
                allSizes.comments = float.Parse(txtComments.Text);
                allSizes.tifComments = float.Parse(txtTIFs.Text);
                allSizes.studentNames = float.Parse(txtStudents.Text);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error, these are not valid font sizes. Try again.", "Error!", MessageBoxButtons.OK);
            }
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            float wwwListS = float.Parse(txtWWWList.Text);
            wwwListS++;
            float tifListS = float.Parse(txtTIFList.Text);
            tifListS++;
            float commentsS = float.Parse(txtComments.Text);
            commentsS++;
            float TIFCommentS = float.Parse(txtTIFs.Text);
            TIFCommentS++;
            float StudentsS = float.Parse(txtStudents.Text);
            StudentsS++;

            txtWWWList.Text = wwwListS.ToString();
            txtTIFList.Text = tifListS.ToString();
            txtComments.Text = commentsS.ToString();
            txtTIFs.Text = TIFCommentS.ToString();
            txtStudents.Text = StudentsS.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            float wwwListS = float.Parse(txtWWWList.Text);
            wwwListS--;
            float tifListS = float.Parse(txtTIFList.Text);
            tifListS--;
            float commentsS = float.Parse(txtComments.Text);
            commentsS--;
            float TIFCommentS = float.Parse(txtTIFs.Text);
            TIFCommentS--;
            float StudentsS = float.Parse(txtStudents.Text);
            StudentsS--;

            txtWWWList.Text = wwwListS.ToString();
            txtTIFList.Text = tifListS.ToString();
            txtComments.Text = commentsS.ToString();
            txtTIFs.Text = TIFCommentS.ToString();
            txtStudents.Text = StudentsS.ToString();
        }
    }
}
