namespace GESTION_CAISSE.IHM
{
    partial class Form_Approvision
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Approvision));
            this.dgv_approvision = new System.Windows.Forms.DataGridView();
            this.idMouv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articleMouv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qteMouv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_approvision)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_approvision
            // 
            this.dgv_approvision.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv_approvision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_approvision.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMouv,
            this.articleMouv,
            this.qteMouv});
            this.dgv_approvision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_approvision.Location = new System.Drawing.Point(0, 0);
            this.dgv_approvision.MultiSelect = false;
            this.dgv_approvision.Name = "dgv_approvision";
            this.dgv_approvision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_approvision.Size = new System.Drawing.Size(446, 261);
            this.dgv_approvision.TabIndex = 0;
            // 
            // idMouv
            // 
            this.idMouv.HeaderText = "ID";
            this.idMouv.Name = "idMouv";
            this.idMouv.Visible = false;
            // 
            // articleMouv
            // 
            this.articleMouv.HeaderText = "Article";
            this.articleMouv.Name = "articleMouv";
            this.articleMouv.ReadOnly = true;
            this.articleMouv.Width = 200;
            // 
            // qteMouv
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.qteMouv.DefaultCellStyle = dataGridViewCellStyle1;
            this.qteMouv.HeaderText = "Quantité";
            this.qteMouv.Name = "qteMouv";
            this.qteMouv.ReadOnly = true;
            // 
            // Form_Approvision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 261);
            this.Controls.Add(this.dgv_approvision);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Approvision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Approvision";
            this.Load += new System.EventHandler(this.Form_Approvision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_approvision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_approvision;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMouv;
        private System.Windows.Forms.DataGridViewTextBoxColumn articleMouv;
        private System.Windows.Forms.DataGridViewTextBoxColumn qteMouv;
    }
}