namespace GetKeyMakeCloneFacebookApp.Views
{
    partial class frmAddKey
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudcount = new System.Windows.Forms.NumericUpDown();
            this.chbactive = new System.Windows.Forms.CheckBox();
            this.chbforver = new System.Windows.Forms.CheckBox();
            this.nudmonth = new System.Windows.Forms.NumericUpDown();
            this.BtnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudmonth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Key:";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(63, 10);
            this.tbKey.Name = "tbKey";
            this.tbKey.ReadOnly = true;
            this.tbKey.Size = new System.Drawing.Size(309, 20);
            this.tbKey.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "MonthCount:";
            // 
            // nudcount
            // 
            this.nudcount.Location = new System.Drawing.Point(63, 36);
            this.nudcount.Name = "nudcount";
            this.nudcount.Size = new System.Drawing.Size(108, 20);
            this.nudcount.TabIndex = 2;
            // 
            // chbactive
            // 
            this.chbactive.AutoSize = true;
            this.chbactive.Location = new System.Drawing.Point(63, 64);
            this.chbactive.Name = "chbactive";
            this.chbactive.Size = new System.Drawing.Size(67, 17);
            this.chbactive.TabIndex = 3;
            this.chbactive.Text = "Is Active";
            this.chbactive.UseVisualStyleBackColor = true;
            // 
            // chbforver
            // 
            this.chbforver.AutoSize = true;
            this.chbforver.Location = new System.Drawing.Point(254, 62);
            this.chbforver.Name = "chbforver";
            this.chbforver.Size = new System.Drawing.Size(106, 17);
            this.chbforver.TabIndex = 3;
            this.chbforver.Text = "Is Active Forever";
            this.chbforver.UseVisualStyleBackColor = true;
            // 
            // nudmonth
            // 
            this.nudmonth.Location = new System.Drawing.Point(252, 36);
            this.nudmonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudmonth.Name = "nudmonth";
            this.nudmonth.Size = new System.Drawing.Size(120, 20);
            this.nudmonth.TabIndex = 2;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(291, 85);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(81, 30);
            this.BtnOk.TabIndex = 4;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // frmAddKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 126);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.chbforver);
            this.Controls.Add(this.chbactive);
            this.Controls.Add(this.nudmonth);
            this.Controls.Add(this.nudcount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(412, 165);
            this.MinimumSize = new System.Drawing.Size(412, 165);
            this.Name = "frmAddKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddKey";
            ((System.ComponentModel.ISupportInitialize)(this.nudcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudmonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudcount;
        private System.Windows.Forms.CheckBox chbactive;
        private System.Windows.Forms.CheckBox chbforver;
        private System.Windows.Forms.NumericUpDown nudmonth;
        private System.Windows.Forms.Button BtnOk;
    }
}