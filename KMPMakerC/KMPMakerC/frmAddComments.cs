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
    public partial class frmAddComments : Form
    {
        allData data;

        public frmAddComments(allData inData)
        {
            InitializeComponent();
            data = inData;
            try
            {
                foreach (string s in data.comments)
                {
                    chkComments.Items.Add(s);
                }
                foreach (string s in data.TIFs)
                {
                    chkTIF.Items.Add(s);
                }
            }
            catch
            {

            }
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if (TXTComment.Text != "")
            {
                if(TXTComment.Text[TXTComment.TextLength-1] != '.')
                {
                    TXTComment.Text = TXTComment.Text + ".";
                }
                chkComments.Items.Add(TXTComment.Text);

                if (chkBoxRememberComment.Checked == false)
                {
                    TXTComment.Text = "";
                }
            }
                else
            {
                    MessageBox.Show("You have not typed anything in!", "Comment Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            TXTComment.Focus();
        }

        private void btnAddTIF_Click(object sender, EventArgs e)
        {
            if (txtTIF.Text != "")
            {
                if (txtTIF.Text[txtTIF.TextLength - 1] != '.')
                {
                    txtTIF.Text = txtTIF.Text + ".";
                }
                chkTIF.Items.Add(txtTIF.Text);
                if (chkBoxRememberTIF.Checked == false)
                {
                    txtTIF.Text = "";
                }
            }
            else
            {
                MessageBox.Show("You have not typed anything in!", "TIF Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtTIF.Focus();
        }

        private void btnRemoveComment_Click(object sender, EventArgs e)
        {
            while (chkComments.CheckedItems.Count > 0)
            {
                chkComments.Items.Remove(chkComments.CheckedItems[0]);
            }


        }

        private void btnRemoveTIF_Click(object sender, EventArgs e)
        {
            while (chkTIF.CheckedItems.Count > 0)
            {
                chkTIF.Items.Remove(chkTIF.CheckedItems[0]);
            }
        }

        private void frmAddComments_Load(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            List<string> tempComments = new List<string>();
            List<string> tempTIFs = new List<string>();
            for (int i = 0; i < chkComments.Items.Count; i++)
            {
                //Console.WriteLine(chkComments.Items[i].ToString());
                tempComments.Add(chkComments.Items[i].ToString());
            }
            for (int i = 0; i < chkTIF.Items.Count; i++)
            {
                //Console.WriteLine(chkTIF.Items[i].ToString());
                tempTIFs.Add(chkTIF.Items[i].ToString());
            }
            data.comments = tempComments;
            data.TIFs = tempTIFs;
            this.Close();
        }
    }
}
