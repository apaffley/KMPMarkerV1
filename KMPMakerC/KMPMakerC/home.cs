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
    public partial class home : Form
    {
        allData data;
        KMPControl control;
        FeedbackData currentRecord;
        private bool formEnabled = false;
        private void SetUpKMPForm()
        {


                data = control.GetCurrentKMP();
                currentRecord = data.GetCurrentRecord();
                if (currentRecord.studentName != "do not use")
                {

                
                txtKMPName.Text = data.assignmentName;
                EnableDisableForm(true);
                PopulateStudentFeedbackData();
                SetUpComments();
                txtTeacher.Text = data.teacherName;
                txtFaculty.Text = data.facultyName;
                txtCovered1.Text = data.topicsCovered[0];
                txtCovered2.Text = data.topicsCovered[1];
                monthCalendar1.SetDate(data.dateOfKMP);
                int record = data.CurrentIndex + 1;
                lblRecordNo.Text = "Record No. " + record.ToString(); 
            }
            else
            {
                EnableDisableForm(false);
            }
        }
        private void PopulateStudentFeedbackData()
        {

            txtComments.Text = currentRecord.feedbackWWWs;
            txtTIF.Text = currentRecord.feedbackTIFs;
            lblNameHolder.Text = currentRecord.studentName;
            lblTarget.Text = currentRecord.targetGrade;
            txtEffort.Text = currentRecord.effortGrade;
            txtGrade.Text = currentRecord.acheivedGrade;
            int record = data.CurrentIndex + 1;
            lblRecordNo.Text = "Record No. " + record.ToString();
            lstStudents.Items.Clear();
            foreach (FeedbackData d in data.AllFeedBackData)
            {
                lstStudents.Items.Add(d.studentName);
            }
        }
        private void EnableDisableForm(bool choice)
        {
            if (choice == false)
            {
                kmpBox.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                commentsToolStripMenuItem.Enabled = false;
                studentsToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                formEnabled = false;
                exportCommentBankToolStripMenuItem.Enabled = false;
                importCommentBankToolStripMenuItem.Enabled = false;
                printKMPsToolStripMenuItem.Enabled = false;
                exportKMPToolStripMenuItem.Enabled = false;
                resultsToolStripMenuItem.Enabled = false;
                changeFontSizesToolStripMenuItem.Enabled = false;
            }
            else
            {
                kmpBox.Enabled = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                commentsToolStripMenuItem.Enabled = true;
                studentsToolStripMenuItem.Enabled = true;
                formEnabled = true;
                exportCommentBankToolStripMenuItem.Enabled = true;
                importCommentBankToolStripMenuItem.Enabled = true;
                printKMPsToolStripMenuItem.Enabled = true;
                exportKMPToolStripMenuItem.Enabled = true;
                resultsToolStripMenuItem.Enabled = true;
                changeFontSizesToolStripMenuItem.Enabled = true;
            }
        }
        private void SetUpComments()
        {
            try
            {
                commentsBox.Items.Clear();
                tifsBox.Items.Clear();
                foreach (string s in data.comments)
                {
                    commentsBox.Items.Add(s);

                }
                foreach (string s in data.TIFs)
                {
                    tifsBox.Items.Add(s);
                }
            }
            catch
            {

            }
        }
        public home(KMPControl inControl)
        {
            control = inControl;
            InitializeComponent();
            EnableDisableForm(false);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            
        }

        private void commentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddComments form1 = new frmAddComments(data);
            form1.ShowDialog();
            SetUpComments();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditStudents f = new frmEditStudents(control);
            f.ShowDialog();
            currentRecord = data.GetCurrentRecord();
            PopulateStudentFeedbackData();

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool result = control.SaveKMPFileAs();
            if (result == true)
            {
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
            }
        }

        private void exportCommentBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data != null)
            {
                if (data.comments.Count == 0 && data.TIFs.Count == 0)
                {
                    MessageBox.Show("No data to export.");
                }
                else
                {
                    control.ExportCommentsTXT();
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
             bool doNew = true;
            if (formEnabled == true)
            {
               
                    if (control.AlreadySaved == true)
                    {
                        DialogResult result = MessageBox.Show("Would you like to save?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (control.SaveKMP() == true)
                            {

                            }
                            else
                            {
                                MessageBox.Show("Save Failed");
                            }
                        }
                        else if (result == DialogResult.No)
                        {
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            doNew = false;
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Would you like to save?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            SaveFileDialog saveFileD = new SaveFileDialog();
                            saveFileD.Filter = "KMP files (*.kmp)|*.kmp";
                            if (saveFileD.ShowDialog() == DialogResult.OK)
                            {
                                bool saveResult = control.OpenKMP(saveFileD.FileName);
                                if (saveResult == true)
                                {
                                    saveAsToolStripMenuItem.Enabled = true;
                                    saveToolStripMenuItem.Enabled = true;

                                }
                            }
                        }
                        else if (result == DialogResult.No)
                        {
                        }
 
                    }
                }
            if (doNew == true)
            {
                newKMP CreateKMP = new newKMP(control);
                CreateKMP.ShowDialog();
                SetUpKMPForm();
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtComments.Clear();
            txtTIF.Clear();
            txtGrade.Clear();
            txtEffort.Clear();
        }

        private void txtKMPName_Leave(object sender, EventArgs e)
        {
            if (txtKMPName.Text == "")
            {
                MessageBox.Show("The assignment name cannot be blank");
                txtKMPName.Focus();
            }
        }

        private void btnAddComments_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < commentsBox.CheckedItems.Count; i++)
            
            {
                txtComments.Text = txtComments.Text + commentsBox.CheckedItems[i].ToString() + " ";
                
            }
            for (int i = 0; i < commentsBox.Items.Count; i++)
            {
                commentsBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            
        }

        private void btnAddTIFs_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tifsBox.CheckedItems.Count; i++)
            {
                txtTIF.Text = txtTIF.Text + tifsBox.CheckedItems[i].ToString() + " ";
            }
            for (int i = 0; i < tifsBox.Items.Count; i++)
            {
                tifsBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void btnAddBoth_Click(object sender, EventArgs e)
        {
            btnAddComments_Click(this, new EventArgs());
            btnAddTIFs_Click(this, new EventArgs());

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ReturnFeedbackToRecord();
            currentRecord = data.GetNextRecord();
            PopulateStudentFeedbackData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ReturnFeedbackToRecord();
            currentRecord = data.GetPreviousRecord();
            PopulateStudentFeedbackData();
        }

        private void UpdateCurrentRecordData()
        {
            currentRecord.feedbackTIFs = txtTIF.Text;
            currentRecord.feedbackWWWs = txtComments.Text;
            currentRecord.acheivedGrade = txtGrade.Text;
            currentRecord.effortGrade = txtEffort.Text;
            currentRecord.facultyName = data.facultyName;
            currentRecord.studentName = lblNameHolder.Text;
            currentRecord.targetGrade = lblTarget.Text;
            currentRecord.topicNote = "";
            currentRecord.topicsCovered = data.topicsCovered.ToArray();
        }

        private void ReturnFeedbackToRecord()
        {
            UpdateCurrentRecordData();
            data.returnRecord(currentRecord);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileD = new OpenFileDialog();
            openFileD.Filter = "KMP files (*.kmp)|*.kmp";
            if (openFileD.ShowDialog() == DialogResult.OK)
            {
                bool result = control.OpenKMP(openFileD.FileName);
                if (result == true)
                {
                    saveAsToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    SetUpKMPForm();
                }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (control.AlreadySaved == true)
            {
                if (control.SaveKMP() == true)
                {

                }
                else
                {
                    MessageBox.Show("Save Failed");
                }
            }
        }

        private void txtKMPName_TextChanged(object sender, EventArgs e)
        {
            data.assignmentName = txtKMPName.Text;
            data.UpdateAllRecordsCoreData();
        }



        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formEnabled == true)
            {
                if (control.AlreadySaved == true)
                {
                    DialogResult result = MessageBox.Show("Would you like to save?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (control.SaveKMP() == true)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Save Failed");
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Would you like to save?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SaveFileDialog saveFileD = new SaveFileDialog();
                        saveFileD.Filter = "KMP files (*.kmp)|*.kmp";
                        if (saveFileD.ShowDialog() == DialogResult.OK)
                        {
                            bool saveResult = control.OpenKMP(saveFileD.FileName);
                            if (saveResult == true)
                            {
                                saveAsToolStripMenuItem.Enabled = true;
                                saveToolStripMenuItem.Enabled = true;
                                SetUpKMPForm();
                            }
                        }
                        
                    }
                    else if (result == DialogResult.No)
                    {
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void importCommentBankToolStripMenuItem_Click(object sender, EventArgs e)
        {

                DialogResult importQ = MessageBox.Show("Would you like to append comments? No will overwrite!", "Append?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (importQ == DialogResult.Yes)
                {
                    control.OpenCommentsFromFile(true);
                }
                else
                {
                    control.OpenCommentsFromFile(false);
                }
            SetUpComments();


        }

        private void commentsBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
            {
                if (chkEnterBothSelect.Checked == true)
                {
                    btnAddTIFs_Click(this, new EventArgs());
                }
                btnAddComments_Click(this, new EventArgs());
            }

        }

        private void btnAddTIFs_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tifsBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
            {
                if (chkEnterBothSelect.Checked == true)
                {
                    btnAddComments_Click(this, new EventArgs());
                }
                btnAddTIFs_Click(this, new EventArgs());
            }
        }

        private void currentKMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control.PrintSingleKMP(data.GetCurrentRecord());
           
        }

        private void txtTeacher_TextChanged(object sender, EventArgs e)
        {
            data.teacherName = txtTeacher.Text;
            data.UpdateAllRecordsCoreData();
        }

        private void txtFaculty_TextChanged(object sender, EventArgs e)
        {
            data.facultyName = txtFaculty.Text;
            data.UpdateAllRecordsCoreData();
        }

        private void txtCovered1_TextChanged(object sender, EventArgs e)
        {
            data.topicsCovered[0] = txtCovered1.Text;
            data.UpdateAllRecordsCoreData();
        }

        private void txtCovered2_TextChanged(object sender, EventArgs e)
        {
            data.topicsCovered[1] = txtCovered2.Text;
            data.UpdateAllRecordsCoreData();
        }

        private void home_Load(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                data.dateOfKMP = monthCalendar1.SelectionStart;
                data.UpdateAllRecordsCoreData();
            }
            catch
                { }
        }

        private void allKMPsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control.PrintAllKMPs();
        }

        private void rangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Range r = new Range(control);
            r.ShowDialog();
        }

        private void printKMPsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportKMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control.ExportKMP();
        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            currentRecord.feedbackWWWs = txtComments.Text;
            data.returnRecord(currentRecord);
        }

        private void txtTIF_TextChanged(object sender, EventArgs e)
        {
            currentRecord.feedbackTIFs = txtTIF.Text;
            data.returnRecord(currentRecord);
        }

        private void txtGrade_TextChanged(object sender, EventArgs e)
        {
            currentRecord.acheivedGrade = txtGrade.Text;
            data.returnRecord(currentRecord);
        }

        private void txtEffort_TextChanged(object sender, EventArgs e)
        {
            currentRecord.effortGrade = txtEffort.Text;
            data.returnRecord(currentRecord);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            ReturnFeedbackToRecord();
            currentRecord = data.GetFirstRecord();
            PopulateStudentFeedbackData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            ReturnFeedbackToRecord();
            currentRecord = data.GetLastRecord();
            PopulateStudentFeedbackData();
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewResults f = new frmViewResults(control);
            f.ShowDialog();
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStudent = lstStudents.SelectedItem.ToString();
            ReturnFeedbackToRecord();
            currentRecord = data.GetFirstRecord();
            PopulateStudentFeedbackData();
            if (currentRecord.studentName == selectedStudent)
            {
                PopulateStudentFeedbackData();
            }
            else
            {
                for (int i = 0; i < data.names.Count; i++)
                {
                    ReturnFeedbackToRecord();
                    currentRecord = data.GetNextRecord();
                    PopulateStudentFeedbackData();
                    if(selectedStudent == currentRecord.studentName)
                    {
                        break;
                    }
                }
            }
        }

        private void changeFontSizesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontSizes formFonts = new fontSizes();
            Font f1 = commentsBox.Font;
            formFonts.wwwList = f1.Size;

            Font f2 = tifsBox.Font;
            formFonts.tifList = f2.Size;

            Font f3 = txtComments.Font;
            formFonts.comments = f3.Size;

            Font f4 = txtTIF.Font;
            formFonts.tifComments = f4.Size;

            Font f5 = lstStudents.Font;
            formFonts.studentNames = f5.Size;

            frmFonts form = new frmFonts(formFonts);
            form.ShowDialog();

            try
            {
                Font A1 = new Font(f1.Name, formFonts.wwwList);
                commentsBox.Font = A1;

                Font A2 = new Font(f2.Name, formFonts.tifList);
                tifsBox.Font = A2;
                
                Font A3 = new Font(f3.Name, formFonts.comments);
                txtComments.Font = A3;

                Font A4 = new Font(f4.Name, formFonts.tifComments);
                txtTIF.Font = A4;

                Font A5 = new Font(f5.Name, formFonts.studentNames);
                lstStudents.Font = A5;
                
            }
            catch
            {
                commentsBox.Font = f1;
                tifsBox.Font = f2;
                txtComments.Font = f3;
                txtTIF.Font = f4;
                lstStudents.Font = f5;
            }
        }

        private void tifsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class fontSizes
    {
        public float wwwList;
        public float tifList;
        public float comments;
        public float tifComments;
        public float studentNames;
    } 
}
