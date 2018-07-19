namespace KMPMakerC
{
    partial class frmViewResults
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
            this.btnDone = new System.Windows.Forms.Button();
            this.txtNames = new System.Windows.Forms.TextBox();
            this.txtGrades = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(318, 521);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // txtNames
            // 
            this.txtNames.Location = new System.Drawing.Point(12, 12);
            this.txtNames.Multiline = true;
            this.txtNames.Name = "txtNames";
            this.txtNames.Size = new System.Drawing.Size(275, 494);
            this.txtNames.TabIndex = 2;
            // 
            // txtGrades
            // 
            this.txtGrades.Location = new System.Drawing.Point(293, 12);
            this.txtGrades.Multiline = true;
            this.txtGrades.Name = "txtGrades";
            this.txtGrades.Size = new System.Drawing.Size(100, 494);
            this.txtGrades.TabIndex = 3;
            // 
            // frmViewResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 556);
            this.Controls.Add(this.txtGrades);
            this.Controls.Add(this.txtNames);
            this.Controls.Add(this.btnDone);
            this.Name = "frmViewResults";
            this.Text = "View Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox txtNames;
        private System.Windows.Forms.TextBox txtGrades;
    }
}