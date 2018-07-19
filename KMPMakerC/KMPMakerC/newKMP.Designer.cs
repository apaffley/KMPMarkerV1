namespace KMPMakerC
{
    partial class newKMP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtKMPName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTeacherName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCovered1 = new System.Windows.Forms.TextBox();
            this.txtCovered2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFacultyName = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "KMP Name:";
            // 
            // txtKMPName
            // 
            this.txtKMPName.Location = new System.Drawing.Point(99, 9);
            this.txtKMPName.Name = "txtKMPName";
            this.txtKMPName.Size = new System.Drawing.Size(298, 20);
            this.txtKMPName.TabIndex = 1;
            this.txtKMPName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKMPName_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 220);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Teacher Name:";
            // 
            // txtTeacherName
            // 
            this.txtTeacherName.Location = new System.Drawing.Point(99, 35);
            this.txtTeacherName.Name = "txtTeacherName";
            this.txtTeacherName.Size = new System.Drawing.Size(298, 20);
            this.txtTeacherName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Topics Covered 1:";
            // 
            // txtCovered1
            // 
            this.txtCovered1.Location = new System.Drawing.Point(99, 61);
            this.txtCovered1.Name = "txtCovered1";
            this.txtCovered1.Size = new System.Drawing.Size(298, 20);
            this.txtCovered1.TabIndex = 3;
            // 
            // txtCovered2
            // 
            this.txtCovered2.Location = new System.Drawing.Point(99, 87);
            this.txtCovered2.Name = "txtCovered2";
            this.txtCovered2.Size = new System.Drawing.Size(298, 20);
            this.txtCovered2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Topics Covered 2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Faculty Name:";
            // 
            // txtFacultyName
            // 
            this.txtFacultyName.Location = new System.Drawing.Point(99, 114);
            this.txtFacultyName.Name = "txtFacultyName";
            this.txtFacultyName.Size = new System.Drawing.Size(298, 20);
            this.txtFacultyName.TabIndex = 5;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(457, 34);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 6;
            //this.monthCalendar1.TodayDate = new System.DateTime(((long)(0)));
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Select Date:";
            // 
            // newKMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 255);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.txtFacultyName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCovered2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCovered1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTeacherName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtKMPName);
            this.Controls.Add(this.label1);
            this.Name = "newKMP";
            this.Text = "New KMP";
            this.Load += new System.EventHandler(this.newKMP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKMPName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTeacherName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCovered1;
        private System.Windows.Forms.TextBox txtCovered2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFacultyName;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label6;
    }
}