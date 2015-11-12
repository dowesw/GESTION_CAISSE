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
        int nbrPgF;
        int nbrPgA;
        public bool archive;
        long rowFacture;
        bool suppFacture;
        DataGridView suppData;

        public double remboursement;
        public double apayer;
        public Client clientZero = new Client();
        public Contenu contenu = new Contenu();
        public Article articleGen = new Article();
        Facture fact = new Facture();
        Mensualite mensualite = new Mensualite();
        PieceCaisse reglement = new PieceCaisse();
        List<ModePaiement> modes;
        Form F_parent;

        public Form_Caisse_Click()
        {
            InitializeComponent();
            familles = new List<FamilleArticle>();
            //charger famillesa articles
            familles.Clear();
            //familles = BLL.FamilleArticleBll.Liste_("select * from yvs_base_famille_article");

            famillesCrits = new List<FamilleArticle>();
            articlesCrits = new List<Article>();
            articles = new List<Article>();
            clients = new List<Client>();
            modes = new List<ModePaiement>();

            contenu = new Contenu();

            ConfigForm();

            // tout réinitialiser
            archive = true;
            //btnReglement.Enabled = false;

            //panel4.Enabled = false;
            //picClient.Enabled = false;
            // btnEnregistrer.Enabled = false;
            //SearchDirectionF(2);
            LoadAll();
        }

        public Form_Caisse_Click(Form parent)
        {
            InitializeComponent();
            familles = new List<FamilleArticle>();
            //charger famillesa articles
            familles.Clear();
            //familles = BLL.FamilleArticleBll.Liste_("select * from yvs_base_famille_article");

            famillesCrits = new List<FamilleArticle>();
            articlesCrits = new List<Article>();
            articles = new List<Article>();
            clients = new List<Client>();
            modes = new List<ModePaiement>();
            if (parent != null)
            {
                F_parent = parent;
            }
            contenu = new Contenu();

            ConfigForm();

            // tout réinitialiser
            archive = true;
            //btnReglement.Enabled = false;

            //panel4.Enabled = false;
            //picClient.Enabled = false;
            // btnEnregistrer.Enabled = false;
            LoadAll();

        }

        public void ConfigForm()
        {
            this.Text = Constantes.APP_NAME + " : Principal";

            Timer bg = new Timer();
            bg.Tick += (s, e) => { lb_date.Text = DateTime.Now.ToString("U"); };
            bg.Interval = 500;
            bg.Start();

            familles.Clear();

            familles = prodListFamille();

            ResetFicheFacture();
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

            nbrPgF = ((familles.Count % 8) > 0) ? (familles.Count / 8) + 1 : (familles.Count / 8);
            btn_cpt_Famille.Text = "0/" + nbrPgF;

            InitFamille();
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
            NomClient.Text = clientZero.Tiers.Nom_prenom;
            AdresseClient.Text = clientZero.Tiers.Adresse;
            TelClient.Text = clientZero.Tiers.Tel;
            codeClient.Text = clientZero.Tiers.CodeTiers;
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
                btn.Enabled = true;
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

        private void LoadAll()
        {
            LoadAllModes();
            setEnteteJour();
        }

        public void LoadAllModes()
        {
            modes.Clear();
            string query = "select * FROM yvs_mode_paiement";
            modes = BLL.ModePaiementBll.Liste(query);
            com_mode.Items.Clear();
            com_mode.DisplayMember = "TypePaiement";
            com_mode.ValueMember = "Id";
            com_mode.DataSource = new BindingSource(modes, null);

            foreach (ENTITE.ModePaiement a in modes)
            {
                if ((a.TypePaiement != null) ? !a.TypePaiement.Trim().Equals("") : false)
                {
                    com_mode.AutoCompleteCustomSource.Add(a.TypePaiement);
                }
            }
            com_mode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_mode.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                if (arT.Famille.Id > 0)
                {
                    if (!listInter.Contains(arT.Famille))
                    {
                        FamilleArticle f = BLL.FamilleArticleBll.One_(arT.Famille.Id);
                        f.Articles.Add(arT);
                        listInter.Add(f);
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
            }
            return listInter;
        }

        //modification des boutons des familles
        private void ModifButton(Button ctl, FamilleArticle cli, Label lbl)
        {
            lbl.Visible = true;
            lbl.Text = cli.Designation;
            ctl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ctl.Text = "";
            ctl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            ctl.UseVisualStyleBackColor = true;
            ctl.Visible = true;
            ctl.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctl.Click += delegate(object sender, EventArgs e)
            {
                tabControl2.SelectedIndex = 1;
                ctl.BackColor = Color.DarkGray;
                indTabA = 0;
                articles.Clear();
                articles.AddRange(cli.Articles);

                nbrPgA = ((articles.Count % 8) > 1) ? (articles.Count / 8) + 1 : (articles.Count / 8);
                btn_cpt_Articles.Text = "0/" + nbrPgA;

                pgGaucheA.Enabled = false;
                pgDroiteA.Enabled = cli.Articles.Count > 8;

                InitArticle();
                ctl.Enabled = false;
                foreach (Button btn in buttonFs)
                {
                    if (btn != ctl)
                    {
                        btn.Enabled = true;
                    }
                }

                //foreach (Button btn in buttonAs)
                //{
                //    if (btn != ctl)
                //    {
                //        btn.Enabled = true;
                //    }
                //}
            };
        }

        //modification des boutons des articles
        private void ModifButton(Button ctl, Article cli, Label lbl)
        {
            lbl.Visible = true;
            lbl.Text = cli.Designation;
            ctl.BackgroundImage = (System.Drawing.Image)cli.Image;
            ctl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ctl.Text = "";
            ctl.UseVisualStyleBackColor = true;
            ctl.Visible = true;
            ctl.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            ctl.Click += delegate(object sender, EventArgs e)
            {
                contenu = new Contenu();

                if ((fact != null) ? fact.Id < 1 : true)
                {
                    Messages.ShowErreur("Vous devez dabord enregsitrer la facture!");
                    return;
                }
                else
                {
                    //sauvegarde nouveau contenu
                    contenu.Article = BLL.ArticleComBll.One(cli);
                    contenu.Facture = fact;
                    contenu.Prix = cli.Prix;
                    contenu.New_ = true;
                    //qté article
                    Form_Caisse_Quantite f = new Form_Caisse_Quantite(this);
                    f.Text = "Quantité de: " + cli.Designation;
                    f.ShowDialog();
                    if ((contenu.Quantite != 0) || (contenu.Quantite == null))
                    {
                        ctl.BackColor = Color.DarkGray;
                        ctl.Enabled = false;
                        btnReglement.Enabled = true;
                        contenu.PrixTotal = contenu.Quantite * contenu.Prix;
                        //SommSR.Text = Convert.ToString(Convert.ToDouble(SommSR.Text) + contenu.PrixTotal);
                    }
                }

                //contenu.Update=true;
                if (contenu.Control())
                {
                    if (!contenu.Update)
                    {
                        contenu.DateContenu = DateTime.Now;
                        Contenu c_ = new BLL.ContenuBll(contenu).Insert();
                        if ((c_ != null) ? c_.Id > 0 : false)
                        {
                            contenu.Id = c_.Id;
                            contenu.Update = true;
                            fact.Contenus.Add(contenu);
                            AddRowContenu(contenu);
                            contenu.Update = true;
                            Messages.Succes();
                        }
                    }
                    else
                    {
                        if (new BLL.ContenuBll(contenu).Update())
                        {
                            contenu.Update = true;
                            fact.Contenus[fact.Contenus.FindIndex(x => x.Id == contenu.Id)] = contenu;
                            UpdateRowContenu(contenu);

                            contenu.Update = true;
                            Messages.Succes();
                        }
                    }
                    Utils.MontantTotalDoc(fact);
                    configFacture(fact);
                    UpdateCurrentFacture(fact);
                }

            };
        }

        private Contenu RecopieViewContenu()
        {
            Contenu c = new Contenu();
            c.Id = contenu.Id;
            c.Article = contenu.Article;
            c.Facture = fact;
            //c.Prix = Convert.ToDouble((!txt_prix_article.Text.Trim().Equals("")) ? txt_prix_article.Text.Trim() : "0");
            //c.Quantite = Convert.ToDouble((!txt_qte_article.Text.Trim().Equals("")) ? txt_qte_article.Text.Trim() : "0");
            c.DateContenu = contenu.DateContenu;
            c.PrixTotal = c.Prix * c.Quantite;
            c.RemiseArt = contenu.RemiseArt;
            c.RemiseCat = contenu.RemiseCat;
            c.Remise = c.RemiseArt + c.RemiseCat;
            c.Ristourne = contenu.Ristourne;
            c.Commission = contenu.Commission;
            c.Update = contenu.Update;
            c.New_ = true;
            return c;
        }
        private void UpdateRowContenu(DataGridView data, Contenu f)
        {
            data.Rows.RemoveAt(Utils.GetRowData(data, f.Id));
            AddRowContenu(data, f);
        }

        private void UpdateRowContenu(Contenu c)
        {
            UpdateRowContenu(dataGridView1, c);
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

        private List<FamilleArticle> GetPack8F(List<FamilleArticle> list, bool droite)
        {
            List<FamilleArticle> listRetour = new List<FamilleArticle>();
            if (list.Count > 0)
            {
                if (droite)
                {

                    int charT = btn_cpt_Famille.Text.IndexOf('/');
                    int subStr = Convert.ToInt32(btn_cpt_Famille.Text.Substring(0, charT));
                    btn_cpt_Famille.Text = (subStr + 1).ToString() + "/" + nbrPgF;

                    int tail = (list.Count - indTabF) > 8 ? 8 : list.Count - indTabF;

                    for (int i = 0; i < tail; i++)
                    {
                        listRetour.Add(list.ElementAt<FamilleArticle>(indTabF));
                        indTabF++;
                    }

                    tail = (list.Count - indTabF) > 8 ? 8 : list.Count - indTabF;
                    if (tail == 0)
                        tail = 1;

                    if (indTabF + tail <= list.Count)
                        pgDroiteF.Enabled = true;
                    else
                    {
                        pgDroiteF.Enabled = false;
                        indTabF = list.Count;
                    }

                    pgGaucheF.Enabled = true;

                }
                else
                {
                    int charT2 = btn_cpt_Famille.Text.IndexOf('/');
                    int subStr2 = Convert.ToInt32(btn_cpt_Famille.Text.Substring(0, charT2));
                    btn_cpt_Famille.Text = (subStr2 - 1).ToString() + "/" + nbrPgF;

                    if ((indTabF % 8) > 0)
                    {
                        indTabF -= ((indTabF % 8));
                    }
                    else
                    {
                        indTabF -= 8;
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        indTabF--;
                        listRetour.Add(list.ElementAt<FamilleArticle>(indTabF));
                    }

                    if (indTabF < 8)
                    {
                        pgGaucheF.Enabled = false;
                        if (indTabF == 0)
                        {
                            indTabF = 8;
                        }
                    }
                    else
                    {
                        indTabF += 8;
                    }

                    pgDroiteF.Enabled = true;

                    listRetour.Reverse();
                }
            }
            else
            {
                pgDroiteF.Enabled = false;
                pgGaucheF.Enabled = false;
            }
            return listRetour;
        }

        private List<FamilleArticle> GetPack8F(ref int indActu, List<FamilleArticle> list, int sens, ref  bool b1F, ref bool b2F)
        {
            List<FamilleArticle> listRetour = new List<FamilleArticle>();

            if (sens == 2)
            {
                listRetour.Clear();

                int charT = btn_cpt_Famille.Text.IndexOf('/');
                int subStr = Convert.ToInt32(btn_cpt_Famille.Text.Substring(0, charT));
                btn_cpt_Famille.Text = (subStr + 1).ToString() + "/" + nbrPgF;

                if (b1F == true)
                {
                    b1F = false;
                    indActu += 8;
                }

                for (int i = 0; i < 8; i++)
                {
                    if ((indActu == list.Count - 1) || (list.Count == 0) || (subStr == nbrPgF)) pgDroiteF.Enabled = false;
                    else pgDroiteF.Enabled = true;

                    if (indActu < 8) pgGaucheF.Enabled = false;
                    else pgGaucheF.Enabled = true;

                    if (/*(indActu >= 0) &&*/ (indActu < list.Count))
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
                b2F = true;
            }

            if (sens == 1)
            {
                if (b2F == true)
                {
                    b2F = false;
                    if ((indActu % 8) == 7) indActu -= 8;
                }
                listRetour.Clear();

                int charT2 = btn_cpt_Articles.Text.IndexOf('/');
                int subStr2 = Convert.ToInt32(btn_cpt_Famille.Text.Substring(0, charT2));
                btn_cpt_Famille.Text = (subStr2 - 1).ToString() + "/" + nbrPgF;

                if ((indActu % 8) != 7) indActu -= ((indActu % 8));
                else indActu -= 8;
                //indActu--;

                for (int i = 0; i < 8; i++)
                {

                    if ((indActu >= 0) && (indActu < list.Count))
                    {
                        indActu--;
                        listRetour.Add(list.ElementAt<FamilleArticle>(indActu));
                    }

                    if (indActu <= -1)
                    {
                        indActu++;
                        listRetour.Reverse();
                        return listRetour;
                    }

                    if (indActu == list.Count - 1) pgDroiteF.Enabled = false;
                    else pgDroiteF.Enabled = true;

                    if (indActu < 8) pgGaucheF.Enabled = false;
                    else pgGaucheF.Enabled = true;
                }
                listRetour.Reverse();
                b1F = true;
            }
            return listRetour;
        }

        private bool b1A = false;
        private bool b2A = false;

        private List<Article> GetPack8A(List<Article> list, bool droite)
        {
            List<Article> listRetour = new List<Article>();
            if (list.Count > 0)
            {
                if (droite)
                {

                    int charT = btn_cpt_Articles.Text.IndexOf('/');
                    int subStr = Convert.ToInt32(btn_cpt_Articles.Text.Substring(0, charT));
                    btn_cpt_Articles.Text = (subStr + 1).ToString() + "/" + nbrPgA;

                    int tail = (list.Count - indTabA) > 8 ? 8 : list.Count - indTabA;

                    for (int i = 0; i < tail; i++)
                    {
                        listRetour.Add(list.ElementAt<Article>(indTabA));
                        indTabA++;
                    }

                    tail = (list.Count - indTabA) > 8 ? 8 : list.Count - indTabA;
                    if (tail == 0)
                        tail = 1;

                    if (indTabA + tail <= list.Count)
                        pgDroiteA.Enabled = true;
                    else
                    {
                        pgDroiteA.Enabled = false;
                        indTabA = list.Count;
                    }

                    pgGaucheA.Enabled = true;

                }
                else
                {
                    int charT2 = btn_cpt_Articles.Text.IndexOf('/');
                    int subStr2 = Convert.ToInt32(btn_cpt_Articles.Text.Substring(0, charT2));
                    btn_cpt_Articles.Text = (subStr2 - 1).ToString() + "/" + nbrPgA;

                    if ((indTabA % 8) > 0)
                    {
                        indTabA -= ((indTabA % 8));
                    }
                    else
                    {
                        indTabA -= 8;
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        indTabA--;
                        listRetour.Add(list.ElementAt<Article>(indTabA));
                    }

                    if (indTabA < 8)
                    {
                        pgGaucheA.Enabled = false;
                        if (indTabA == 0)
                        {
                            indTabA = 8;
                        }
                    }
                    else
                    {
                        indTabA += 8;
                    }

                    pgDroiteA.Enabled = true;

                    listRetour.Reverse();
                }
            }
            else
            {
                pgDroiteA.Enabled = false;
                pgGaucheA.Enabled = false;
            }
            return listRetour;
        }

        private List<Article> GetPack8A(ref int indActu, List<Article> list, int sens)
        {
            List<Article> listRetour = new List<Article>();

            if (sens == 2)
            {
                listRetour.Clear();

                int charT = btn_cpt_Articles.Text.IndexOf('/');
                int subStr = Convert.ToInt32(btn_cpt_Articles.Text.Substring(0, charT));
                btn_cpt_Articles.Text = (subStr + 1).ToString() + "/" + nbrPgA;

                if (b1A == true)
                {
                    b1A = false;
                    indActu += 8;
                }

                for (int i = 0; i < 8; i++)
                {
                    if ((indActu == list.Count - 1) || (list.Count == 0) || (subStr == nbrPgF)) pgDroiteA.Enabled = false;
                    else pgDroiteA.Enabled = true;

                    if (indActu < 8) pgGaucheA.Enabled = false;
                    else pgGaucheA.Enabled = true;

                    if (/*(indActu >= 0) &&*/ (indActu < list.Count))
                    {
                        listRetour.Add(list.ElementAt<Article>(indActu));
                        indActu++;
                    }

                    if (indActu == list.Count)
                    {
                        indActu--;
                        return listRetour;
                    }
                }
                b2A = true;
            }

            if (sens == 1)
            {
                if (b2A == true)
                {
                    b2A = false;
                    if ((indActu % 8) == 7) indActu -= 8;
                }
                listRetour.Clear();

                int charT2 = btn_cpt_Articles.Text.IndexOf('/');
                int subStr2 = Convert.ToInt32(btn_cpt_Articles.Text.Substring(0, charT2));
                btn_cpt_Articles.Text = (subStr2 - 1).ToString() + "/" + nbrPgF;

                if ((indActu % 8) != 7) indActu -= ((indActu % 8));
                else indActu -= 8;
                //indActu--;

                for (int i = 0; i < 8; i++)
                {

                    if ((indActu >= 0) && (indActu < list.Count))
                    {
                        indActu--;
                        listRetour.Add(list.ElementAt<Article>(indActu));
                    }

                    if (indActu <= -1)
                    {
                        indActu++;
                        listRetour.Reverse();
                        return listRetour;
                    }

                    if (indActu == list.Count - 1) pgDroiteA.Enabled = false;
                    else pgDroiteA.Enabled = true;

                    if (indActu < 8) pgGaucheA.Enabled = false;
                    else pgGaucheA.Enabled = true;
                }
                listRetour.Reverse();
                b1A = true;
            }
            return listRetour;
        }

        private void InitFamille()
        {
            int taill = (familles.Count > 8) ? 8 : familles.Count;
            for (int i = 0; i < taill; i++)
            {
                ModifButton(buttonFs.ElementAt<Button>(i), familles.ElementAt<FamilleArticle>(i), labelFs.ElementAt<Label>(i));
            }
            indTabF = taill;
            pgGaucheF.Enabled = false;
            pgGaucheA.Enabled = false;
            pgDroiteA.Enabled = false;
            pgDroiteF.Enabled = familles.Count > 8;
        }

        private void InitArticle()
        {
            int taill = (articles.Count > 8) ? 8 : articles.Count;
            for (int i = 0; i < taill; i++)
            {
                ModifButton(buttonAs.ElementAt<Button>(i), articles.ElementAt<Article>(i), labelAs.ElementAt<Label>(i));
            }
            indTabA = taill;
            pgGaucheA.Enabled = false;
            pgDroiteA.Enabled = familles.Count > 8;
        }

        private void SearchDirectionF(bool droite)
        {
            InitButton(buttonFs, labelFs);
            ResultatRechercheF("");
            List<FamilleArticle> seracList = GetPack8F(famillesCrits, droite);

            for (int i = 0; i < seracList.Count; i++)
            {
                ModifButton(buttonFs.ElementAt<Button>(i), seracList.ElementAt<FamilleArticle>(i), labelFs.ElementAt<Label>(i));
            }
        }

        private void SearchDirectionA(bool droite)
        {
            InitButton(buttonAs, labelAs);
            ResultatRechercheA("");
            List<Article> seracList = GetPack8A(articlesCrits, droite);
            var t = seracList.Count;
            for (int i = 0; i < seracList.Count; i++)
            {
                ModifButton(buttonAs.ElementAt<Button>(i), seracList.ElementAt<Article>(i), labelAs.ElementAt<Label>(i));
            }
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
            if ((fact != null) ? fact.Id > 0 : false)
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
            if ((Constantes.Entete != null) ? Constantes.Entete.Id > 0 : false)
            {
                //Charge facture en attente
                dgv_facture_wait.Rows.Clear();
                foreach (Facture f in Constantes.Entete.FacturesEnAttente)
                {
                    AddRowFacture(dgv_facture_wait, f);
                }

                //Charge facture en cours
                dgv_facture_cours.Rows.Clear();
                foreach (Facture f in Constantes.Entete.FacturesEnCours)
                {
                    AddRowFacture(dgv_facture_cours, f);
                }

                //Charge facture regle
                dgv_facture_regle.Rows.Clear();
                foreach (Facture f in Constantes.Entete.FacturesRegle)
                {
                    AddRowFacture(dgv_facture_regle, f);
                }

                //Charge commande
                dgv_commande.Rows.Clear();
                foreach (Facture f in Constantes.Entete.Commandes)
                {
                    AddRowFacture(dgv_commande, f);
                }
            }
            else
            {
                DateTime date = Convert.ToDateTime("2015-10-10");
                TOOLS.Utils.SetEnteteOfDay(date);
            }

            lb_montant_caisse.Text = Constantes.Entete.Montant.ToString();
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

        private void configClient(Client f)
        {
            if (f != null)
            {
                codeClient.Text = f.Tiers.CodeTiers;
                AdresseClient.Text = f.Tiers.Adresse;
                NomClient.Text = f.Tiers.Nom_prenom;
                TelClient.Text = f.Tiers.Tel;
                if (f.Tiers.Logo.Equals("") || f.Tiers.Logo == null)
                {
                    picClient.Image = ((System.Drawing.Image)global::GESTION_CAISSE.Properties.Resources.user_m1);
                }
                else
                {
                    String chemin = Application.StartupPath;
                    chemin += TOOLS.Constantes.FILE_SEPARATOR + f.Tiers.Logo;
                    picClient.Image = ((System.Drawing.Image)(resources.GetObject(chemin)));
                }
            }
            else
            {
                lb_numPiece.Text = Utils.GenererReference(Constantes.DOC_FACTURE);
                codeClient.Text = f.Tiers.CodeTiers;
                AdresseClient.Text = f.Tiers.Adresse;
                NomClient.Text = f.Tiers.Nom_prenom;
                TelClient.Text = f.Tiers.Tel;
                if (f.Tiers.Logo.Equals("") || f.Tiers.Logo == null)
                {
                    picClient.Image = ((System.Drawing.Image)global::GESTION_CAISSE.Properties.Resources.user_m1);
                }
                else
                {
                    String chemin = Application.StartupPath;
                    chemin += TOOLS.Constantes.FILE_SEPARATOR + f.Tiers.Logo;
                    picClient.Image = ((System.Drawing.Image)(resources.GetObject(chemin)));
                }
            }
        }


        private void NvoTicket_Click_1(object sender, EventArgs e)
        {
            contenu = new Contenu();
            ConfigForm();
            initZonePrix();
            clientZero = BLL.ClientBll.Default();
            dataGridView1.Rows.Clear();
            picClient.Enabled = true;
            btnEnregistrer.Enabled = true;
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
            initZonePrix();
            InitInfoClient();
            nbrPgA = 0;
            btn_cpt_Famille.Text = "0/" + nbrPgF;
            btn_cpt_Articles.Text = "0/" + nbrPgA;
            SearchDirectionF(true);
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
                    double montant = Convert.ToDouble(SommeVersee.Text);
                    if (montant > 0)
                    {
                        if (fact.Mensualites.Count > 0)
                        {
                            foreach (Mensualite m in fact.Mensualites)
                            {
                                if (montant > 0)
                                {
                                    if (m.MontantReste > 0)
                                    {
                                        PieceCaisse p = RecopieViewReglement(m, ((montant - m.MontantReste < 0) ? (m.MontantReste - montant) : m.MontantReste));
                                        PieceCaisse p_ = new BLL.PieceCaisseBll(p).Insert();
                                        if ((p_ != null) ? p_.Id > 0 : false)
                                        {
                                            montant = (montant - p.Montant < 0) ? montant - p.Montant : 0;
                                            p.Id = p_.Id;
                                            p.Update = true;
                                            m.Reglements.Add(p);
                                            m.MontantReste -= p.Montant;
                                            fact.Mensualites.Add(m);
                                            fact.MontantAvance += p.Montant;

                                            AddRowReglement(p);
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            Mensualite m = RecopieViewMensualite(montant);
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
                                    m.MontantReste -= p.Montant;
                                    fact.Mensualites.Add(m);
                                    fact.MontantAvance += p.Montant;

                                    AddRowReglement(p);
                                }
                            }
                        }

                        String etat = Constantes.ETAT_EN_COURS;
                        if (Convert.ToDouble(SommeVersee.Text) >= fact.MontantTTC)
                        {
                            etat = Constantes.ETAT_REGLE;
                        }
                        if (BLL.FactureBll.ChangeEtat(fact.Id, etat))
                        {
                            fact.MontantReste = (fact.MontantTTC - Convert.ToDouble(SommeVersee.Text) < 0) ? fact.MontantTTC - Convert.ToDouble(SommeVersee.Text) : 0;
                            DeleteCurrentFacture(fact);
                            fact.Statut = etat;
                            AddCurrentFacture(fact);
                        }
                        Messages.Succes();
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

        private void DeleteCurrentFacture(Facture f)
        {
            if ((f != null) ? f.Id > 0 : false)
            {
                String type = f.TypeDoc;
                String etat = f.Statut;
                switch (type)
                {
                    case Constantes.TYPE_BCV:
                        Constantes.Entete.Commandes.Remove(f);
                        dgv_commande.Rows.RemoveAt(Utils.GetRowData(dgv_commande, f.Id));
                        break;
                    case Constantes.TYPE_FV:
                        switch (etat)
                        {
                            case Constantes.ETAT_EN_ATTENTE:
                                Constantes.Entete.FacturesEnAttente.Remove(f);
                                dgv_facture_wait.Rows.RemoveAt(Utils.GetRowData(dgv_facture_wait, f.Id));
                                break;
                            case Constantes.ETAT_EN_COURS:
                                Constantes.Entete.FacturesEnCours.Remove(f);
                                dgv_facture_cours.Rows.RemoveAt(Utils.GetRowData(dgv_facture_cours, f.Id));
                                break;
                            case Constantes.ETAT_REGLE:
                                Constantes.Entete.FacturesRegle.Remove(f);
                                dgv_facture_regle.Rows.RemoveAt(Utils.GetRowData(dgv_facture_regle, f.Id));
                                break;
                        }
                        break;
                }
            }
        }

        private void ResetFicheFacture()
        {
            rowFacture = -1;
            fact = new Facture();
            fact.TypeDoc = Constantes.TYPE_FV;
            fact.Statut = Constantes.ETAT_EN_ATTENTE;
            fact.Client = BLL.ClientBll.Default();
            fact.Categorie = clientZero.Categorie;
            fact.HeureDoc = DateTime.Now;
            fact.MouvStock = true;
            dataGridView1.Rows.Clear();
            dgv_reglement.Rows.Clear();
            fact.Client = clientZero;
            com_typeDoc.Text = "Facture";
            SetStateFacture(true);
            configFacture(null);
            contenu = new Contenu();
        }

        private void AddRowContenu(DataGridView data, Contenu c)
        {
            if (c != null)
            {
                data.Rows.Add(new object[] { c.Id, c.Article.Article.Designation, c.Prix, c.Quantite, c.PrixTotal, null });
            }
        }

        private void AddRowContenu(Contenu c)
        {
            AddRowContenu(dataGridView1, c);
        }

        public void FullContenu(Facture f)
        {
            if (f != null)
            {
                foreach (Contenu c in f.Contenus)
                {
                    AddRowContenu(c);
                }
            }
        }

        public void FullReglement(Facture f)
        {
            if (f != null)
            {
                foreach (PieceCaisse p in f.Reglements)
                {
                    AddRowReglement(p);
                }
            }
        }

        private void PopulateViewFacture(Facture f)
        {
            ResetFicheFacture();
            fact = f;
            clientZero = f.Client;
            configFacture(f);
            FullContenu(f);
            FullReglement(f);
            btnEnregistrer.Enabled = !f.Statut.Equals(Constantes.ETAT_REGLE);
            btnReglement.Enabled = !f.Statut.Equals(Constantes.ETAT_REGLE);
            btn_regl_tick.Enabled = !f.Statut.Equals(Constantes.ETAT_REGLE);

            foreach (Button btn in buttonAs)
            {
                btn.Enabled = !f.Statut.Equals(Constantes.ETAT_REGLE);
            }
            SetStateFacture(false);
        }

        private void PopulateViewContenu(Contenu c)
        {
            contenu = new Contenu();
            contenu = c;
        }

        private void dgv_contenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells["idContenu"].Value != null)
                {
                    long id = Convert.ToInt64(dataGridView1.CurrentRow.Cells["idContenu"].Value.ToString());
                    if (id > 0)
                    {
                        Contenu c = fact.Contenus.Find(x => x.Id == id);
                        if (e.ColumnIndex == 5)
                        {
                            if (!fact.Statut.Equals(Constantes.ETAT_REGLE))
                            {
                                if (DialogResult.Yes == Messages.Confirmation("supprimer"))
                                {
                                    if (BLL.ContenuBll.Delete(c.Id))
                                    {
                                        dataGridView1.Rows.RemoveAt(Utils.GetRowData(dataGridView1, c.Id));
                                        fact.Contenus.Remove(c);
                                        Utils.MontantTotalDoc(fact);
                                        configFacture(fact);
                                        UpdateCurrentFacture(fact);

                                        Messages.Succes();
                                    }
                                }
                            }
                            else
                            {
                                Messages.ShowErreur("Vous ne pouvez pas supprimer ce contenu. car la facture est déja reglée");
                            }
                        }
                        else
                        {
                            PopulateViewContenu(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        private void dgv_commande_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_commande.CurrentRow.Cells["idCommande"].Value != null)
                {
                    long id = Convert.ToInt64(dgv_commande.CurrentRow.Cells["idCommande"].Value.ToString());
                    if (id > 0)
                    {
                        Facture f = Constantes.Entete.Commandes.Find(x => x.Id == id);

                        if (e.ColumnIndex == 6)
                        {
                            if (!f.Statut.Equals(Constantes.ETAT_REGLE) && f.Contenus.Count < 1)
                            {
                                if (DialogResult.Yes == Messages.Confirmation("supprimer"))
                                {
                                    if (BLL.FactureBll.Delete(f.Id))
                                    {
                                        dgv_commande.Rows.RemoveAt(Utils.GetRowData(dgv_commande, f.Id));
                                        Constantes.Entete.Commandes.Remove(f);
                                        ResetFicheFacture();
                                        Messages.Succes();
                                    }
                                }
                            }
                            else
                            {
                                if (DialogResult.Yes == Messages.Erreur_Oui_Non("Vous ne pouvez pas supprimer cette facture! La marquer?"))
                                {
                                    if (BLL.FactureBll.ChangeSupp(f.Id, true))
                                    {
                                        f.Supp = true;
                                        UpdateCurrentFacture(f);
                                        Messages.Succes();
                                    }
                                }
                            }
                        }
                        else
                        {
                            com_typeDoc.Text = "Commande";
                            PopulateViewFacture(f);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells["idContenu"].Value != null)
                {
                    long id = Convert.ToInt64(dataGridView1.CurrentRow.Cells["idContenu"].Value.ToString());
                    if (id > 0)
                    {
                        Contenu c = fact.Contenus.Find(x => x.Id == id);
                        if (e.ColumnIndex == 5)
                        {
                            if (!fact.Statut.Equals(Constantes.ETAT_REGLE))
                            {
                                if (DialogResult.Yes == Messages.Confirmation("supprimer"))
                                {
                                    if (BLL.ContenuBll.Delete(c.Id))
                                    {
                                        dataGridView1.Rows.RemoveAt(Utils.GetRowData(dataGridView1, c.Id));
                                        fact.Contenus.Remove(c);
                                        Utils.MontantTotalDoc(fact);
                                        configFacture(fact);
                                        UpdateCurrentFacture(fact);

                                        Messages.Succes();
                                    }
                                }
                            }
                            else
                            {
                                Messages.ShowErreur("Vous ne pouvez pas supprimer ce contenu. car la facture est déja reglée");
                            }
                        }
                        else
                        {
                            PopulateViewContenu(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        private void SetCurrentFacture(long id, bool supp, DataGridView data)
        {
            if (id > 0)
            {
                Facture f = new Facture(id);
                switch (data.Name)
                {
                    case "dgv_commande":
                        f = Constantes.Entete.Commandes.Find(x => x.Id == id);
                        f.Supp = supp;
                        Constantes.Entete.Commandes[Constantes.Entete.Commandes.FindIndex(x => x.Id == f.Id)] = f;
                        UpdateRowFacture(dgv_commande, f);
                        break;
                    case "dgv_facture_wait":
                        f = Constantes.Entete.FacturesEnAttente.Find(x => x.Id == id);
                        f.Supp = supp;
                        Constantes.Entete.FacturesEnAttente[Constantes.Entete.FacturesEnAttente.FindIndex(x => x.Id == f.Id)] = f;
                        UpdateRowFacture(dgv_facture_wait, f);
                        break;
                    case "dgv_facture_cours":
                        f = Constantes.Entete.FacturesEnCours.Find(x => x.Id == id);
                        f.Supp = supp;
                        Constantes.Entete.FacturesEnCours[Constantes.Entete.FacturesEnCours.FindIndex(x => x.Id == f.Id)] = f;
                        UpdateRowFacture(dgv_facture_cours, f);
                        break;
                    case "dgv_facture_regle":
                        f = Constantes.Entete.FacturesRegle.Find(x => x.Id == id);
                        f.Supp = supp;
                        Constantes.Entete.FacturesRegle[Constantes.Entete.FacturesRegle.FindIndex(x => x.Id == f.Id)] = f;
                        UpdateRowFacture(dgv_facture_regle, f);
                        break;
                }
            }
        }


        private void Form_Caisse_Click_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constantes.form_caisse_click = null;
        }

        private void Form_Caisse_Click_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Constantes.form_caisse_saisie == null)
            {
                if (DialogResult.OK == Messages.FermerApplication())
                {
                    Application.Exit();
                }
                else
                {
                    if (F_parent != null)
                        F_parent.Show();
                }
            }
        }

        private void Form_Caisse_Click_Load(object sender, EventArgs e)
        {
            Constantes.form_caisse_click = this;
            contenu = new Contenu();
        }

        private void com_typeDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            String type = com_typeDoc.Text;
            String reference = "FV/271015/0000";
            if (!fact.Update)
            {
                switch (type)
                {
                    case Constantes.TYPE_BCV_NAME:
                        reference = Utils.GenererReference(Constantes.DOC_COMMANDE);
                        fact.TypeDoc = Constantes.TYPE_BCV;
                        lb_totalVerse.Text = "Somme Avancée : ";
                        fact.MouvStock = false;
                        break;
                    case Constantes.TYPE_FV_NAME:
                        reference = Utils.GenererReference(Constantes.DOC_FACTURE);
                        fact.TypeDoc = Constantes.TYPE_FV;
                        lb_totalVerse.Text = "Somme Versée : ";
                        fact.MouvStock = true;
                        break;
                }
                fact.NumDoc = reference;
            }
            else
            {
                reference = fact.NumDoc;
            }
            lb_numPiece.Text = reference;
        }


        private void btn_theme_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Constantes.form_caisse_click = null;
            if (F_parent != null)
                new Form_Caisse_Saisie(F_parent).Show();
            else
                new Form_Caisse_Saisie().Show();
        }

        private void btn_deconnect_Click(object sender, EventArgs e)
        {
            if (F_parent != null)
            {
                Form_Login l = (Form_Login)F_parent;
                l.bubble.Visible = false;
                l.Show();
                this.Dispose();
            }
        }


        private void dgv_facture_regle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_facture_regle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int i = e.RowIndex;
            bool supp = (Boolean)((dgv_facture_regle.Rows[i].Cells[7].Value != null) ? dgv_facture_regle.Rows[i].Cells[7].Value : false);
            if (supp)
            {
                this.dgv_facture_regle.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;
            }
        }

        private void dgv_facture_regle_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgv_facture_regle.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    rowFacture = Convert.ToInt64(dgv_facture_regle.Rows[e.RowIndex].Cells[0].Value.ToString());
                    suppData = dgv_facture_regle;
                    bool supp = (Boolean)((dgv_facture_regle.Rows[e.RowIndex].Cells[7].Value != null) ? dgv_facture_regle.Rows[e.RowIndex].Cells[7].Value : false);
                    suppFacture = !supp;
                }
            }
        }

        private void dgv_facture_wait_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_facture_wait_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int i = e.RowIndex;
            bool supp = (Boolean)((dgv_facture_wait.Rows[i].Cells[7].Value != null) ? dgv_facture_wait.Rows[i].Cells[7].Value : false);
            if (supp)
            {
                this.dgv_facture_wait.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;
            }
        }

        private void dgv_facture_wait_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgv_facture_wait.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    rowFacture = Convert.ToInt64(dgv_facture_wait.Rows[e.RowIndex].Cells[0].Value.ToString());
                    suppData = dgv_facture_wait;
                    bool supp = (Boolean)((dgv_facture_wait.Rows[e.RowIndex].Cells[7].Value != null) ? dgv_facture_wait.Rows[e.RowIndex].Cells[7].Value : false);
                    suppFacture = !supp;
                }
            }
        }

        private void dgv_facture_cours_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int i = e.RowIndex;
            bool supp = (Boolean)((dgv_facture_cours.Rows[i].Cells[7].Value != null) ? dgv_facture_cours.Rows[i].Cells[7].Value : false);
            if (supp)
            {
                this.dgv_facture_cours.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;
            }
        }

        private void dgv_facture_cours_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgv_facture_cours.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    rowFacture = Convert.ToInt64(dgv_facture_cours.Rows[e.RowIndex].Cells[0].Value.ToString());
                    suppData = dgv_facture_cours;
                    bool supp = (Boolean)((dgv_facture_cours.Rows[e.RowIndex].Cells[7].Value != null) ? dgv_facture_cours.Rows[e.RowIndex].Cells[7].Value : false);
                    suppFacture = !supp;
                }
            }
        }

        private void dgv_facture_cours_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_commande_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgv_commande.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    rowFacture = Convert.ToInt64(dgv_commande.Rows[e.RowIndex].Cells[0].Value.ToString());
                    suppData = dgv_commande;
                    bool supp = (Boolean)((dgv_commande.Rows[e.RowIndex].Cells[7].Value != null) ? dgv_commande.Rows[e.RowIndex].Cells[7].Value : false);
                    suppFacture = !supp;
                }
            }
        }

        private void dgv_commande_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int i = e.RowIndex;
            bool supp = (Boolean)((dgv_commande.Rows[i].Cells[7].Value != null) ? dgv_commande.Rows[i].Cells[7].Value : false);
            if (supp)
            {
                this.dgv_commande.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;
            }
        }




        private void SommeP_TextChanged(object sender, EventArgs e)
        {
            SommeP.Text = string.Format("{0:#,##0.00}", double.Parse(SommeP.Text));
        }

        private void Relicat_TextChanged(object sender, EventArgs e)
        {
            //Relicat.Text = string.Format("{0:#,##0.00}", double.Parse(Relicat.Text));
            Relicat.Text = string.Format("{0:#,##0.00}", double.Parse(Relicat.Text));
            double reste = Convert.ToDouble(Relicat.Text);
            label14.Text = (reste < 0) ? "A Rembourser : " : "Reste : ";
        }

        private void SommeVersee_TextChanged(object sender, EventArgs e)
        {
            SommeVersee.Text = string.Format("{0:#,##0.00}", double.Parse(SommeVersee.Text));
            Relicat.Text = (Convert.ToDouble(SommeP.Text) - Convert.ToDouble(SommeVersee.Text)).ToString();

            //txt_montantVerse.Text = string.Format("{0:#,##0.00}", double.Parse(txt_montantVerse.Text));
            //txt_montantReste.Text = (Convert.ToDouble(txt_montantTTC.Text) - Convert.ToDouble(txt_montantVerse.Text)).ToString();

        }

        private void TotalRemz_TextChanged(object sender, EventArgs e)
        {
            TotalRemz.Text = string.Format("{0:#,##0.00}", double.Parse(TotalRemz.Text));
        }

        private void dgv_facture_wait_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_facture_wait.CurrentRow.Cells["idFactureWait"].Value != null)
                {
                    long id = Convert.ToInt64(dgv_facture_wait.CurrentRow.Cells["idFactureWait"].Value.ToString());
                    if (id > 0)
                    {
                        clients.Clear();
                        clients = BLL.ClientBll.Liste("select * from yvs_com_client");
                        Facture f = Constantes.Entete.FacturesEnAttente.Find(x => x.Id == id);
                        long idCli = f.Client.Id;
                        Client c = clients.Find(x => x.Id == idCli);
                        configClient(c);

                        if (e.ColumnIndex == 6)
                        {
                            if (!f.Statut.Equals(Constantes.ETAT_REGLE) && f.Contenus.Count < 1)
                            {
                                if (DialogResult.Yes == Messages.Confirmation("supprimer"))
                                {
                                    if (BLL.FactureBll.Delete(f.Id))
                                    {
                                        dgv_facture_wait.Rows.RemoveAt(Utils.GetRowData(dgv_facture_wait, f.Id));
                                        Constantes.Entete.FacturesEnAttente.Remove(f);
                                        ResetFicheFacture();
                                        Messages.Succes();
                                    }
                                }
                            }
                            else
                            {
                                if (DialogResult.Yes == Messages.Erreur_Oui_Non("Vous ne pouvez pas supprimer cette facture! La marquer?"))
                                {
                                    if (BLL.FactureBll.ChangeSupp(f.Id, true))
                                    {
                                        f.Supp = true;
                                        UpdateCurrentFacture(f);
                                        Messages.Succes();
                                    }
                                }
                            }
                        }
                        else
                        {
                            com_typeDoc.Text = "Facture";
                            PopulateViewFacture(f);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        private void dgv_facture_cours_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_facture_cours.CurrentRow.Cells["idFactureCours"].Value != null)
                {
                    long id = Convert.ToInt64(dgv_facture_cours.CurrentRow.Cells["idFactureCours"].Value.ToString());
                    if (id > 0)
                    {
                        clients.Clear();
                        clients = BLL.ClientBll.Liste("select * from yvs_com_client");
                        Facture f = Constantes.Entete.FacturesEnCours.Find(x => x.Id == id);
                        long idCli = f.Client.Id;
                        Client c = clients.Find(x => x.Id == idCli);
                        configClient(c);
                        if (e.ColumnIndex == 6)
                        {
                            if (!f.Statut.Equals(Constantes.ETAT_REGLE) && f.Contenus.Count < 1)
                            {
                                if (DialogResult.Yes == Messages.Confirmation("supprimer"))
                                {
                                    if (BLL.FactureBll.Delete(f.Id))
                                    {
                                        dgv_facture_cours.Rows.RemoveAt(Utils.GetRowData(dgv_facture_cours, f.Id));
                                        Constantes.Entete.FacturesEnCours.Remove(f);
                                        ResetFicheFacture();
                                        Messages.Succes();
                                    }
                                }
                            }
                            else
                            {
                                if (DialogResult.Yes == Messages.Erreur_Oui_Non("Vous ne pouvez pas supprimer cette facture! La marquer?"))
                                {
                                    if (BLL.FactureBll.ChangeSupp(f.Id, true))
                                    {
                                        f.Supp = true;
                                        UpdateCurrentFacture(f);
                                        Messages.Succes();
                                    }
                                }
                            }
                        }
                        else
                        {
                            com_typeDoc.Text = "Facture";
                            PopulateViewFacture(f);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        private void dgv_facture_regle_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_facture_regle.CurrentRow.Cells["idFactureRegle"].Value != null)
                {
                    long id = Convert.ToInt64(dgv_facture_regle.CurrentRow.Cells["idFactureRegle"].Value.ToString());
                    if (id > 0)
                    {
                        clients.Clear();
                        clients = BLL.ClientBll.Liste("select * from yvs_com_client");
                        Facture f = Constantes.Entete.FacturesRegle.Find(x => x.Id == id);
                        long idCli = f.Client.Id;
                        Client c = clients.Find(x => x.Id == idCli);
                        configClient(c);
                        if (e.ColumnIndex == 6)
                        {
                            if (!f.Statut.Equals(Constantes.ETAT_REGLE) && f.Contenus.Count < 1)
                            {
                                if (DialogResult.Yes == Messages.Confirmation("supprimer"))
                                {
                                    if (BLL.FactureBll.Delete(f.Id))
                                    {
                                        dgv_facture_regle.Rows.RemoveAt(Utils.GetRowData(dgv_facture_regle, f.Id));
                                        Constantes.Entete.FacturesRegle.Remove(f);
                                        ResetFicheFacture();
                                        Messages.Succes();
                                    }
                                }
                            }
                            else
                            {
                                if (DialogResult.Yes == Messages.Erreur_Oui_Non("Vous ne pouvez pas supprimer cette facture! La marquer?"))
                                {
                                    if (BLL.FactureBll.ChangeSupp(f.Id, true))
                                    {
                                        f.Supp = true;
                                        UpdateCurrentFacture(f);
                                        Messages.Succes();
                                    }
                                }
                            }
                        }
                        else
                        {
                            com_typeDoc.Text = "Facture";
                            PopulateViewFacture(f);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        private void dgv_commande_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_commande.CurrentRow.Cells["idCommande"].Value != null)
                {
                    long id = Convert.ToInt64(dgv_commande.CurrentRow.Cells["idCommande"].Value.ToString());
                    if (id > 0)
                    {
                        clients.Clear();
                        clients = BLL.ClientBll.Liste("select * from yvs_com_client");
                        Facture f = Constantes.Entete.Commandes.Find(x => x.Id == id);
                        long idCli = f.Client.Id;
                        Client c = clients.Find(x => x.Id == idCli);
                        configClient(c);
                        if (e.ColumnIndex == 6)
                        {
                            if (!f.Statut.Equals(Constantes.ETAT_REGLE) && f.Contenus.Count < 1)
                            {
                                if (DialogResult.Yes == Messages.Confirmation("supprimer"))
                                {
                                    if (BLL.FactureBll.Delete(f.Id))
                                    {
                                        dgv_commande.Rows.RemoveAt(Utils.GetRowData(dgv_commande, f.Id));
                                        Constantes.Entete.Commandes.Remove(f);
                                        ResetFicheFacture();
                                        Messages.Succes();
                                    }
                                }
                            }
                            else
                            {
                                if (DialogResult.Yes == Messages.Erreur_Oui_Non("Vous ne pouvez pas supprimer cette facture! La marquer?"))
                                {
                                    if (BLL.FactureBll.ChangeSupp(f.Id, true))
                                    {
                                        f.Supp = true;
                                        UpdateCurrentFacture(f);
                                        Messages.Succes();
                                    }
                                }
                            }
                        }
                        else
                        {
                            com_typeDoc.Text = "Commande";
                            PopulateViewFacture(f);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        private void com_mode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ModePaiement a = com_mode.SelectedItem as ModePaiement;
            a = modes.Find(x => x.Id == a.Id);
            reglement.Mode = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((fact != null) ? fact.Id > 0 : false)
            {
                new Form_Ticket(fact).Show();
            }
            else
            {
                Messages.ShowErreur("Vous devez selectionner une facture");
            }
        }

        private void btn_regl_tick_Click(object sender, EventArgs e)
        {
            btnReglement_Click(sender, e);
            if ((fact != null) ? fact.Id > 0 : false)
            {
                new Form_Ticket(fact).Show();
            }
        }

        private void lb_montant_caisse_TextChanged(object sender, EventArgs e)
        {
            lb_montant_caisse.Text = string.Format("{0:#,##0.00}", double.Parse(lb_montant_caisse.Text));
        }

        private void btn_approv_Click(object sender, EventArgs e)
        {
            new Form_Approvision().ShowDialog();
        }

        private void pgDroiteF_Click(object sender, EventArgs e)
        {
            SearchDirectionF(true);
        }

        private void pgGaucheF_Click(object sender, EventArgs e)
        {
            SearchDirectionF(false);
        }

        private void pgGaucheA_Click(object sender, EventArgs e)
        {
            SearchDirectionA(false);
        }

        private void pgDroiteA_Click(object sender, EventArgs e)
        {
            SearchDirectionA(true);
        }

        private void btn_actualise_Click(object sender, EventArgs e)
        {

        }

    }
}