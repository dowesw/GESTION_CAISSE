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

        List<FamilleArticle> familles;
        List<Article> articles;
        List<Client> clients;
       
        FamilleArticle currentFamille= new FamilleArticle();
        public double remboursement;
        public double apayer;
        public Client clientZero;

        

        public Form_Caisse_Click()
        {   
            InitializeComponent();

            familles = new List<FamilleArticle>();
            articles = new List<Article>();
            clients = new List<Client>();
            clientZero = BLL.ClientBll.Default();
            Timer bg = new Timer();
            bg.Tick += (s, e) => { label2.Text = DateTime.Now.ToString("U"); };
            bg.Interval = 500;
            bg.Start();

            InitInfoClient();

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

        private void Form_Caisse_Click_Load(object sender, EventArgs e)
        {
            LoadAllFamille();

        }

        private void LoadAllFamille()
        {
           
            CreatBtnFamilleArticle();
        }

        private void CreatBtnFamilleArticle()
        {
            int btnPos = 0;
            //Panel pnl = new Panel();
            //pnl.AutoScroll = true;
            //pnl.Width = 393;
            //pnl.Height = 202;
            //pnl.BackColor = Color.Aqua;
            //pnl.Location = new Point(3, 16);

            foreach (FamilleArticle fA in familles)
            {
                Button _btn = new Button();
                _btn.Text = fA.Designation;
                _btn.Height = 86;
                _btn.Width = 138;
                _btn.BackColor = Color.White; 

                if((btnPos%2)==0){
                    _btn.Location = new Point(15+ (138* (btnPos/2)), 15);
                }

                if ((btnPos % 2) != 0)
                {
                    _btn.Location = new Point(15 + (138 * (btnPos / 2)), 86+ 15);
                }
                
                btnPos ++;
                _btn.Click += delegate(object sender, EventArgs e)
                {
                    //_btn.Image
                    _btn.BackColor = Color.Tomato;
                    panel5.Controls.Clear();
                    CreatBtnArticle(fA.Articles);
                    foreach (Button btnn in panel4.Controls)
                    {
                        btnn.BackColor = Color.White;
                    }

                    _btn.BackColor = Color.Tomato;
                };
                panel4.AutoScroll = true;
                panel4.Controls.Add(_btn);
            }
        }

        private void CreatBtnArticle(List<Article> aarticles)
        {
            int btnPos = 0;
            //Panel pnl = new Panel();
            //pnl.AutoScroll = true;
            //pnl.Width = 393;
            //pnl.Height = 202;
            //pnl.BackColor = Color.Aqua;
            //pnl.Location = new Point(3, 16);

            foreach (Article art in aarticles)
            {
                Button _btn = new Button();
                _btn.Text = art.Designation;
                _btn.Height = 86;
                _btn.Width = 138;
                _btn.BackColor = Color.White;

                if ((btnPos % 2) == 0)
                {
                    _btn.Location = new Point(15 + (138 * (btnPos / 2)), 15);
                }

                if ((btnPos % 2) != 0)
                {
                    _btn.Location = new Point(15 + (138 * (btnPos / 2)), 86 + 15);
                }

                btnPos++;

                _btn.Click += delegate(object sender, EventArgs e)
                {
                    //_btn.BackColor = Color.Tomato;
                    //panel5.Controls.Clear();
                    foreach (Button btnn in panel5.Controls)
                    {
                        btnn.BackColor = Color.White;
                    }

                    _btn.BackColor = Color.Tomato;
                    AjoutDatgridArt(art, AjoutQteArt());
                };
                panel5.AutoScroll = true;
                panel5.Controls.Add(_btn);
            }
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

    }
}
