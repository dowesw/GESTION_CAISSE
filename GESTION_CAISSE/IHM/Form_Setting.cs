using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTION_CAISSE.TOOLS;
using GESTION_CAISSE.ENTITE;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Setting : Form
    {
        float TailPoliceTextBox, TailPoliceLabel;
        string ColorForm, ColorLabel, ColorTextTextBox, ColorTextBox, PoliceTextBox, PoliceLabel, NameTemplate;

        public Form_Setting()
        {
            InitializeComponent();
            setConfiguration();
        }

        private void setConfiguration()
        {
            Constantes.Configuration = BLL.ConfigurationBLL.getReturnConfiguration();
            if (Constantes.Configuration.Update)
            {
                com_template.SelectedItem = Constantes.Configuration.getNomTemplate;
            }
        }

        private void Form_Setting_Load(object sender, EventArgs e)
        {
            ChargerComBox();
        }


        private BLL.ConfigurationBLL getFileI()
        {
            ENTITE.Configuration config = new ENTITE.Configuration();

            config.getCouleurLabel = ColorLabel;
            config.getCouleurEcritText = ColorTextTextBox;
            config.getCouleurForm = ColorForm;
            config.getCouleurTextbox = ColorTextBox;
            config.getPoliceLabel = PoliceLabel;
            config.getPoliceEcritText = PoliceTextBox;
            config.getTaillePoliceLabel = TailPoliceLabel;
            config.getTaillePoliceEcritText = TailPoliceTextBox;
            config.getNomTemplate = NameTemplate;

            BLL.ConfigurationBLL createFileI = new BLL.ConfigurationBLL(config);
            return createFileI;
        }

        public void ChargerPoliceTextForm()
        {
            List<FontFamily> lt = new List<FontFamily>();
            System.Drawing.Text.InstalledFontCollection t0 = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily f in t0.Families)
                lt.Add(f);
            com_policeText.DataSource = lt;
            com_policeText.DisplayMember = "Name";
        }

        public void ChargerPoliceTextTextBox()
        {
            List<FontFamily> lt = new List<FontFamily>();
            System.Drawing.Text.InstalledFontCollection t0 = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily f in t0.Families)
                lt.Add(f);
            com_policTextBox.DataSource = lt;
            com_policTextBox.DisplayMember = "Name";
        }

        public void ChargerColorForm()
        {
            com_colorForm.Items.Clear();
            string[] col = System.Enum.GetNames(typeof(System.Drawing.KnownColor));
            com_colorForm.DataSource = col;
        }

        public void ChargerColorTextForm()
        {
            com_colorLabel.Items.Clear();
            string[] col = System.Enum.GetNames(typeof(System.Drawing.KnownColor));
            com_colorLabel.DataSource = col;
        }

        public void ChargerColorTextTextBox()
        {
            com_colorTextTextBox.Items.Clear();
            string[] col = System.Enum.GetNames(typeof(System.Drawing.KnownColor));
            com_colorTextTextBox.DataSource = col;
        }

        public void ChargerColorTextBox()
        {
            com_colorTextBox.Items.Clear();
            string[] col = System.Enum.GetNames(typeof(System.Drawing.KnownColor));
            com_colorTextBox.DataSource = col;
        }

        public void ChargerComBox()
        {
            ChargerPoliceTextForm();
            ChargerPoliceTextTextBox();
            ChargerColorForm();
            ChargerColorTextForm();
            ChargerColorTextTextBox();
            ChargerColorTextBox();
        }

        private void com_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_template.Text.Equals("Basique"))
            {
                NameTemplate = "Basique";
                this.box_template.Image = global::GESTION_CAISSE.Properties.Resources.Basique;

                ColorForm = "Control";
                ColorLabel = "ControlText";
                PoliceLabel = "Microsoft Sans Serif";
                TailPoliceLabel = float.Parse("8,25");

                ColorTextBox = "WindowText";
                ColorTextTextBox = "Window";
                PoliceTextBox = "Microsoft Sans Serif";
                TailPoliceTextBox = float.Parse("8,25");
            }
            else if (com_template.Text.Equals("BlackClass"))
            {
                NameTemplate = "BlackClass";
                this.box_template.Image = global::GESTION_CAISSE.Properties.Resources.BlackClass;

                ColorForm = "Black";
                ColorLabel = "ControlText";
                PoliceLabel = "Arial Narrow";
                TailPoliceLabel = float.Parse("10,25");

                ColorTextBox = "WindowText";
                ColorTextTextBox = "White";
                PoliceTextBox = "Arial Narrow";
                TailPoliceTextBox = float.Parse("10,25");
            }
            else if (com_template.Text.Equals("BlueTrack"))
            {
                NameTemplate = "BlueTrack";
                this.box_template.Image = global::GESTION_CAISSE.Properties.Resources.BlueTrack;

                ColorForm = "GradientInactiveCaption";
                ColorLabel = "Navy";
                PoliceLabel = "Tahoma";
                TailPoliceLabel = float.Parse("9,75");

                ColorTextBox = "WindowText";
                ColorTextTextBox = "Window";
                PoliceTextBox = "Tahoma";
                TailPoliceTextBox = float.Parse("9,75");

            }
            else if (com_template.Text.Equals("Classique"))
            {
                NameTemplate = "Classique";
                this.box_template.Image = global::GESTION_CAISSE.Properties.Resources.Classique;

                ColorForm = "White";
                ColorLabel = "Navy";
                PoliceLabel = "Rockwell";
                TailPoliceLabel = float.Parse("9,75");

                ColorTextBox = "WindowText";
                ColorTextTextBox = "Window";
                PoliceTextBox = "Rockwell";
                TailPoliceTextBox = float.Parse("9,75");

            }
            else if (com_template.Text.Equals("Personnaliser"))
            {
                NameTemplate = "Personnaliser";
                tabC_theme.SelectedIndex = 1;
            }

        }

        private void com_colorForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                form_divers.BackColor = Color.FromName(com_colorForm.SelectedItem.ToString());
                ColorForm = com_colorForm.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur suivant detectée");
            }
        }

        private void com_policeText_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lb_testtexte.Font = new Font((FontFamily)com_policeText.SelectedItem, 12);
                lb_testtexte1.Font = new Font((FontFamily)com_policeText.SelectedItem, 12);
                PoliceLabel = com_policeText.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur suivant detectée");
            }
        }

        private void com_colorLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lb_testtexte.ForeColor = Color.FromName(com_colorLabel.SelectedItem.ToString());
                lb_testtexte1.ForeColor = Color.FromName(com_colorLabel.SelectedItem.ToString());
                ColorLabel = com_colorLabel.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur suivant detectée");
            }
        }

        private void com_tailText_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int taille = Convert.ToInt16(com_tailText.Text);
                lb_testtexte.Font = new Font((FontFamily)com_policeText.SelectedItem, taille);
                lb_testtexte1.Font = new Font((FontFamily)com_policeText.SelectedItem, taille);
                TailPoliceLabel = taille;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur suivant detectée");
            }
        }

        private void com_colorTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_testtextbox.BackColor = Color.FromName(com_colorTextBox.SelectedItem.ToString());
                txt_testtextbox1.BackColor = Color.FromName(com_colorTextBox.SelectedItem.ToString());
                ColorTextBox = com_colorTextBox.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur suivant detectée");
            }
        }

        private void com_policTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_testtextbox.Font = new Font((FontFamily)com_policTextBox.SelectedItem, 12);
                txt_testtextbox1.Font = new Font((FontFamily)com_policTextBox.SelectedItem, 12);
                PoliceTextBox = com_policTextBox.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur suivant detectée");
            }
        }

        private void com_colorTextTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_testtextbox.ForeColor = Color.FromName(com_colorTextTextBox.SelectedItem.ToString());
                txt_testtextbox1.ForeColor = Color.FromName(com_colorTextTextBox.SelectedItem.ToString());
                ColorTextTextBox = com_colorTextTextBox.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur suivant detectée");
            }
        }

        private void com_tailTextTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int taille = Convert.ToInt16(com_tailTextTextBox.Text);
                txt_testtextbox.Font = new Font((FontFamily)com_policTextBox.SelectedItem, taille);
                txt_testtextbox1.Font = new Font((FontFamily)com_policTextBox.SelectedItem, taille);
                TailPoliceTextBox = taille;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur suivant detectée");
            }
        }

        private void btn_save_theme_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Constantes.Configuration.Update)
                {
                    if (DialogResult.Yes == Messages.Confirmation("enregistrer"))
                        if (getFileI().getCreateConfiguration())
                            if (DialogResult.OK == Messages.Succes("Configuration", "enregistrée"))
                                this.Close();
                }
                else
                {
                    if (DialogResult.Yes == Messages.Confirmation("modifier"))
                        if (getFileI().getUpdateConfiguration())
                            if (DialogResult.OK == Messages.Succes("Configuration", "modifiée"))
                                this.Close();
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        private void btn_colorForm_Click(object sender, EventArgs e)
        {
            DialogResult result = choose_color.ShowDialog();
            if (result == DialogResult.OK)
            {
                form_divers.BackColor = choose_color.Color;
                ColorForm = choose_color.Color.Name;
            }
        }

        private void btn_colorLabel_Click(object sender, EventArgs e)
        {
            DialogResult result = choose_color.ShowDialog();
            if (result == DialogResult.OK)
            {
                lb_testtexte.ForeColor = choose_color.Color;
                lb_testtexte1.ForeColor = choose_color.Color;
                ColorLabel = choose_color.Color.Name;
            }
        }

        private void btn_colorTextBox_Click(object sender, EventArgs e)
        {
            DialogResult result = choose_color.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_testtextbox.BackColor = choose_color.Color;
                txt_testtextbox1.BackColor = choose_color.Color;
                ColorTextBox = choose_color.Color.Name;
            }
        }

        private void btn_TextTextBox_Click(object sender, EventArgs e)
        {
            DialogResult result = choose_color.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_testtextbox.ForeColor = choose_color.Color;
                txt_testtextbox1.ForeColor = choose_color.Color;
                ColorTextTextBox = choose_color.Color.Name;
            }
        }
    }
}
