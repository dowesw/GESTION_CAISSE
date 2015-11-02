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
using GESTION_CAISSE.TOOLS;

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

        Depot dpt= new Depot();
        int indTabF;
        int indTabA;
        public bool archive;

        public double remboursement;
        public double apayer;
        public Client clientZero=new Client();
        public Contenu contenu= new Contenu();
        public Article articleGen= new Article();
        Facture fact=new Facture();



        public Form_Caisse_Click()
        {
            InitializeComponent();
            familles = new List<FamilleArticle>();
            //charger famillesa articles
            familles.Clear();
            //familles = BLL.FamilleArticleBll.Liste_("select * from yvs_base_famille_article");
            familles = prodListFamille();
            famillesCrits = new List<FamilleArticle>();
            articlesCrits = new List<Article>();
            articles = new List<Article>();
            clients = new List<Client>();
           
            contenu = new Contenu();
           
            ConfigForm();

            // tout réinitialiser
            archive = true;
            btnReglement.Enabled = false;
            
            panel4.Enabled = false;
            //picClient.Enabled = false;
            btnEnregistrer.Enabled = false;
            SearchDirectionF(2);

        }

        public void ConfigForm()
        {
            clientZero = BLL.ClientBll.Default();
            dpt = TOOLS.Constantes.Creneau.Depot;
            indTabF = 0; indTabA = 0;
            // création de la liste des boutons famille
            buttonFs = new List<Button> { button7, button8, button9, button10, button11, button12, button13, button14 };
            // création de la liste des labels famille
            labelFs = new List<Label> { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8 };

            // création de la liste des boutons article
            buttonAs = new List<Button> { button15, button16, button17, button18, button19, button20, button21, button22 };
            // création de la liste des labels article
            labelAs = new List<Label> { label18, label20, label21, label22, label23, label24, label25, label26 };
            InitButton(buttonFs, labelFs);
            InitButton(buttonAs, labelAs);
            initZonePrix();
            InitInfoClient();
            Timer bg = new Timer();
            bg.Tick += (s, e) => { label2.Text = DateTime.Now.ToString("U"); };
            bg.Interval = 500;
            bg.Start();
        }

        public void initZonePrix()
        {
            SommSR.Text = "0";
            SommeP.Text = "0";
            Relicat.Text = "0";
            TotalRemz.Text = "0";
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



        private List<FamilleArticle> prodListFamille()
        {
            FamilleArticle Dflt = new FamilleArticle(0);
            Dflt.Description = "Articles sans réel famille";
            Dflt.Designation = "Autres";
            List<FamilleArticle> listInter = new List<FamilleArticle> { Dflt };

            List<Article> articless = new List<Article>();
            dpt = TOOLS.Constantes.Creneau.Depot;

            foreach (ArticleDepot arDpt in dpt.Articles)
            {
                articless.Add(arDpt.Article);
            }

            foreach (Article arT in articless)
            {
                //if (arT.Famille.Id < 1)
                //{ 
                //    arT.Famille = Dflt; Dflt.Articles.Add(arT);
                //}
                if (arT.Famille.Id > 0)
                {
                    if (!listInter.Contains(arT.Famille))
                    {
                        FamilleArticle f = BLL.FamilleArticleBll.One_(arT.Famille.Id);
                        f.Articles.Add(arT);
                        listInter.Add(f);
                        //listInter.Add(arT.Famille);
                    }
                    else
                    {
                        FamilleArticle f = listInter.Find(x => x.Id == arT.Famille.Id);
                        f.Articles.Add(arT);
                        listInter[listInter.FindIndex(x => x.Id == f.Id)] = f;
                    }
                }
                else
                {
                    FamilleArticle f = listInter.Find(x => x.Id == Dflt.Id);
                    f.Articles.Add(arT);
                    listInter[listInter.FindIndex(x => x.Id == f.Id)] = f;
                }

                //arT.Famille.Id;
                //BLL.FamilleArticleBll.One();
                //list.Add();
            }
            return listInter;
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
            ctl.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctl.Click += delegate(object sender, EventArgs e)
            {
                ctl.BackColor = Color.DarkGray;
                indTabA = 0;
                articles.Clear();
                articles.AddRange(cli.Articles);
                SearchDirectionA(2);
                ctl.Enabled = false;
                foreach (Button btn in buttonFs)
                {
                    if (btn != ctl)
                    {
                        btn.Enabled = true;
                    }
                }

                foreach (Button btn in buttonAs)
                {
                    if (btn != ctl)
                    {
                        btn.Enabled = true;
                    }
                }
            };

            lbl.Visible = true;
            lbl.Text = cli.Designation;
        }

        //modification des boutons des articles
        private void ModifButton(Button ctl, Article cli, Label lbl)
        {
            //cli = (Article)articles.ElementAt<Article>(indTabA);

            if ((cli.Photos != null) ?
                    ((cli.Photos.Count > 0) ?
                        ((cli.Photos[0] != null) ? cli.Photos[0].Trim().Equals("") : true)
                    : true)
                : true)
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
                contenu.Article = BLL.ArticleComBll.One(cli);
                Form_Caisse_Quantite f = new Form_Caisse_Quantite(this);
                f.ShowDialog();
                TOOLS.Utils.TotalRRRContenuDoc(fact, contenu);
                contenu.PrixTotal = contenu.Quantite * contenu.Article.Article.Prix;
                if (contenu.Quantite != 0)
                {
                    dataGridView1.Rows.Add(new object[] { contenu.Id, contenu.Article.Article.Designation,
                    contenu.Article.Article.Prix, contenu.Remise, contenu.Quantite, contenu.PrixTotal, null });

                    SommSR.Text = Convert.ToString(Convert.ToDouble(SommSR.Text) + contenu.PrixTotal);

                    //sauvegarde nouveau contenu
                }
                ctl.BackColor = Color.DarkGray;
                ctl.Enabled = false;
                btnReglement.Enabled = true;
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
                        indActu--;
                        return listRetour;
                    }
                    if ((indActu == list.Count - 1) || (list.Count == 0)) pgDroiteA.Enabled = false;
                    else pgDroiteA.Enabled = true;
                    if (indActu < 8) pgGaucheA.Enabled = false;
                    else pgGaucheA.Enabled = true;
                }
            }

            if (sens == 1)
            {
                if ((indActu % 8) != 0) indActu -= (indActu % 8); indActu--;
                for (int i = 0; i < 8; i++)
                {

                    if ((indActu >= 0) && (indActu < list.Count))
                    {
                        listRetour.Add(list.ElementAt<Article>(indActu));
                        indActu--;
                    }

                    if (indActu <= -1)
                    {
                        indActu++;
                        return listRetour;
                    }
                    if (indActu == list.Count - 1) pgDroiteA.Enabled = false;
                    else pgDroiteA.Enabled = true;
                    if (indActu < 8) pgGaucheA.Enabled = false;
                    else pgGaucheA.Enabled = true;
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

        private void Regler(object sender, EventArgs e)
        {
            Form_Caisse_Reglement f = new Form_Caisse_Reglement(this);
            f.ShowDialog();
        }

        private void NvoTicket_Click(object sender, EventArgs e)
        {
            if (archive)
            {
                contenu = new Contenu();

                InitButton(buttonAs, labelAs);
                initZonePrix();
                clientZero = BLL.ClientBll.Default();
                dataGridView1.Rows.Clear();
                panel4.Enabled = true;
                picClient.Enabled = true;
                btnEnregistrer.Enabled = true;
                archive = false;
                fact = new Facture();
                fact.TypeDoc = Constantes.TYPE_FV;
                fact.Statut = Constantes.ETAT_EN_ATTENTE;
                fact.Client = BLL.ClientBll.Default();
                fact.Categorie = fact.Client.Categorie;
                fact.HeureDoc = DateTime.Now;
                fact.MouvStock = true;
            }
            else
            {
                

            }
        }


        private void picClient_Click(object sender, EventArgs e)
        {
            Form_Choix_Client f = new Form_Choix_Client(this);
            f.ShowDialog();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //sauvegarde nouvelle facture
            Facture fa = new Facture();
            fa.Categorie = new CategorieComptable();
            fa.Client = clientZero;
            fa.DocumentLie = new Facture();
            fa.Entete = new Entete();
            fa.HeureDoc = DateTime.Now;
            //fa.MontantAvance = new CategorieComptable();
            //fact.NumDoc = TOOLS.Utils.GenererReference(TOOLS.Constantes.DOC_FACTURE);
            Facture f = new BLL.FactureBll(fact).Insert();
            fact.Id = f.Id;
        }

        private void picClient_Click_1(object sender, EventArgs e)
        {
            Form_Choix_Client f = new Form_Choix_Client(this);
            f.ShowDialog();
        }

        private void AddRowFacture(DataGridView data, Facture f)
        {
            if (f != null)
            {
                data.Rows.Add(new object[] { f.Id, f.NumDoc, f.HeureDoc.ToString("T"), f.Client.Nom_prenom, f.MontantTTC, f.MontantReste, null, f.Supp });
            }
        }

        public void setEnteteJour()
        {
            DateTime date = Convert.ToDateTime("2015-10-10");
            Entete e = BLL.EnteteBll.One(Constantes.Creneau, date);
            if ((e != null) ? e.Id > 0 : false)
            {
                Constantes.Entete = e;
                //Charge facture en attente
                dgv_facture_wait.Rows.Clear();
                foreach (Facture f in e.FacturesEnAttente)
                {
                    AddRowFacture(dgv_facture_wait, f);
                }

                //Charge facture en cours
                dgv_facture_cours.Rows.Clear();
                foreach (Facture f in e.FacturesEnCours)
                {
                    AddRowFacture(dgv_facture_cours, f);
                }

                //Charge facture regle
                dgv_facture_regle.Rows.Clear();
                foreach (Facture f in e.FacturesRegle)
                {
                    AddRowFacture(dgv_facture_regle, f);
                }

                //Charge commande
                dgv_commande.Rows.Clear();
                foreach (Facture f in e.Commandes)
                {
                    AddRowFacture(dgv_commande, f);
                }
            }
        }

        private void configFacture(Facture f)
        {
            if (f != null)
            {
                lb_numPiece.Text = f.NumDoc;
                txt_reference.Text = f.NumPiece;
                SommeP.Text = f.MontantTTC.ToString();
                Relicat.Text = f.MontantReste.ToString();
                txt_montantVerse.Text = f.MontantAvance.ToString();
                TotalRemz.Text = f.MontantRemise.ToString();
                SommSR.Text = f.MontantHT.ToString();
            }
            else
            {
                lb_numPiece.Text = Utils.GenererReference(Constantes.DOC_FACTURE);
                txt_reference.ResetText();
                SommeP.Text = "0";
                Relicat.Text = "0";
                txt_montantVerse.Text = "0";
                TotalRemz.Text = "0";
                SommSR.Text = "0";
            }
        }

        private void dgv_facture_wait_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
