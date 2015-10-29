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
            
            //charger famillesa articles
            familles.Clear();
            familles = BLL.FamilleArticleBll.Liste("select * from yvs_base_famille_article");
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
       
        //modification des boutons des familles
        private void ModifButton(Button ctl, FamilleArticle cli, Label lbl)
        {
            cli = (FamilleArticle)familles.ElementAt<FamilleArticle>(indTabF);

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
                articlesCrits.Clear();
                articlesCrits.AddRange(cli.Articles);
            };
            lbl.Visible = true;
            lbl.Text = cli.Designation;
        }

        //modification des boutons des articles
        private void ModifButton(Button ctl, Article cli, Label lbl)
        {
            cli = (Article)articles.ElementAt<Article>(indTabA);

            if (cli.Photos[0].Trim().Equals("") || cli.Photos[0] == null)
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
            ctl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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

        //gestion affichage des familles d'articles
        private void Form_Caisse_Click_Load(object sender, EventArgs e)
        {
           

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


        private void LoadAllArticleFromFamille()
        {
            articles.Clear();
            articles = BLL.ArticleBll.Liste("select * from yvs_articles where famille= "+currentFamille.Id);
            
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
