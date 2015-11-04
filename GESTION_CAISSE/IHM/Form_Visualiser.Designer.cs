namespace GESTION_CAISSE.IHM
{
    partial class Form_Visualiser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Visualiser));
            this.report_etat = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // report_etat
            // 
            this.report_etat.ActiveViewIndex = -1;
            this.report_etat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.report_etat.Cursor = System.Windows.Forms.Cursors.Default;
            this.report_etat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.report_etat.Location = new System.Drawing.Point(0, 0);
            this.report_etat.Name = "report_etat";
            this.report_etat.Size = new System.Drawing.Size(1021, 559);
            this.report_etat.TabIndex = 0;
            // 
            // Form_Visualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 559);
            this.Controls.Add(this.report_etat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Visualiser";
            this.Text = "Form_Visualiser";
            this.Load += new System.EventHandler(this.Form_Visualiser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer report_etat;

    }
}