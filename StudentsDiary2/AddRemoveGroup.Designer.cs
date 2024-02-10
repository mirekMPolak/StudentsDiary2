namespace StudentsDiary
{
    partial class AddRemoveGroup
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
            this.dgvGroupNames = new System.Windows.Forms.DataGridView();
            this.btnAddNewGroup = new System.Windows.Forms.Button();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupNames)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGroupNames
            // 
            this.dgvGroupNames.AllowUserToAddRows = false;
            this.dgvGroupNames.AllowUserToDeleteRows = false;
            this.dgvGroupNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroupNames.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvGroupNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupNames.Location = new System.Drawing.Point(12, 12);
            this.dgvGroupNames.Name = "dgvGroupNames";
            this.dgvGroupNames.ReadOnly = true;
            this.dgvGroupNames.RowHeadersVisible = false;
            this.dgvGroupNames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroupNames.Size = new System.Drawing.Size(204, 281);
            this.dgvGroupNames.TabIndex = 0;
            // 
            // btnAddNewGroup
            // 
            this.btnAddNewGroup.Location = new System.Drawing.Point(12, 325);
            this.btnAddNewGroup.Name = "btnAddNewGroup";
            this.btnAddNewGroup.Size = new System.Drawing.Size(85, 23);
            this.btnAddNewGroup.TabIndex = 1;
            this.btnAddNewGroup.Text = "Dodaj grupę:";
            this.btnAddNewGroup.UseVisualStyleBackColor = true;
            this.btnAddNewGroup.Click += new System.EventHandler(this.btnAddNewGroup_Click);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Location = new System.Drawing.Point(12, 387);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveGroup.TabIndex = 2;
            this.btnRemoveGroup.Text = "Usuń grupę";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(103, 325);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(113, 20);
            this.tbGroupName.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(141, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AddRemoveGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 430);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbGroupName);
            this.Controls.Add(this.btnRemoveGroup);
            this.Controls.Add(this.btnAddNewGroup);
            this.Controls.Add(this.dgvGroupNames);
            this.MaximumSize = new System.Drawing.Size(244, 469);
            this.MinimumSize = new System.Drawing.Size(244, 469);
            this.Name = "AddRemoveGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupy";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupNames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGroupNames;
        private System.Windows.Forms.Button btnAddNewGroup;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Button btnClose;
    }
}