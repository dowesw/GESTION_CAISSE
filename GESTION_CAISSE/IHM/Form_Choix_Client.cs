using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTION_CAISSE.ENTITE;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Choix_Client : Form
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Choix_Client));
        List<Client> clients;
        List<Client> clientCrits;
        List<Button> buttons;
        List<Label> labels;
        List<Button> claviers;
        List<Button> claviers2;
        Form fParent;
        int indTab;


        public Form_Choix_Client(Form parent)
        {
            InitializeComponent();
            fParent = parent;

            clients = new List<Client>();
            clients = BLL.ClientBll.Liste("select * from yvs_com_client");
            var t = clients.Count;
            clientCrits = new List<Client>();
            // création de la liste des boutons
            buttons = new List<Button> { button33, button34, button35, button36, button37, button38, button39, button40 };
            // création de la liste des boutons
            labels = new List<Label> { label1, label2, label3, label4, label5, label6, label7, label8 };
            // création de la liste des boutons
            claviers = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9
            , button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20
            , button21, button22, button23, button24, button25, button26};

            claviers2 = new List<Button> { button68, button67, button66, button65, button64, button63, button62, button61, button60
            , button59};

            populateEventAlphaCla();
            populateEventNumCla();
            //affichage des boutons
            indTab = 0;
            InitButton(buttons, labels);
            SearchDirection(2);
            //panel1.Visible=true;
            //panel4.Visible=false;
        }


        private void ModifButton(Button ctl, Client cli, Label lbl)
        {
            //cli = (Client)clients.ElementAt<Client>(indTab);

            if (cli.Tiers.Logo.Trim().Equals("") || cli.Tiers.Logo == null)
            {
                ctl.BackgroundImage = ((System.Drawing.Image)global::GESTION_CAISSE.Properties.Resources.user_m1);
            }
            else
            {
                String chemin = Application.StartupPath;
                chemin += TOOLS.Constantes.FILE_SEPARATOR + cli.Tiers.Logo;
                ctl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject(chemin)));
            }
            ctl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ctl.Text = "";
            ctl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            ctl.UseVisualStyleBackColor = true;
            ctl.Visible = true;
            //ctl.Size = new System.Drawing.Size(159, 170);
            ctl.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctl.Click += delegate(object sender, EventArgs e)
            {
                Form_Caisse_Click f = (Form_Caisse_Click)fParent;
                f.clientZero = cli;
                f.InitInfoClient();
                this.Close();
            };
            lbl.Visible = true;
            lbl.Text = cli.Nom_prenom;
        }

        private void ResultatRecherche(String txt)
        {
            clientCrits.Clear();
            if (txt.Length!=0)
            {
                foreach (Client sCli in clients)
                {
                    if (sCli.Tiers.Nom_prenom.ToLower().Contains(txt.ToLower()))
                    {
                        clientCrits.Add(sCli);
                    }
                }
            }
            else { clientCrits.AddRange(clients); }
        }

        private List<Client> GetPack8(ref int indActu, List<Client> list, int sens)
        {
            List<Client> listRetour = new List<Client>();

            if (sens == 2)
            {
                listRetour.Clear();

                //int charT = btn_cpt_Articles.Text.IndexOf('/');
                //int subStr = Convert.ToInt32(btn_cpt_Articles.Text.Substring(0, charT));
                //btn_cpt_Articles.Text = (subStr + 1).ToString() + "/" + nbrPgA;

                //if (b1A == true)
                //{
                //    b1A = false;
                //    indActu += 8;
                //}

                for (int i = 0; i < 8; i++)
                {
                    if ((indActu == list.Count - 1) || (list.Count == 0) /*|| (subStr == nbrPgF)*/) pgDroite.Enabled = false;
                    else pgDroite.Enabled = true;

                    if (indActu < 8) pgGauche.Enabled = false;
                    else pgGauche.Enabled = true;

                    if (/*(indActu >= 0) &&*/ (indActu < list.Count))
                    {
                        listRetour.Add(list.ElementAt<Client>(indActu));
                        indActu++;
                    }

                    if (indActu == list.Count)
                    {
                        indActu--;
                        return listRetour;
                    }
                }
                //b2A = true;
            }

            if (sens == 1)
            {
                //if (b2A == true)
                //{
                //    b2A = false;
                //    if ((indActu % 8) == 7) indActu -= 8;
                //}
                listRetour.Clear();

                //int charT2 = btn_cpt_Articles.Text.IndexOf('/');
                //int subStr2 = Convert.ToInt32(btn_cpt_Articles.Text.Substring(0, charT2));
                //btn_cpt_Articles.Text = (subStr2 - 1).ToString() + "/" + nbrPgF;

                if ((indActu % 8) != 7) indActu -= ((indActu % 8));
                else indActu -= 8;
                //indActu--;

                for (int i = 0; i < 8; i++)
                {

                    if ((indActu >= 0) && (indActu < list.Count))
                    {
                        indActu--;
                        listRetour.Add(list.ElementAt<Client>(indActu));
                    }

                    if (indActu <= -1)
                    {
                        indActu++;
                        listRetour.Reverse();
                        return listRetour;
                    }

                    if (indActu == list.Count - 1) pgDroite.Enabled = false;
                    else pgDroite.Enabled = true;

                    if (indActu < 8) pgGauche.Enabled = false;
                    else pgGauche.Enabled = true;
                }
                listRetour.Reverse();
                //b1A = true;
            }
            return listRetour;
        }

        private void InitButton(List<Button> listBtn, List<Label> listLabl)
        {
            foreach (Button btn in listBtn)
            {
                btn.BackgroundImage = null;
                btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btn.Text = "";
                btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                btn.UseVisualStyleBackColor = true;
                btn.Visible = false;
                btn.Click -= delegate(object sender, EventArgs e)
                {

                };
            }

            foreach (Label lblL in listLabl)
            {
                lblL.Text = "";
                lblL.Visible = false;

            }
        }


        private void SearchDirection(int sens)
        {
            int posBtn = 0;
            InitButton(buttons, labels);
            ResultatRecherche(textBox1.Text);
            List<Client> seracList = GetPack8(ref indTab, clientCrits, sens);
            var t = seracList.Count;
            foreach (Client cli in seracList)
            {
                ModifButton(buttons.ElementAt<Button>(posBtn), cli, labels.ElementAt<Label>(posBtn));
                posBtn++;
            }
        }

       
        private void DroiteClick(object sender, EventArgs e)
        {
            SearchDirection(2);
        }

        private void GaucheClick(object sender, EventArgs e)
        {
            SearchDirection(1);
        }

        private void populateEventAlphaCla()
        {
            foreach (Button btn in claviers)
            {
                btn.Click += delegate(object senderc, EventArgs ec)
                {
                    this.textBox1.Text += btn.Text;
                };
            }
        }

        private void populateEventNumCla()
        {
            foreach (Button btn in claviers2)
            {
                btn.Click += delegate(object senderc, EventArgs ec)
                {
                    this.textBox1.Text += btn.Text;
                };
            }
        }

        private void numerique_Click(object sender, EventArgs e)
        {

            panel4.Visible = true;
            panel1.Visible = false;

        }
        private void alphabet_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel4.Visible = false;
        }
        //effacer un caractere
        private void button27_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }
        //effacer toute ecriture if (textBox1.Text.Length > 0) 
        private void button28_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            indTab = 0;
            SearchDirection(2);
            Console.WriteLine(textBox1.Text);
            var tt = clientCrits.Count;
        }

        private void button67_Click(object sender, EventArgs e)
        {

        }

        private void button60_Click(object sender, EventArgs e)
        {

        }

        private void Form_Choix_Client_Load(object sender, EventArgs e)
        {

        }

    }
}
