using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GESTION_CAISSE.TOOLS;
using GESTION_CAISSE.ENTITE;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Login : Form
    {
        int i = 0, j = 0, nbreerror = 0;

        public Form_Login()
        {
            InitializeComponent();
        }

        public void ShowNotification()
        {
            bubble.Visible = true;
            bubble.ShowBalloonTip(10, "Information de connexion", Constantes.Users.NomUser + " : Vous êtes connecté", System.Windows.Forms.ToolTipIcon.Info);
        }

        private void MiseZero()
        {
            txt_email.ResetText();
            txt_pwd.ResetText();
        }

        private void InitTime()
        {
            i = 0;
            j = 0;
            nbreerror = 0;
            progressBar1.Value = 0;
            MiseZero();
        }

        private Users RecopiewView()
        {
            Users u = new Users();
            u.CodeUsers = txt_email.Text.Trim();
            u.Password = txt_pwd.Text.Trim();
            return u;
        }

        private bool ConnectLog()
        {
            try
            {
                Users u = RecopiewView();
                if (u.correct())
                {
                    if (u.CodeUsers.Equals(Constantes.NAME_ADMIN) && u.Password.Equals(Constantes.NAME_ADMIN))
                    {
                        u.CodeUsers = "Administrateur";
                        u.NomUser = "Administrateur";
                        u.Admin = true;
                        if (Constantes.Users == null)
                            Constantes.Users = new ENTITE.Users();
                        Constantes.Users = u;
                        return true;
                    }
                    else
                    {
                        Users u_ = BLL.UsersBll.One(u.CodeUsers, Echapper(u.Password));
                        if ((u_ != null) ? u_.Id > 0 : false)
                        {
                            if (u_.Actif)
                            {
                                if (Constantes.Users == null)
                                    Constantes.Users = new ENTITE.Users();
                                Constantes.Users = u_;
                                return true;
                            }
                            else
                            {
                                Messages.ShowErreur("Votre compte est déactiver...Veuillez contacter votre administrateur!");
                            }
                        }
                        else
                        {
                            Messages.ShowErreur("Code ou Mot de passe incorrect!");
                        }
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
                return false;
            }
        }

        private bool setCreneau()
        {
            if (Constantes.Users.Admin)
            {
                return true;
            }
            Creneau c = BLL.CreneauBll.One(BLL.PersonnelBll.One(Constantes.Users));
            if ((c != null) ? c.Id > 0 : false)
            {
                Constantes.Creneau = c;
            }
            Messages.ShowErreur("Vous n'etes pas programmé pour aujourd'hui. Veuillez contacter votre administrateur!");
            return false;
        }

        private string Echapper(string chaine)
        {
            int i = 0;
            string vr = null;
            vr = chaine;
            foreach (char t in chaine)
            {
                if (t == '\'')
                {
                    vr = vr.Insert(i + 1, "'");
                    i++;
                }
                else if (t == '\\')
                {
                    vr = vr.Insert(i + 1, @"\");
                    i++;
                }
                i++;
            }
            return vr;
        }

        private void btn_connecter_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConnectLog())
                {
                    if (setCreneau())
                    {
                        this.Hide();
                        timer1.Stop();
                        timer2.Stop();
                        InitTime();

                        new Form_Caisse_Saisie(this).Show();
                        ShowNotification();
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        public void btn_annuler_Click(object sender, EventArgs e)
        {
            if (!Constantes.askQuestion)
            {
                Constantes.askQuestion = true;
                if (DialogResult.OK == Messages.FermerApplication())
                {
                    Application.Exit();
                }
                else if (this.Visible)
                    MiseZero();
            }
            else
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i != Constantes.MAX_TIME_CONNECT)
            {
                temps.Text = "Il reste " + (Constantes.MAX_TIME_CONNECT - i).ToString() + " secondes";
                timer1.Stop();
                timer2.Start();
                System.Threading.Thread.Sleep(1000);
                i++;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (j == 3)
            {
                timer2.Stop();
                timer1.Start();
                if (i == Constantes.MAX_TIME_CONNECT)
                {
                    progressBar1.Value += 100 - progressBar1.Value;
                    if (DialogResult.OK == MessageBox.Show("Temps de connexion expiré. Merci", "Gestion Caisse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation))
                    {
                        Application.Exit();
                    }
                }
                j = 0;
            }
            else
            {
                progressBar1.Value += 1;
                j++;
            }
        }

        private void link_creeruser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form_Login_Activated(object sender, EventArgs e)
        {
            timer1.Start();
            txt_email.Focus();
        }

        private void btn_presence_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            txt_email.Focus();
            Constantes.Users = null;
            timer2.Start();
        }

        private void tool_setting_Click(object sender, EventArgs e)
        {
            new Form_Setting().Show();
        }
    }
}
