namespace KMPMakerC
{
    partial class frmIntlStudents
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
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtNames = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(235, 22);
            this.txtTarget.Multiline = true;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(104, 490);
            this.txtTarget.TabIndex = 8;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(232, 6);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Target:";
            // 
            // txtNames
            // 
            this.txtNames.Location = new System.Drawing.Point(12, 22);
            this.txtNames.Multiline = true;
            this.txtNames.Name = "txtNames";
            this.txtNames.Size = new System.Drawing.Size(213, 490);
            this.txtNames.TabIndex = 6;
            this.txtNames.TextChanged += new System.EventHandler(this.txtNames_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Names:";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(15, 545);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 9;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // frmIntlStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 580);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtNames);
            this.Controls.Add(this.Label1);
            this.Name = "frmIntlStudents";
            this.Text = "Initialise Students";
            this.Load += new System.EventHandler(this.frmStudents_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtTarget;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtNames;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnDone;
    }
}