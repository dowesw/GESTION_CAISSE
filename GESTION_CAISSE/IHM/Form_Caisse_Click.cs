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
        List<DataGridView> datagrids;

        Depot dpt = new Depot();
        int indTabF;
        int indTabA;
        public bool archive;

        public double remboursement;
        public double apayer;
        public Client clientZero = new Client();
        public Contenu contenu = new Contenu();
        public Article articleGen = new Article();
        Facture fact = new Facture();
        Mensualite mensualite = new Mensualite();
        PieceCaisse reglement = new PieceCaisse();



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
            //btnReglement.Enabled = false;

            //panel4.Enabled = false;
            //picClient.Enabled = false;
           // btnEnregistrer.Enabled = false;
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
            //lise datagridviews
            datagrids = new List<DataGridView> { dgv_commande, dgv_facture_cours, dgv_facture_regle, dgv_facture_wait, dgv_reglement };
            InitButton(buttonFs, labelFs);
            InitButton(buttonAs, labelAs);
            initZonePrix();
            InitInfoClient();
            Timer bg = new Timer();
            bg.Tick += (s, e) => { label2.Text = DateTime.Now.ToString("U"); };
            bg.Interval = 500;
            bg.Start();

            gestDgvs(null, 2, true);
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

        private void gestDgvs(DataGridView dgv, int lkel, bool b) 
        {
            if(lkel==1)
            {
                foreach(DataGridView d in datagrids){
                    if (d.Equals(dgv)) d.Visible = b;
                    else d.Visible=!b;
                }
            }

            if (lkel ==2)
            {
                foreach (DataGridView d in datagrids)
                {
                    d.Visible = false;
                }
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


        private PieceCaisse RecopieViewReglement(Mensualite m, double montant)
        {
            PieceCaisse p = new PieceCaisse();
            p.DatePiece = DateTime.Now;
            p.IdExterne = m.Id;
            p.TableEterne = Constantes.TABLE_EXTERNE_PIECE;
            p.Libelle = "Reglement Facture Vente";
            p.Montant = montant;
            p.Mouvement = Constantes.MOUV_ENTREE;
            p.Mode = reglement.Mode;
            p.OnCompte = reglement.OnCompte;
            p.NumRef = Utils.GenererReference(Constantes.DOC_PIECE);
            p.Statut = Constantes.ETAT_REGLE;
            return p;
        }

        private void createReglementByEcheance(double montant)
        {
            Mensualite m = new Mensualite();
            PieceCaisse p = RecopieViewReglement(m, m.MontantReste);

            double mtant = fact.MontantAvance - m.MontantReste;
        }

        private Mensualite RecopieViewMensualite(double montant)
        {
            Mensualite m = new Mensualite();
            m.DateMensualite = DateTime.Now;
            m.Etat = Constantes.ETAT_EN_ATTENTE;
            m.Facture = fact;
            m.Montant = montant;
            m.Reglements = mensualite.Reglements;
            return m;
        }

        private void AddRowReglement(DataGridView data, PieceCaisse p)
        {
            if (p != null)
            {
                data.Rows.Add(new object[] { p.Id, p.IdExterne, p.DatePiece, p.Montant });
            }
        }

        private void AddRowReglement(PieceCaisse p)
        {
            AddRowReglement(dgv_reglement, p);
        }

        private void UpdateRowReglement(DataGridView data, PieceCaisse f)
        {
            data.Rows.RemoveAt(Utils.GetRowData(data, f.Id));
            AddRowReglement(data, f);
        }

        private void UpdateRowReglement(PieceCaisse c)
        {
            UpdateRowReglement(dgv_reglement, c);
        }

        private void Regler(object sender, EventArgs e)
        {
            Form_Caisse_Reglement f = new Form_Caisse_Reglement(this);
            f.ShowDialog();
            if ((fact!= null) ? fact.Id > 0 : false)
            {
                if (fact.MontantReste > 0)
                {
                    if (Convert.ToDouble(SommeVersee.Text) > 0)
                    {
                        Mensualite m = new Mensualite();
                        if (fact.Mensualites.Count > 0)
                        {
                            foreach (Mensualite m_ in fact.Mensualites)
                            {
                                if (m_.MontantReste > 0)
                                {
                                    m = m_;
                                    break;
                                }
                            }
                        }
                        if (m.Id > 0)
                        {
                            createReglementByEcheance(fact.MontantAvance);
                        }
                        else
                        {
                            m = RecopieViewMensualite(fact.MontantAvance);
                            Mensualite m_ = new BLL.MensualiteBll(m).Insert();
                            if ((m_ != null) ? m_.Id > 0 : false)
                            {
                                m.Id = m_.Id;
                                m.Update = true;
                                PieceCaisse p = RecopieViewReglement(m, m.Montant);
                                PieceCaisse p_ = new BLL.PieceCaisseBll(p).Insert();
                                if ((p_ != null) ? p_.Id > 0 : false)
                                {
                                    p.Id = p_.Id;
                                    p.Update = true;
                                    m.Reglements.Add(p);
                                    fact.Mensualites.Add(m);
                                    AddRowReglement(p);
                                    Messages.Succes();
                                }
                            }
                        }
                    }
                    else
                    {
                        Messages.ShowErreur("Vous devez entrer le montant!");
                    }
                }
                else
                {
                    Messages.ShowErreur("cette facture a deja été réglée!");
                }
            }
            else
            {
                Messages.ShowErreur("Vous devez selectionner une facture!");
            }
        }

        private void SetStateFacture(bool etat)
        {
            com_typeDoc.Enabled = etat;
            txt_reference.Enabled = etat;
        }


        private void NvoTicket_Click(object sender, EventArgs e)
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

            com_typeDoc.Text = "Facture";
            SetStateFacture(true);
            configFacture(null);

        }


        private void picClient_Click(object sender, EventArgs e)
        {
            Form_Choix_Client f = new Form_Choix_Client(this);
            f.ShowDialog();
        }




        private Facture RecopieViewFacture()
        {
            Facture f = new Facture();
            f.Id = fact.Id;
            f.Categorie = fact.Categorie;
            f.Client = clientZero;
            f.Entete = Constantes.Entete;
            f.HeureDoc = DateTime.Now;
            f.MontantAvance = Convert.ToDouble(SommeVersee.Text.Trim());
            f.MontantTTC = Convert.ToDouble(SommeP.Text.Trim());
            f.MontantReste = Convert.ToDouble(Relicat.Text.Trim());
            f.Update = fact.Update;
            f.Statut = fact.Statut;
            f.TypeDoc = fact.TypeDoc;
            f.Solde = fact.Solde;
            if (fact.Update)
            {
                f.NumDoc = lb_numPiece.Text;
            }
            else
            {
                switch (fact.TypeDoc)
                {
                    case Constantes.TYPE_BCV:
                        f.NumDoc = Utils.GenererReference(Constantes.DOC_COMMANDE);
                        break;
                    case Constantes.TYPE_FV:
                        f.NumDoc = Utils.GenererReference(Constantes.DOC_FACTURE);
                        break;
                }
            }
            f.NumPiece = txt_reference.Text.Trim();
            f.MontantCommission = fact.MontantCommission;
            f.MontantHT = fact.MontantHT;
            f.MontantRemise = fact.MontantRemise;
            f.MontantRistourne = fact.MontantRistourne;
            f.MontantTaxe = fact.MontantTaxe;
            f.New_ = true;
            f.Contenus = fact.Contenus;
            f.Mensualites = fact.Mensualites;
            f.Remises = fact.Remises;
            f.MouvStock = fact.MouvStock;
            return f;
        }

        private void AddCurrentFacture(Facture f)
        {
            if (f != null)
            {
                String type = f.TypeDoc;
                String etat = f.Statut;
                switch (type)
                {
                    case Constantes.TYPE_BCV:
                        Constantes.Entete.Commandes.Add(f);
                        AddRowFacture(dgv_commande, f);
                        break;
                    case Constantes.TYPE_FV:
                        switch (etat)
                        {
                            case Constantes.ETAT_EN_ATTENTE:
                                Constantes.Entete.FacturesEnAttente.Add(f);
                                AddRowFacture(dgv_facture_wait, f);
                                break;
                            case Constantes.ETAT_EN_COURS:
                                Constantes.Entete.FacturesEnCours.Add(f);
                                AddRowFacture(dgv_facture_cours, f);
                                break;
                            case Constantes.ETAT_REGLE:
                                Constantes.Entete.FacturesRegle.Add(f);
                                AddRowFacture(dgv_facture_regle, f);
                                break;
                        }
                        break;
                }
            }
        }

        private void UpdateRowFacture(DataGridView data, Facture f)
        {
            data.Rows.RemoveAt(Utils.GetRowData(data, f.Id));
            AddRowFacture(data, f);
        }

        private void UpdateCurrentFacture(Facture f)
        {
            if ((f != null) ? f.Id > 0 : false)
            {
                String type = f.TypeDoc;
                String etat = f.Statut;
                switch (type)
                {
                    case Constantes.TYPE_BCV:
                        Constantes.Entete.Commandes[Constantes.Entete.Commandes.FindIndex(x => x.Id == f.Id)] = f;
                        UpdateRowFacture(dgv_commande, f);
                        break;
                    case Constantes.TYPE_FV:
                        switch (etat)
                        {
                            case Constantes.ETAT_EN_ATTENTE:
                                Constantes.Entete.FacturesEnAttente[Constantes.Entete.FacturesEnAttente.FindIndex(x => x.Id == f.Id)] = f;
                                UpdateRowFacture(dgv_facture_wait, f);
                                break;
                            case Constantes.ETAT_EN_COURS:
                                Constantes.Entete.FacturesEnCours[Constantes.Entete.FacturesEnCours.FindIndex(x => x.Id == f.Id)] = f;
                                UpdateRowFacture(dgv_facture_cours, f);
                                break;
                            case Constantes.ETAT_REGLE:
                                Constantes.Entete.FacturesRegle[Constantes.Entete.FacturesRegle.FindIndex(x => x.Id == f.Id)] = f;
                                UpdateRowFacture(dgv_facture_regle, f);
                                break;
                        }
                        break;
                }
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //sauvegarde nouvelle facture
            //Facture fa = new Facture();
            //fa.Categorie = new CategorieComptable();
            //fa.Client = clientZero;
            //fa.DocumentLie = new Facture();
            //fa.Entete = new Entete();
            //fa.HeureDoc = DateTime.Now;
            ////fa.MontantAvance = new CategorieComptable();
            ////fact.NumDoc = TOOLS.Utils.GenererReference(TOOLS.Constantes.DOC_FACTURE);
            //Facture f = new BLL.FactureBll(fact).Insert();
            //fact.Id = f.Id;


            Facture f = RecopieViewFacture();
            if (f.Control())
            {
                if (!f.Update)
                {
                    Facture f_ = new BLL.FactureBll(f).Insert();
                    if ((f_ != null) ? f_.Id > 0 : false)
                    {
                        f.Id = f_.Id;
                        f.Update = true;
                        fact.Id = f_.Id;
                        AddCurrentFacture(f);
                        fact.Update = true;
                        Messages.Succes();
                    }
                }
                else
                {
                    if (new BLL.FactureBll(f).Update())
                    {
                        f.Update = true;
                        UpdateCurrentFacture(f);
                        fact.Update = true;
                        Messages.Succes();
                    }
                }
            }
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
                SommeVersee.Text = f.MontantAvance.ToString();
                TotalRemz.Text = f.MontantRemise.ToString();
                SommSR.Text = f.MontantHT.ToString();
            }
            else
            {
                lb_numPiece.Text = Utils.GenererReference(Constantes.DOC_FACTURE);
                txt_reference.ResetText();
                SommeP.Text = "0";
                Relicat.Text = "0";
                SommeVersee.Text = "0";
                TotalRemz.Text = "0";
                SommSR.Text = "0";
            }
        }

        private void bntEnCours_Click(object sender, EventArgs e)
        {
            groupBox7.Text = "Historique des factures en Cours";
            groupBox7.Visible = true;
            gestDgvs(dgv_facture_cours,1,true);
            panel6.Visible = false;
        }

        private void bntEnAttente_Click(object sender, EventArgs e)
        {
            groupBox7.Text = "Historique des factures en Attentes";
            groupBox7.Visible = true;
            gestDgvs(dgv_facture_wait, 1, true);
            panel6.Visible = false;
        }

        private void btnCmd_Click(object sender, EventArgs e)
        {
            groupBox7.Text = "Historique des Commandes";
            groupBox7.Visible = true;
            gestDgvs(dgv_commande, 1, true);
            panel6.Visible = false;
        }

        private void bntRefHist_Click(object sender, EventArgs e)
        {
            groupBox7.Text = "Historique des factures réglées";
            groupBox7.Visible = true;
            gestDgvs(dgv_facture_regle, 1, true);
            panel6.Visible = false;
        }

        private void bntEncaissmts_Click(object sender, EventArgs e)
        {
            groupBox7.Text = "Historique des Encaissements";
            groupBox7.Visible = true;
            gestDgvs(dgv_reglement, 1, true);
            panel6.Visible = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            gestDgvs(null, 2, false);
            groupBox7.Visible =false;
            panel6.Visible = true;
        }

        private void NvoTicket_Click_1(object sender, EventArgs e)
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

            com_typeDoc.Text = "Facture";
            SetStateFacture(true);
            configFacture(null);
        }

        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {
            Facture f = RecopieViewFacture();
            if (f.Control())
            {
                if (!f.Update)
                {
                    Facture f_ = new BLL.FactureBll(f).Insert();
                    if ((f_ != null) ? f_.Id > 0 : false)
                    {
                        f.Id = f_.Id;
                        f.Update = true;
                        fact.Id = f_.Id;
                        AddCurrentFacture(f);
                        fact.Update = true;
                        Messages.Succes();
                    }
                }
                else
                {
                    if (new BLL.FactureBll(f).Update())
                    {
                        f.Update = true;
                        UpdateCurrentFacture(f);
                        fact.Update = true;
                        Messages.Succes();
                    }
                }
            }
        }

        private void btnReglement_Click(object sender, EventArgs e)
        {
           
            if ((fact != null) ? fact.Id > 0 : false)
            {
                Form_Caisse_Reglement f = new Form_Caisse_Reglement(this);
                f.ShowDialog();

                if (fact.MontantReste > 0)
                {
                    if (Convert.ToDouble(SommeVersee.Text) > 0)
                    {
                        Mensualite m = new Mensualite();
                        if (fact.Mensualites.Count > 0)
                        {
                            foreach (Mensualite m_ in fact.Mensualites)
                            {
                                if (m_.MontantReste > 0)
                                {
                                    m = m_;
                                    break;
                                }
                            }
                        }
                        if (m.Id > 0)
                        {
                            createReglementByEcheance(fact.MontantAvance);
                        }
                        else
                        {
                            m = RecopieViewMensualite(fact.MontantAvance);
                            Mensualite m_ = new BLL.MensualiteBll(m).Insert();
                            if ((m_ != null) ? m_.Id > 0 : false)
                            {
                                m.Id = m_.Id;
                                m.Update = true;
                                PieceCaisse p = RecopieViewReglement(m, m.Montant);
                                PieceCaisse p_ = new BLL.PieceCaisseBll(p).Insert();
                                if ((p_ != null) ? p_.Id > 0 : false)
                                {
                                    p.Id = p_.Id;
                                    p.Update = true;
                                    m.Reglements.Add(p);
                                    fact.Mensualites.Add(m);
                                    AddRowReglement(p);
                                    Messages.Succes();
                                }
                            }
                        }
                    }
                    else
                    {
                        Messages.ShowErreur("Vous devez entrer le montant!");
                    }
                }
                else
                {
                    Messages.ShowErreur("cette facture a deja été réglée!");
                }
            }
            else
            {
                Messages.ShowErreur("Vous devez selectionner une facture!");
            }
        }

    }
}
