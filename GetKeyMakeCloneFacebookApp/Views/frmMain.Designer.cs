namespace GetKeyMakeCloneFacebookApp.Views
{
    partial class frmMain
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
            this.gv_data = new System.Windows.Forms.DataGridView();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnActive = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeforever = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthcount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_data
            // 
            this.gv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.key,
            this.count,
            this.activeforever,
            this.monthcount,
            this.actived});
            this.gv_data.Location = new System.Drawing.Point(12, 35);
            this.gv_data.MultiSelect = false;
            this.gv_data.Name = "gv_data";
            this.gv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_data.Size = new System.Drawing.Size(699, 335);
            this.gv_data.TabIndex = 0;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(636, 389);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 34);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnActive
            // 
            this.BtnActive.Location = new System.Drawing.Point(93, 389);
            this.BtnActive.Name = "BtnActive";
            this.BtnActive.Size = new System.Drawing.Size(75, 34);
            this.BtnActive.TabIndex = 1;
            this.BtnActive.Text = "Acitve";
            this.BtnActive.UseVisualStyleBackColor = true;
            this.BtnActive.Click += new System.EventHandler(this.BtnActive_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(12, 389);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 34);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // key
            // 
            this.key.HeaderText = "Key";
            this.key.Name = "key";
            this.key.ReadOnly = true;
            this.key.Width = 230;
            // 
            // count
            // 
            this.count.HeaderText = "Count";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // activeforever
            // 
            this.activeforever.HeaderText = "Active Forever";
            this.activeforever.Name = "activeforever";
            this.activeforever.ReadOnly = true;
            // 
            // monthcount
            // 
            this.monthcount.HeaderText = "Month Count";
            this.monthcount.Name = "monthcount";
            this.monthcount.ReadOnly = true;
            // 
            // actived
            // 
            this.actived.HeaderText = "Actived";
            this.actived.Name = "actived";
            this.actived.ReadOnly = true;
            // 
            // BtnCopy
            // 
            this.BtnCopy.Location = new System.Drawing.Point(174, 389);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(75, 34);
            this.BtnCopy.TabIndex = 1;
            this.BtnCopy.Text = "Copy Key";
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 450);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.BtnActive);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.gv_data);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_data;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnActive;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn key;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn activeforever;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthcount;
        private System.Windows.Forms.DataGridViewTextBoxColumn actived;
        private System.Windows.Forms.Button BtnCopy;
    }
}