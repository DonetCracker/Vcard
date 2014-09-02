namespace warpiton
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.datanumbers = new System.Windows.Forms.DataGridView();
            this.numbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prefixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preferDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.numberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataemail = new System.Windows.Forms.DataGridView();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prfixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preferedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.emailbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pemailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csvcardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datanumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataemail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailbBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csvcardBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.formNameDataGridViewTextBoxColumn,
            this.pemailDataGridViewTextBoxColumn,
            this.pnumberDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.csvcardBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(580, 160);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 202);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 84);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // datanumbers
            // 
            this.datanumbers.AutoGenerateColumns = false;
            this.datanumbers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datanumbers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datanumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datanumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numbDataGridViewTextBoxColumn,
            this.prefixDataGridViewTextBoxColumn,
            this.preferDataGridViewCheckBoxColumn});
            this.datanumbers.DataSource = this.numberBindingSource;
            this.datanumbers.Location = new System.Drawing.Point(12, 309);
            this.datanumbers.Name = "datanumbers";
            this.datanumbers.RowHeadersVisible = false;
            this.datanumbers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.datanumbers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datanumbers.Size = new System.Drawing.Size(259, 150);
            this.datanumbers.TabIndex = 2;
            // 
            // numbDataGridViewTextBoxColumn
            // 
            this.numbDataGridViewTextBoxColumn.DataPropertyName = "Numb";
            this.numbDataGridViewTextBoxColumn.HeaderText = "Numb";
            this.numbDataGridViewTextBoxColumn.Name = "numbDataGridViewTextBoxColumn";
            this.numbDataGridViewTextBoxColumn.Width = 60;
            // 
            // prefixDataGridViewTextBoxColumn
            // 
            this.prefixDataGridViewTextBoxColumn.DataPropertyName = "Prefix";
            this.prefixDataGridViewTextBoxColumn.HeaderText = "Prefix";
            this.prefixDataGridViewTextBoxColumn.Name = "prefixDataGridViewTextBoxColumn";
            this.prefixDataGridViewTextBoxColumn.Width = 58;
            // 
            // preferDataGridViewCheckBoxColumn
            // 
            this.preferDataGridViewCheckBoxColumn.DataPropertyName = "Prefer";
            this.preferDataGridViewCheckBoxColumn.HeaderText = "Prefer";
            this.preferDataGridViewCheckBoxColumn.Name = "preferDataGridViewCheckBoxColumn";
            this.preferDataGridViewCheckBoxColumn.Width = 41;
            // 
            // numberBindingSource
            // 
            this.numberBindingSource.DataSource = typeof(warpiton.Csvcard.Number);
            // 
            // dataemail
            // 
            this.dataemail.AutoGenerateColumns = false;
            this.dataemail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataemail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataemail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataemail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emailDataGridViewTextBoxColumn,
            this.prfixDataGridViewTextBoxColumn,
            this.preferedDataGridViewCheckBoxColumn});
            this.dataemail.DataSource = this.emailbBindingSource;
            this.dataemail.Location = new System.Drawing.Point(291, 309);
            this.dataemail.Name = "dataemail";
            this.dataemail.RowHeadersVisible = false;
            this.dataemail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataemail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataemail.Size = new System.Drawing.Size(277, 150);
            this.dataemail.TabIndex = 3;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 57;
            // 
            // prfixDataGridViewTextBoxColumn
            // 
            this.prfixDataGridViewTextBoxColumn.DataPropertyName = "Prfix";
            this.prfixDataGridViewTextBoxColumn.HeaderText = "Prfix";
            this.prfixDataGridViewTextBoxColumn.Name = "prfixDataGridViewTextBoxColumn";
            this.prfixDataGridViewTextBoxColumn.Width = 52;
            // 
            // preferedDataGridViewCheckBoxColumn
            // 
            this.preferedDataGridViewCheckBoxColumn.DataPropertyName = "Prefered";
            this.preferedDataGridViewCheckBoxColumn.HeaderText = "Prefered";
            this.preferedDataGridViewCheckBoxColumn.Name = "preferedDataGridViewCheckBoxColumn";
            this.preferedDataGridViewCheckBoxColumn.Width = 53;
            // 
            // emailbBindingSource
            // 
            this.emailbBindingSource.DataSource = typeof(warpiton.Csvcard.Emailb);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Emails";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Numbers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Photo:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(580, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // formNameDataGridViewTextBoxColumn
            // 
            this.formNameDataGridViewTextBoxColumn.DataPropertyName = "FormName";
            this.formNameDataGridViewTextBoxColumn.HeaderText = "FormName";
            this.formNameDataGridViewTextBoxColumn.Name = "formNameDataGridViewTextBoxColumn";
            this.formNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pemailDataGridViewTextBoxColumn
            // 
            this.pemailDataGridViewTextBoxColumn.DataPropertyName = "Pemail";
            this.pemailDataGridViewTextBoxColumn.HeaderText = "Pemail";
            this.pemailDataGridViewTextBoxColumn.Name = "pemailDataGridViewTextBoxColumn";
            this.pemailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pnumberDataGridViewTextBoxColumn
            // 
            this.pnumberDataGridViewTextBoxColumn.DataPropertyName = "Pnumber";
            this.pnumberDataGridViewTextBoxColumn.HeaderText = "Pnumber";
            this.pnumberDataGridViewTextBoxColumn.Name = "pnumberDataGridViewTextBoxColumn";
            this.pnumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // csvcardBindingSource
            // 
            this.csvcardBindingSource.DataSource = typeof(warpiton.Csvcard);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 471);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataemail);
            this.Controls.Add(this.datanumbers);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datanumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataemail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailbBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csvcardBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn formNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pemailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource csvcardBindingSource;
        private System.Windows.Forms.DataGridView datanumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn numbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prefixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn preferDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource numberBindingSource;
        private System.Windows.Forms.DataGridView dataemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prfixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn preferedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource emailbBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

