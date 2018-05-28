namespace MakeCloneFacebookApp.Views
{
    partial class frm_main
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbuser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_pass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.tb_sendm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_count = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "hành động";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "user:";
            // 
            // tbuser
            // 
            this.tbuser.Location = new System.Drawing.Point(273, 117);
            this.tbuser.Name = "tbuser";
            this.tbuser.Size = new System.Drawing.Size(301, 20);
            this.tbuser.TabIndex = 1;
            this.tbuser.Text = "boycodon9x2007@gmail.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "pass:";
            // 
            // tb_pass
            // 
            this.tb_pass.Location = new System.Drawing.Point(273, 143);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.Size = new System.Drawing.Size(301, 20);
            this.tb_pass.TabIndex = 2;
            this.tb_pass.Text = "Hh01218314076";
            this.tb_pass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "post wall message:";
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(273, 169);
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(301, 20);
            this.tb_message.TabIndex = 3;
            this.tb_message.Text = "post test thoi";
            // 
            // tb_sendm
            // 
            this.tb_sendm.Location = new System.Drawing.Point(273, 195);
            this.tb_sendm.Name = "tb_sendm";
            this.tb_sendm.Size = new System.Drawing.Size(188, 20);
            this.tb_sendm.TabIndex = 4;
            this.tb_sendm.Text = "send test thoi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "send message:";
            // 
            // tb_count
            // 
            this.tb_count.Location = new System.Drawing.Point(527, 195);
            this.tb_count.Name = "tb_count";
            this.tb_count.Size = new System.Drawing.Size(47, 20);
            this.tb_count.TabIndex = 5;
            this.tb_count.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(467, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "count:";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_count);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_sendm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_pass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbuser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "frm_main";
            this.Text = "frm_main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbuser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_pass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.TextBox tb_sendm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_count;
        private System.Windows.Forms.Label label5;
    }
}