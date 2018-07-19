namespace KMPMakerC
{
    partial class Range
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
            this.lblMax = new System.Windows.Forms.Label();
            this.selectin = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Print KMP Range:";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(12, 37);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(33, 13);
            this.lblMax.TabIndex = 1;
            this.lblMax.Text = "Max: ";
            // 
            // selectin
            // 
            this.selectin.AutoSize = true;
            this.selectin.Location = new System.Drawing.Point(12, 64);
            this.selectin.Name = "selectin";
            this.selectin.Size = new System.Drawing.Size(54, 13);
            this.selectin.TabIndex = 2;
            this.selectin.Text = "Selection:";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(72, 61);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(56, 20);
            this.txtMin.TabIndex = 3;
            this.txtMin.TextChanged += new System.EventHandler(this.txtMin_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "to";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(157, 61);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(56, 20);
            this.txtMax.TabIndex = 5;
            this.txtMax.TextChanged += new System.EventHandler(this.txtMax_TextChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 97);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(97, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print Selection";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(115, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Range
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 132);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.selectin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.label1);
            this.Name = "Range";
            this.Text = "Range";
            this.Load += new System.EventHandler(this.Range_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label selectin;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
    }
}