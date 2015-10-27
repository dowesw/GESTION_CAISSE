namespace GESTION_CAISSE.IHM
{
    partial class Form_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Setting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_save_theme = new System.Windows.Forms.Button();
            this.btn_cancel_theme = new System.Windows.Forms.Button();
            this.tabC_theme = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.box_template = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.com_template = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.form_divers = new System.Windows.Forms.Panel();
            this.txt_testtextbox1 = new System.Windows.Forms.TextBox();
            this.lb_testtexte1 = new System.Windows.Forms.Label();
            this.txt_testtextbox = new System.Windows.Forms.TextBox();
            this.lb_testtexte = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_TextTextBox = new System.Windows.Forms.Button();
            this.btn_colorTextBox = new System.Windows.Forms.Button();
            this.com_tailTextTextBox = new System.Windows.Forms.ComboBox();
            this.com_colorTextTextBox = new System.Windows.Forms.ComboBox();
            this.com_policTextBox = new System.Windows.Forms.ComboBox();
            this.com_colorTextBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_colorLabel = new System.Windows.Forms.Button();
            this.btn_colorForm = new System.Windows.Forms.Button();
            this.com_tailText = new System.Windows.Forms.ComboBox();
            this.com_colorLabel = new System.Windows.Forms.ComboBox();
            this.com_policeText = new System.Windows.Forms.ComboBox();
            this.com_colorForm = new System.Windows.Forms.ComboBox();
            this.coulF = new System.Windows.Forms.Label();
            this.coulTf = new System.Windows.Forms.Label();
            this.poliT = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.choose_color = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_label = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabC_theme.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_template)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.form_divers.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 445);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_save_theme);
            this.tabPage1.Controls.Add(this.btn_cancel_theme);
            this.tabPage1.Controls.Add(this.tabC_theme);
            this.tabPage1.Location = new System.Drawing.Point(23, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(857, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thèmes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_save_theme
            // 
            this.btn_save_theme.Location = new System.Drawing.Point(689, 406);
            this.btn_save_theme.Name = "btn_save_theme";
            this.btn_save_theme.Size = new System.Drawing.Size(81, 23);
            this.btn_save_theme.TabIndex = 3;
            this.btn_save_theme.Text = "Sauvegarder";
            this.btn_save_theme.UseVisualStyleBackColor = true;
            this.btn_save_theme.Click += new System.EventHandler(this.btn_save_theme_Click);
            // 
            // btn_cancel_theme
            // 
            this.btn_cancel_theme.Location = new System.Drawing.Point(776, 406);
            this.btn_cancel_theme.Name = "btn_cancel_theme";
            this.btn_cancel_theme.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel_theme.TabIndex = 2;
            this.btn_cancel_theme.Text = "Annuler";
            this.btn_cancel_theme.UseVisualStyleBackColor = true;
            // 
            // tabC_theme
            // 
            this.tabC_theme.Controls.Add(this.tabPage3);
            this.tabC_theme.Controls.Add(this.tabPage4);
            this.tabC_theme.Location = new System.Drawing.Point(3, 3);
            this.tabC_theme.Name = "tabC_theme";
            this.tabC_theme.SelectedIndex = 0;
            this.tabC_theme.Size = new System.Drawing.Size(851, 397);
            this.tabC_theme.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.box_template);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.com_template);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(843, 371);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Par Défaut";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // box_template
            // 
            this.box_template.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.box_template.Image = global::GESTION_CAISSE.Properties.Resources.Basique;
            this.box_template.Location = new System.Drawing.Point(7, 61);
            this.box_template.Name = "box_template";
            this.box_template.Size = new System.Drawing.Size(830, 307);
            this.box_template.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box_template.TabIndex = 2;
            this.box_template.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Template : ";
            // 
            // com_template
            // 
            this.com_template.FormattingEnabled = true;
            this.com_template.Items.AddRange(new object[] {
            "Basique",
            "Classique",
            "BlackClass",
            "BlueTrack",
            "Personnaliser"});
            this.com_template.Location = new System.Drawing.Point(113, 20);
            this.com_template.Name = "com_template";
            this.com_template.Size = new System.Drawing.Size(209, 21);
            this.com_template.TabIndex = 0;
            this.com_template.Text = "Basique";
            this.com_template.SelectedIndexChanged += new System.EventHandler(this.com_template_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.form_divers);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(843, 371);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Personaliser";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // form_divers
            // 
            this.form_divers.BackColor = System.Drawing.Color.White;
            this.form_divers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.form_divers.Controls.Add(this.panel1);
            this.form_divers.Controls.Add(this.txt_testtextbox1);
            this.form_divers.Controls.Add(this.lb_testtexte1);
            this.form_divers.Controls.Add(this.txt_testtextbox);
            this.form_divers.Controls.Add(this.lb_testtexte);
            this.form_divers.Location = new System.Drawing.Point(400, 46);
            this.form_divers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.form_divers.Name = "form_divers";
            this.form_divers.Size = new System.Drawing.Size(437, 269);
            this.form_divers.TabIndex = 29;
            // 
            // txt_testtextbox1
            // 
            this.txt_testtextbox1.Location = new System.Drawing.Point(225, 222);
            this.txt_testtextbox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_testtextbox1.Name = "txt_testtextbox1";
            this.txt_testtextbox1.ReadOnly = true;
            this.txt_testtextbox1.Size = new System.Drawing.Size(188, 20);
            this.txt_testtextbox1.TabIndex = 11;
            this.txt_testtextbox1.Text = "texte";
            // 
            // lb_testtexte1
            // 
            this.lb_testtexte1.AutoSize = true;
            this.lb_testtexte1.Location = new System.Drawing.Point(23, 225);
            this.lb_testtexte1.Name = "lb_testtexte1";
            this.lb_testtexte1.Size = new System.Drawing.Size(95, 13);
            this.lb_testtexte1.TabIndex = 9;
            this.lb_testtexte1.Text = "Texte (Exemple) :  ";
            // 
            // txt_testtextbox
            // 
            this.txt_testtextbox.Location = new System.Drawing.Point(225, 184);
            this.txt_testtextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_testtextbox.Name = "txt_testtextbox";
            this.txt_testtextbox.ReadOnly = true;
            this.txt_testtextbox.Size = new System.Drawing.Size(188, 20);
            this.txt_testtextbox.TabIndex = 11;
            this.txt_testtextbox.Text = "texte";
            // 
            // lb_testtexte
            // 
            this.lb_testtexte.AutoSize = true;
            this.lb_testtexte.Location = new System.Drawing.Point(23, 187);
            this.lb_testtexte.Name = "lb_testtexte";
            this.lb_testtexte.Size = new System.Drawing.Size(95, 13);
            this.lb_testtexte.TabIndex = 9;
            this.lb_testtexte.Text = "Texte (Exemple) :  ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_TextTextBox);
            this.groupBox2.Controls.Add(this.btn_colorTextBox);
            this.groupBox2.Controls.Add(this.com_tailTextTextBox);
            this.groupBox2.Controls.Add(this.com_colorTextTextBox);
            this.groupBox2.Controls.Add(this.com_policTextBox);
            this.groupBox2.Controls.Add(this.com_colorTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 186);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(381, 174);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TextBox";
            // 
            // btn_TextTextBox
            // 
            this.btn_TextTextBox.Location = new System.Drawing.Point(349, 96);
            this.btn_TextTextBox.Name = "btn_TextTextBox";
            this.btn_TextTextBox.Size = new System.Drawing.Size(26, 23);
            this.btn_TextTextBox.TabIndex = 30;
            this.btn_TextTextBox.Text = "+";
            this.btn_TextTextBox.UseVisualStyleBackColor = true;
            this.btn_TextTextBox.Click += new System.EventHandler(this.btn_TextTextBox_Click);
            // 
            // btn_colorTextBox
            // 
            this.btn_colorTextBox.Location = new System.Drawing.Point(349, 20);
            this.btn_colorTextBox.Name = "btn_colorTextBox";
            this.btn_colorTextBox.Size = new System.Drawing.Size(26, 23);
            this.btn_colorTextBox.TabIndex = 30;
            this.btn_colorTextBox.Text = "+";
            this.btn_colorTextBox.UseVisualStyleBackColor = true;
            this.btn_colorTextBox.Click += new System.EventHandler(this.btn_colorTextBox_Click);
            // 
            // com_tailTextTextBox
            // 
            this.com_tailTextTextBox.FormattingEnabled = true;
            this.com_tailTextTextBox.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18",
            "22"});
            this.com_tailTextTextBox.Location = new System.Drawing.Point(168, 138);
            this.com_tailTextTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.com_tailTextTextBox.Name = "com_tailTextTextBox";
            this.com_tailTextTextBox.Size = new System.Drawing.Size(76, 21);
            this.com_tailTextTextBox.TabIndex = 26;
            this.com_tailTextTextBox.SelectedIndexChanged += new System.EventHandler(this.com_tailTextTextBox_SelectedIndexChanged);
            // 
            // com_colorTextTextBox
            // 
            this.com_colorTextTextBox.FormattingEnabled = true;
            this.com_colorTextTextBox.Location = new System.Drawing.Point(168, 98);
            this.com_colorTextTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.com_colorTextTextBox.Name = "com_colorTextTextBox";
            this.com_colorTextTextBox.Size = new System.Drawing.Size(178, 21);
            this.com_colorTextTextBox.TabIndex = 25;
            this.com_colorTextTextBox.SelectedIndexChanged += new System.EventHandler(this.com_colorTextTextBox_SelectedIndexChanged);
            // 
            // com_policTextBox
            // 
            this.com_policTextBox.FormattingEnabled = true;
            this.com_policTextBox.Location = new System.Drawing.Point(168, 61);
            this.com_policTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.com_policTextBox.Name = "com_policTextBox";
            this.com_policTextBox.Size = new System.Drawing.Size(178, 21);
            this.com_policTextBox.TabIndex = 24;
            this.com_policTextBox.SelectedIndexChanged += new System.EventHandler(this.com_policTextBox_SelectedIndexChanged);
            // 
            // com_colorTextBox
            // 
            this.com_colorTextBox.FormattingEnabled = true;
            this.com_colorTextBox.Location = new System.Drawing.Point(169, 22);
            this.com_colorTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.com_colorTextBox.Name = "com_colorTextBox";
            this.com_colorTextBox.Size = new System.Drawing.Size(177, 21);
            this.com_colorTextBox.TabIndex = 23;
            this.com_colorTextBox.SelectedIndexChanged += new System.EventHandler(this.com_colorTextBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Couleur du TextBox : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Couleur du texte : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Police texte : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Taille police : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_colorLabel);
            this.groupBox1.Controls.Add(this.btn_colorForm);
            this.groupBox1.Controls.Add(this.com_tailText);
            this.groupBox1.Controls.Add(this.com_colorLabel);
            this.groupBox1.Controls.Add(this.com_policeText);
            this.groupBox1.Controls.Add(this.com_colorForm);
            this.groupBox1.Controls.Add(this.coulF);
            this.groupBox1.Controls.Add(this.coulTf);
            this.groupBox1.Controls.Add(this.poliT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(381, 171);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulaire";
            // 
            // btn_colorLabel
            // 
            this.btn_colorLabel.Location = new System.Drawing.Point(349, 96);
            this.btn_colorLabel.Name = "btn_colorLabel";
            this.btn_colorLabel.Size = new System.Drawing.Size(26, 23);
            this.btn_colorLabel.TabIndex = 30;
            this.btn_colorLabel.Text = "+";
            this.btn_colorLabel.UseVisualStyleBackColor = true;
            this.btn_colorLabel.Click += new System.EventHandler(this.btn_colorLabel_Click);
            // 
            // btn_colorForm
            // 
            this.btn_colorForm.Location = new System.Drawing.Point(349, 28);
            this.btn_colorForm.Name = "btn_colorForm";
            this.btn_colorForm.Size = new System.Drawing.Size(26, 23);
            this.btn_colorForm.TabIndex = 30;
            this.btn_colorForm.Text = "+";
            this.btn_colorForm.UseVisualStyleBackColor = true;
            this.btn_colorForm.Click += new System.EventHandler(this.btn_colorForm_Click);
            // 
            // com_tailText
            // 
            this.com_tailText.FormattingEnabled = true;
            this.com_tailText.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18",
            "22"});
            this.com_tailText.Location = new System.Drawing.Point(169, 134);
            this.com_tailText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.com_tailText.Name = "com_tailText";
            this.com_tailText.Size = new System.Drawing.Size(75, 21);
            this.com_tailText.TabIndex = 26;
            this.com_tailText.SelectedIndexChanged += new System.EventHandler(this.com_tailText_SelectedIndexChanged);
            // 
            // com_colorLabel
            // 
            this.com_colorLabel.FormattingEnabled = true;
            this.com_colorLabel.Location = new System.Drawing.Point(169, 98);
            this.com_colorLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.com_colorLabel.Name = "com_colorLabel";
            this.com_colorLabel.Size = new System.Drawing.Size(177, 21);
            this.com_colorLabel.TabIndex = 25;
            this.com_colorLabel.SelectedIndexChanged += new System.EventHandler(this.com_colorLabel_SelectedIndexChanged);
            // 
            // com_policeText
            // 
            this.com_policeText.FormattingEnabled = true;
            this.com_policeText.Location = new System.Drawing.Point(169, 66);
            this.com_policeText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.com_policeText.Name = "com_policeText";
            this.com_policeText.Size = new System.Drawing.Size(177, 21);
            this.com_policeText.TabIndex = 24;
            this.com_policeText.SelectedIndexChanged += new System.EventHandler(this.com_policeText_SelectedIndexChanged);
            // 
            // com_colorForm
            // 
            this.com_colorForm.FormattingEnabled = true;
            this.com_colorForm.Location = new System.Drawing.Point(169, 28);
            this.com_colorForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.com_colorForm.Name = "com_colorForm";
            this.com_colorForm.Size = new System.Drawing.Size(177, 21);
            this.com_colorForm.TabIndex = 23;
            this.com_colorForm.SelectedIndexChanged += new System.EventHandler(this.com_colorForm_SelectedIndexChanged);
            // 
            // coulF
            // 
            this.coulF.AutoSize = true;
            this.coulF.Location = new System.Drawing.Point(14, 31);
            this.coulF.Name = "coulF";
            this.coulF.Size = new System.Drawing.Size(118, 13);
            this.coulF.TabIndex = 17;
            this.coulF.Text = "Couleur du Formulaire : ";
            // 
            // coulTf
            // 
            this.coulTf.AutoSize = true;
            this.coulTf.Location = new System.Drawing.Point(14, 100);
            this.coulTf.Name = "coulTf";
            this.coulTf.Size = new System.Drawing.Size(93, 13);
            this.coulTf.TabIndex = 19;
            this.coulTf.Text = "Couleur du texte : ";
            // 
            // poliT
            // 
            this.poliT.AutoSize = true;
            this.poliT.Location = new System.Drawing.Point(14, 66);
            this.poliT.Name = "poliT";
            this.poliT.Size = new System.Drawing.Size(71, 13);
            this.poliT.TabIndex = 22;
            this.poliT.Text = "Police texte : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Taille police : ";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(857, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Utilisateur";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lb_label);
            this.panel1.Location = new System.Drawing.Point(18, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 163);
            this.panel1.TabIndex = 12;
            // 
            // lb_label
            // 
            this.lb_label.AutoSize = true;
            this.lb_label.Location = new System.Drawing.Point(14, 12);
            this.lb_label.Name = "lb_label";
            this.lb_label.Size = new System.Drawing.Size(295, 130);
            this.lb_label.TabIndex = 0;
            this.lb_label.Text = resources.GetString("lb_label.Text");
            // 
            // Form_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 445);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Form_Setting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabC_theme.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_template)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.form_divers.ResumeLayout(false);
            this.form_divers.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabC_theme;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox box_template;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox com_template;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel form_divers;
        private System.Windows.Forms.TextBox txt_testtextbox1;
        private System.Windows.Forms.Label lb_testtexte1;
        private System.Windows.Forms.TextBox txt_testtextbox;
        private System.Windows.Forms.Label lb_testtexte;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox com_tailTextTextBox;
        private System.Windows.Forms.ComboBox com_colorTextTextBox;
        private System.Windows.Forms.ComboBox com_policTextBox;
        private System.Windows.Forms.ComboBox com_colorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox com_tailText;
        private System.Windows.Forms.ComboBox com_colorLabel;
        private System.Windows.Forms.ComboBox com_policeText;
        private System.Windows.Forms.ComboBox com_colorForm;
        private System.Windows.Forms.Label coulF;
        private System.Windows.Forms.Label coulTf;
        private System.Windows.Forms.Label poliT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_save_theme;
        private System.Windows.Forms.Button btn_cancel_theme;
        private System.Windows.Forms.Button btn_TextTextBox;
        private System.Windows.Forms.Button btn_colorTextBox;
        private System.Windows.Forms.Button btn_colorLabel;
        private System.Windows.Forms.Button btn_colorForm;
        private System.Windows.Forms.ColorDialog choose_color;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_label;
    }
}