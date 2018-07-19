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
    public partial class Range : Form
    {
        KMPControl control;
        allData data;
        public Range(KMPControl inControl)
        {
            control = inControl;
            data = control.GetKMP();
            InitializeComponent();
        }

        private void Range_Load(object sender, EventArgs e)
        {
            lblMax.Text = "Max: " + data.NumberOfRecords.ToString();
            
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in txtMin.Text.ToCharArray())
            {
                try
                {
                    if (int.Parse(txtMin.Text) < 1)
                    {
                        MessageBox.Show("Selection cannot be less than 1");
                        txtMin.Clear();
                    }
                    if (Char.IsNumber(c))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Sorry, invalid value");
                        txtMin.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Sorry, invalid value");
                    txtMin.Clear();
                }
            }
        }

        private void txtMax_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in txtMax.Text.ToCharArray())
            {
                try
                {
                    if (int.Parse(txtMax.Text) > data.NumberOfRecords)
                    {
                        MessageBox.Show("Selection cannot be larger than " + data.NumberOfRecords.ToString() + "." );
                        txtMax.Clear();
                    }
                    if (Char.IsNumber(c))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Sorry, invalid value");
                        txtMax.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Sorry, invalid value");
                    txtMax.Clear();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                control.PrintRange(int.Parse(txtMin.Text), int.Parse(txtMax.Text));
                Close();
            }
            catch
            {
                MessageBox.Show("Please enter a valid range to print.");
            }

        }
    }
}
