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
    public partial class Form_Caisse_Click : Form
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel
            .ComponentResourceManager(typeof(Form_Caisse_Click));
       
        List<FamilleArticle> familles;
        List<FamilleArticle> famillesCrits;
        List<Article> articles;
        List<Article> articlesCrits;
        List<Client> clients;
        List<Button> buttonAs;
        List<Label> labelAs;
        List<Button> buttonFs;
        List<Label> labelFs;
        int indTabF;
        int indTabA;
       
        FamilleArticle currentFamille= new FamilleArticle();
        public double remboursement;
        public double apayer;
        public Client clientZero;

        

        public Form_Caisse_Click()
        {   
            InitializeComponent();
           
            indTabF = 0; indTabA = 0;
            
            familles = new List<FamilleArticle>();
            //charger famillesa articles
            familles.Clear();
            familles = BLL.FamilleArticleBll.Liste_("select * from yvs_base_famille_article");
            famillesCrits = new List<FamilleArticle>();
            articlesCrits = new List<Article>();
            articles = new List<Article>();
            clients = new List<Client>();
            clientZero = BLL.ClientBll.Default();
            Timer bg = new Timer();
            bg.Tick += (s, e) => { label2.Text = DateTime.Now.ToString("U"); };
            bg.Interval = 500;
            bg.Start();

            InitInfoClient();
            

            // création de la liste des boutons famille
            buttonFs = new List<Button> { button7, button8, button9, button10, button11, button12, button13, button14 };
            // création de la liste des labels famille
            labelFs = new List<Label> { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8 };

            // création de la liste des boutons article
            buttonAs = new List<Button> { button15, button16, button17, button18, button19, button20, button21, button22 };
            // création de la liste des labels article
            labelAs = new List<Label> { label18, label20, label21, label22, label23, label24, label25, label26 };

            InitButton(buttonAs, labelAs);
            InitButton(buttonFs, labelFs);
            SearchDirectionF(2);

           
        }

        public void InitInfoClient()
        {
            // initialisation deslabels pour le client
            NomClient.Text = clientZero.Tiers.Nom;
            PrenomClient.Text = clientZero.Tiers.Prenom;
            AdresseClient.Text = clientZero.Tiers.Adresse;
            TelClient.Text = clientZero.Tiers.Tel;
            label16.Text = clientZero.Tiers.CodeTiers;
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
                btn.Click += delegate(object sender, EventArgs e)
                {

                };
            }

            foreach (Label lblL in listLabl)
            {
                lblL.Text = "";
                lblL.Visible = false;

            }
        }

        //modification des boutons des familles
        private void ModifButton(Button ctl, FamilleArticle cli, Label lbl)
        {
            //cli = (FamilleArticle)familles.ElementAt<FamilleArticle>(indTabF);

            //if (cli.Tiers.Logo.Trim().Equals("") || cli.Tiers.Logo == null)
            //{
            //    ctl.BackgroundImage = ((System.Drawing.Image)global::GESTION_CAISSE.Properties.Resources.user_m1);
            //}
            //else
            //{
            //    String chemin = Application.StartupPath;
            //    chemin += TOOLS.Constantes.FILE_SEPARATOR + cli.Tiers.Logo;
            //    ctl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject(chemin)));
            //}
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
                indTabA = 0;
                articles.Clear();
                articles = BLL.ArticleBll.Liste("select * from yvs_articles where famille= " + cli.Id);
                SearchDirectionA(2);
            };
            lbl.Visible = true;
            lbl.Text = cli.Designation;
        }

        //modification des boutons des articles
        private void ModifButton(Button ctl, Article cli, Label lbl)
        {
            //cli = (Article)articles.ElementAt<Article>(indTabA);

            if ((cli.Photos!=null)? 
                    ((cli.Photos.Count>0)?
                        ((cli.Photos[0]!=null)?cli.Photos[0].Trim().Equals(""):true)
                    :true)
                :true)
            {
                ctl.BackgroundImage = ((System.Drawing.Image)global::GESTION_CAISSE.Properties.Resources.user_m1);
            }
            else
            {
                String chemin = Application.StartupPath;
                chemin += TOOLS.Constantes.FILE_SEPARATOR + cli.Photos[0];
                ctl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject(chemin)));
            }

            ctl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ctl.Text = "";
            ctl.UseVisualStyleBackColor = true;
            ctl.Visible = true;
            ctl.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctl.Click += delegate(object sender, EventArgs e)
            {
               
            };
            lbl.Visible = true;
            lbl.Text = cli.Designation;
        }

        private void ResultatRechercheF(String txt)
        {
            famillesCrits.Clear();
            if ((txt.Length != 0))
            {
                foreach (FamilleArticle sCli in familles)
                {
                    if (sCli.Designation.ToLower().Contains(txt.ToLower()))
                    {
                        famillesCrits.Add(sCli);
                    }
                }
            }
            else { famillesCrits.AddRange(familles); }
        }

        private void ResultatRechercheA(String txt)
        {
            articlesCrits.Clear();
            if ((txt.Length != 0))
            {
                foreach (Article sCli in articles)
                {
                    if (sCli.Designation.ToLower().Contains(txt.ToLower()))
                    {
                        articlesCrits.Add(sCli);
                    }
                }
            }
            else { articlesCrits.AddRange(articles); }
        }

        private List<FamilleArticle> GetPack8F(ref int indActu, List<FamilleArticle> list, int sens)
        {
            List<FamilleArticle> listRetour = new List<FamilleArticle>();
            if (sens == 2)
            {
                for (int i = 0; i < 8; i++)
                {
                    if ((indActu == list.Count - 1) || (list.Count == 0)) pgDroiteF.Enabled = false;
                    else pgDroiteF.Enabled = true;
                    if (indActu < 8) pgGaucheF.Enabled = false;
                    else pgGaucheF.Enabled = true;

                    if ((indActu >= 0) && (indActu < list.Count))
                    {
                        listRetour.Add(list.ElementAt<FamilleArticle>(indActu));
                        indActu++;
                    }

                    if (indActu == list.Count)
                    {
                        indActu--;
                        return listRetour;
                    }
                }
            }

            if (sens == 1)
            {
                for (int i = 0; i < 8; i++)
                {

                    if (indActu == list.Count - 1) pgDroiteF.Enabled = false;
                    else pgDroiteF.Enabled = true;
                    if (indActu < 8) pgGaucheF.Enabled = false;
                    else pgGaucheF.Enabled = true;

                    if ((indActu >= 0) && (indActu < list.Count))
                    {
                        listRetour.Add(list.ElementAt<FamilleArticle>(indActu));
                        indActu--;
                    }

                    if (indActu <= -1)
                    {
                        return listRetour;
                    }
                }
            }
            return listRetour;
        }

        private List<Article> GetPack8A(ref int indActu, List<Article> list, int sens)
        {
            List<Article> listRetour = new List<Article>();
            if (sens == 2)
            {
                for (int i = 0; i < 8; i++)
                {
                   

                    if ((indActu >= 0) && (indActu < list.Count))
                    {
                        listRetour.Add(list.ElementAt<Article>(indActu));
                        indActu++;
                    }

                    if (indActu == list.Count)
                    {
                        if ((indActu == list.Count - 1) || (list.Count == 0)) pgDroiteA.Enabled = false;
                        else pgDroiteA.Enabled = true;
                        if (indActu < 8) pgGaucheA.Enabled = false;
                        else pgGaucheA.Enabled = true;
                        indActu--;
                        return listRetour;
                    }
                }
            }

            if (sens == 1)
            {
                indActu-=7;
                for (int i = 0; i < 8; i++)
                {

                    if ((indActu >= 0) && (indActu < list.Count))
                    {
                        listRetour.Add(list.ElementAt<Article>(indActu));
                        indActu++;
                    }

                    if (indActu <= -1)
                    {
                        if (indActu == list.Count - 1) pgDroiteA.Enabled = false;
                        else pgDroiteA.Enabled = true;
                        if (indActu < 8) pgGaucheA.Enabled = false;
                        else pgGaucheA.Enabled = true;
                        indActu++;
                        return listRetour;
                    }
                }
            }
            return listRetour;
        }

        private void SearchDirectionF(int sens)
        {
            int posBtn = 0;
            InitButton(buttonFs, labelFs);
            ResultatRechercheF("");
            List<FamilleArticle> seracList = GetPack8F(ref indTabF, famillesCrits, sens);
            var t = seracList.Count;
            foreach (FamilleArticle cli in seracList)
            {
                ModifButton(buttonFs.ElementAt<Button>(posBtn), cli, labelFs.ElementAt<Label>(posBtn));
                posBtn++;
            }
        }
        private void SearchDirectionA(int sens)
        {
            int posBtn = 0;
            InitButton(buttonAs, labelAs);
            ResultatRechercheA("");
            List<Article> seracList = GetPack8A(ref indTabA, articlesCrits, sens);
            var t = seracList.Count;
            foreach (Article cli in seracList)
            {
                ModifButton(buttonAs.ElementAt<Button>(posBtn), cli, labelAs.ElementAt<Label>(posBtn));
                posBtn++;
            }
        }

        private void pgGaucheF_Click(object sender, EventArgs e)
        {
            SearchDirectionF(1);
        }

        private void pgDroiteF_Click(object sender, EventArgs e)
        {
            SearchDirectionF(2);
        }

        private void pgGaucheA_Click(object sender, EventArgs e)
        {
            SearchDirectionA(1);
        }

        private void pgDroiteA_Click(object sender, EventArgs e)
        {
            SearchDirectionA(2);
        }


        private void AjoutDatgridArt(Article artDtG, int qte)
        {
            string[] row = new string[] { artDtG.Designation, (artDtG.Prix).ToString(), qte.ToString(),
            (qte * artDtG.Prix).ToString() };

            dataGridView1.Rows.Add(row);
        }

        private int AjoutQteArt()
        {
            return 34;
        }


        private void LoadAllClient()
        {
            clients.Clear();
            clients = BLL.ClientBll.Liste("select * from yvs_com_client");
        }

        private void Regler(object sender, EventArgs e)
        {
            Form_Caisse_Reglement f = new Form_Caisse_Reglement(this);
            f.ShowDialog();
        }

        private void NvoTicket_Click(object sender, EventArgs e)
        {
            TotalRemz.Text = "0";
            SommeP.Text = "0";
            SommSR.Text = "0";
            TotalRemz.Text = "0";
            Relicat.Text = "0";

            clientZero = BLL.ClientBll.Default();
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void picClient_Click(object sender, EventArgs e)
        {
            Form_Choix_Client f = new Form_Choix_Client(this);
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
