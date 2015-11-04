namespace GESTION_CAISSE.IHM
{
    partial class Form_Caisse_Mensualite
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Caisse_Mensualite));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_genere = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_mensualite = new System.Windows.Forms.DataGridView();
            this.idMensualite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateMensualite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtantMensualite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verseMensualite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resteMensualite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etatMensualite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outMensualite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.rbtn_no = new System.Windows.Forms.RadioButton();
            this.rbtn_yes = new System.Windows.Forms.RadioButton();
            this.com_mode = new System.Windows.Forms.ComboBox();
            this.txt_montant = new System.Windows.Forms.NumericUpDown();
            this.txt_numPiece = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_reglement = new System.Windows.Forms.DataGridView();
            this.idReglement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateReglement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtantReglement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeReglement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mensualite)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_montant)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reglement)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_genere);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Liste Mensualités";
            // 
            // btn_genere
            // 
            this.btn_genere.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_genere.Image = global::GESTION_CAISSE.Properties.Resources.cnr_not_connected;
            this.btn_genere.Location = new System.Drawing.Point(636, 11);
            this.btn_genere.Name = "btn_genere";
            this.btn_genere.Size = new System.Drawing.Size(35, 23);
            this.btn_genere.TabIndex = 1;
            this.btn_genere.UseVisualStyleBackColor = true;
            this.btn_genere.Click += new System.EventHandler(this.btn_genere_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_mensualite);
            this.panel1.Location = new System.Drawing.Point(6, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 153);
            this.panel1.TabIndex = 0;
            // 
            // dgv_mensualite
            // 
            this.dgv_mensualite.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv_mensualite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mensualite.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMensualite,
            this.dateMensualite,
            this.mtantMensualite,
            this.verseMensualite,
            this.resteMensualite,
            this.etatMensualite,
            this.outMensualite});
            this.dgv_mensualite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_mensualite.Location = new System.Drawing.Point(0, 0);
            this.dgv_mensualite.MultiSelect = false;
            this.dgv_mensualite.Name = "dgv_mensualite";
            this.dgv_mensualite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mensualite.Size = new System.Drawing.Size(665, 153);
            this.dgv_mensualite.TabIndex = 0;
            this.dgv_mensualite.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_mensualite_CellContentClick);
            this.dgv_mensualite.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_mensualite_RowsAdded);
            // 
            // idMensualite
            // 
            this.idMensualite.HeaderText = "ID";
            this.idMensualite.Name = "idMensualite";
            this.idMensualite.Visible = false;
            // 
            // dateMensualite
            // 
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = "Pas Record";
            this.dateMensualite.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateMensualite.HeaderText = "Date";
            this.dateMensualite.Name = "dateMensualite";
            this.dateMensualite.ReadOnly = true;
            this.dateMensualite.Width = 135;
            // 
            // mtantMensualite
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.mtantMensualite.DefaultCellStyle = dataGridViewCellStyle2;
            this.mtantMensualite.HeaderText = "Montant";
            this.mtantMensualite.Name = "mtantMensualite";
            this.mtantMensualite.ReadOnly = true;
            this.mtantMensualite.Width = 125;
            // 
            // verseMensualite
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.verseMensualite.DefaultCellStyle = dataGridViewCellStyle3;
            this.verseMensualite.HeaderText = "Montant Verse";
            this.verseMensualite.Name = "verseMensualite";
            this.verseMensualite.ReadOnly = true;
            this.verseMensualite.Width = 125;
            // 
            // resteMensualite
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.resteMensualite.DefaultCellStyle = dataGridViewCellStyle4;
            this.resteMensualite.HeaderText = "Montant Reste";
            this.resteMensualite.Name = "resteMensualite";
            this.resteMensualite.ReadOnly = true;
            this.resteMensualite.Width = 125;
            // 
            // etatMensualite
            // 
            this.etatMensualite.HeaderText = "Etat";
            this.etatMensualite.Name = "etatMensualite";
            this.etatMensualite.ReadOnly = true;
            this.etatMensualite.Width = 110;
            // 
            // outMensualite
            // 
            this.outMensualite.HeaderText = "Out";
            this.outMensualite.Name = "outMensualite";
            this.outMensualite.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(677, 219);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reglements";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_save);
            this.groupBox4.Controls.Add(this.btn_cancel);
            this.groupBox4.Controls.Add(this.rbtn_no);
            this.groupBox4.Controls.Add(this.rbtn_yes);
            this.groupBox4.Controls.Add(this.com_mode);
            this.groupBox4.Controls.Add(this.txt_montant);
            this.groupBox4.Controls.Add(this.txt_numPiece);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 194);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Création";
            // 
            // btn_save
            // 
            this.btn_save.Image = global::GESTION_CAISSE.Properties.Resources.btn_sauvegarde;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(147, 155);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Enreg&sitrer";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Image = global::GESTION_CAISSE.Properties.Resources.rotate_cw;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancel.Location = new System.Drawing.Point(21, 155);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(107, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "&Nouveau";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // rbtn_no
            // 
            this.rbtn_no.AutoSize = true;
            this.rbtn_no.Location = new System.Drawing.Point(164, 120);
            this.rbtn_no.Name = "rbtn_no";
            this.rbtn_no.Size = new System.Drawing.Size(45, 17);
            this.rbtn_no.TabIndex = 7;
            this.rbtn_no.TabStop = true;
            this.rbtn_no.Text = "Non";
            this.rbtn_no.UseVisualStyleBackColor = true;
            // 
            // rbtn_yes
            // 
            this.rbtn_yes.AutoSize = true;
            this.rbtn_yes.Location = new System.Drawing.Point(100, 120);
            this.rbtn_yes.Name = "rbtn_yes";
            this.rbtn_yes.Size = new System.Drawing.Size(41, 17);
            this.rbtn_yes.TabIndex = 7;
            this.rbtn_yes.TabStop = true;
            this.rbtn_yes.Text = "Oui";
            this.rbtn_yes.UseVisualStyleBackColor = true;
            // 
            // com_mode
            // 
            this.com_mode.FormattingEnabled = true;
            this.com_mode.Location = new System.Drawing.Point(101, 85);
            this.com_mode.Name = "com_mode";
            this.com_mode.Size = new System.Drawing.Size(121, 21);
            this.com_mode.TabIndex = 6;
            // 
            // txt_montant
            // 
            this.txt_montant.Location = new System.Drawing.Point(101, 53);
            this.txt_montant.Name = "txt_montant";
            this.txt_montant.Size = new System.Drawing.Size(120, 20);
            this.txt_montant.TabIndex = 5;
            // 
            // txt_numPiece
            // 
            this.txt_numPiece.Location = new System.Drawing.Point(101, 20);
            this.txt_numPiece.Name = "txt_numPiece";
            this.txt_numPiece.ReadOnly = true;
            this.txt_numPiece.Size = new System.Drawing.Size(157, 20);
            this.txt_numPiece.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Par Compte : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mode : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Montant : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Num. Piece : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_reglement);
            this.groupBox3.Location = new System.Drawing.Point(287, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 196);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Liste";
            // 
            // dgv_reglement
            // 
            this.dgv_reglement.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv_reglement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_reglement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReglement,
            this.dateReglement,
            this.mtantReglement,
            this.modeReglement});
            this.dgv_reglement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_reglement.Location = new System.Drawing.Point(3, 16);
            this.dgv_reglement.MultiSelect = false;
            this.dgv_reglement.Name = "dgv_reglement";
            this.dgv_reglement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_reglement.Size = new System.Drawing.Size(378, 177);
            this.dgv_reglement.TabIndex = 2;
            this.dgv_reglement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_regelement_CellContentClick);
            // 
            // idReglement
            // 
            this.idReglement.HeaderText = "ID";
            this.idReglement.Name = "idReglement";
            this.idReglement.Visible = false;
            // 
            // dateReglement
            // 
            dataGridViewCellStyle5.Format = "g";
            dataGridViewCellStyle5.NullValue = "Pas Record";
            this.dateReglement.DefaultCellStyle = dataGridViewCellStyle5;
            this.dateReglement.HeaderText = "Date";
            this.dateReglement.Name = "dateReglement";
            this.dateReglement.ReadOnly = true;
            this.dateReglement.Width = 120;
            // 
            // mtantReglement
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.mtantReglement.DefaultCellStyle = dataGridViewCellStyle6;
            this.mtantReglement.HeaderText = "Montant";
            this.mtantReglement.Name = "mtantReglement";
            this.mtantReglement.ReadOnly = true;
            this.mtantReglement.Width = 115;
            // 
            // modeReglement
            // 
            this.modeReglement.HeaderText = "Mode";
            this.modeReglement.Name = "modeReglement";
            this.modeReglement.ReadOnly = true;
            // 
            // Form_Caisse_Mensualite
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(701, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Caisse_Mensualite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mensualités";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mensualite)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_montant)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reglement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_genere;
        private System.Windows.Forms.DataGridView dgv_mensualite;
        private System.Windows.Forms.DataGridView dgv_reglement;
        private System.Windows.Forms.NumericUpDown txt_montant;
        private System.Windows.Forms.TextBox txt_numPiece;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtn_no;
        private System.Windows.Forms.RadioButton rbtn_yes;
        private System.Windows.Forms.ComboBox com_mode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReglement;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateReglement;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtantReglement;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeReglement;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMensualite;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateMensualite;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtantMensualite;
        private System.Windows.Forms.DataGridViewTextBoxColumn verseMensualite;
        private System.Windows.Forms.DataGridViewTextBoxColumn resteMensualite;
        private System.Windows.Forms.DataGridViewTextBoxColumn etatMensualite;
        private System.Windows.Forms.DataGridViewTextBoxColumn outMensualite;
    }
}