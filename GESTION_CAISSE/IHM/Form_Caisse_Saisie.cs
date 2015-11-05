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
    public partial class Form_Caisse_Saisie : Form
    {
        List<Article> articles;
        List<ModePaiement> modes;
        List<Client> clients;

        public Facture facture = new Facture();
        Depot depot = new Depot();

        Contenu contenu = new Contenu();
        Mensualite mensualite = new Mensualite();
        PieceCaisse reglement = new PieceCaisse();

        long rowFacture;
        bool suppFacture;
        DataGridView suppData;

        Form F_parent;

        public Form_Caisse_Saisie()
        {
            InitializeComponent();
            articles = new List<Article>();
            modes = new List<ModePaiement>();
            clients = new List<Client>();

            configForm();
            LoadAll();
        }

        public Form_Caisse_Saisie(Form parent)
        {
            InitializeComponent();
            articles = new List<Article>();
            modes = new List<ModePaiement>();
            clients = new List<Client>();

            configForm();
            LoadAll();
            F_parent = parent;
        }

        private void configForm()
        {
            depot = Constantes.Creneau.Depot;
            this.Text = Constantes.APP_NAME + " : Principal";

            lb_numPiece.Text = Utils.GenererReference(Constantes.DOC_FACTURE);
            lb_nom_agence.Text = Constantes.Agence.Designation;
            lb_nom_user.Text = Constantes.Users.NomUser;
            lb_nom_depot.Text = depot.Designation;
            lb_heure_debut_tranch.Text = Constantes.Creneau.Tranche.HeureDebut.ToString("T");
            lb_heure_fin_tranch.Text = Constantes.Creneau.Tranche.HeureFin.ToString("T");

            Timer timer1 = new Timer();
            timer1.Tick += (s, e) => { lb_date.Text = DateTime.Now.ToString("U"); };
            timer1.Interval = 100;
            timer1.Start();
        }

        private void configClient(Client a)
        {
            lb_adr_client.Text = a.Tiers.Adresse;
            lb_nom_client.Text = a.Tiers.Nom_prenom;
            lb_tel_client.Text = a.Tiers.Tel;
        }

        private void configFacture(Facture f)
        {
            if (f != null)
            {
                lb_numPiece.Text = f.NumDoc;
                txt_reference.Text = f.NumPiece;
                txt_montantTTC.Text = f.MontantTTC.ToString();
                txt_montantReste.Text = f.MontantReste.ToString();
                txt_montantVerse.Text = f.MontantAvance.ToString();
                txt_montantRemise.Text = f.MontantRemise.ToString();
                txt_montantHt.Text = f.MontantHT.ToString();
            }
            else
            {
                lb_numPiece.Text = Utils.GenererReference(Constantes.DOC_FACTURE);
                txt_reference.ResetText();
                txt_montantTTC.Text = "0";
                txt_montantReste.Text = "0";
                txt_montantVerse.Text = "0";
                txt_montantRemise.Text = "0";
                txt_montantHt.Text = "0";
            }
        }

        private void LoadAll()
        {
            LoadAllArticle();
            LoadAllModes();
            LoadAllClients();

            SetClientDefaut();
            setEnteteJour();
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

        public void SetClientDefaut()
        {
            Client v = BLL.ClientBll.Default();
            com_client.SelectedIndex = clients.FindIndex(a => a.Id == v.Id);
            facture.Client = v;
            facture.Categorie = v.Categorie;
        }

        public void LoadAllClients()
        {
            clients.Clear();
            string query = "select * FROM yvs_com_client c inner join yvs_tiers t on c.tiers = t.id where t.agence = " + Constantes.Agence.Id;
            clients = BLL.ClientBll.Liste(query);
            com_client.Items.Clear();
            com_client.DisplayMember = "Nom_prenom";
            com_client.ValueMember = "Id";
            com_client.DataSource = new BindingSource(clients, null);

            foreach (ENTITE.Client a in clients)
            {
                if ((a.Tiers != null) ? a.Tiers.Id > 0 : false)
                    if ((a.Tiers.Nom_prenom != null) ? !a.Tiers.Nom_prenom.Trim().Equals("") : false)
                    {
                        com_client.AutoCompleteCustomSource.Add(a.Tiers.Nom_prenom);
                    }
            }
            com_client.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_client.AutoCompleteSource = AutoCompleteSource.CustomSource;
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

        public void LoadAllArticle()
        {
            articles.Clear();

            foreach (ArticleDepot a in depot.Articles)
            {
                articles.Add(a.Article);
            }

            com_article.Items.Clear();
            com_article.DisplayMember = "Designation";
            com_article.ValueMember = "Id";
            com_article.DataSource = new BindingSource(articles, null);

            com_article.AutoCompleteCustomSource.Clear();
            foreach (ENTITE.Article a in articles)
            {
                if ((a.Designation != null) ? !a.Designation.Trim().Equals("") : false)
                {
                    com_article.AutoCompleteCustomSource.Add(a.Designation);
                }
            }
            com_article.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_article.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void FullArticlesByName()
        {
            com_article.AutoCompleteCustomSource.Clear();
            foreach (ENTITE.Article a in articles)
            {
                if ((a.Designation != null) ? !a.Designation.Trim().Equals("") : false)
                {
                    com_article.AutoCompleteCustomSource.Add(a.Designation);
                }
            }
        }

        public void FullArticlesByRef()
        {
            com_article.AutoCompleteCustomSource.Clear();
            foreach (ENTITE.Article a in articles)
            {
                if ((a.RefArt != null) ? !a.RefArt.Trim().Equals("") : false)
                {
                    com_article.AutoCompleteCustomSource.Add(a.RefArt);
                }
            }
        }

        private void AddRowFacture(DataGridView data, Facture f)
        {
            if (f != null)
            {
                data.Rows.Add(new object[] { f.Id, f.NumDoc, f.HeureDoc.ToString("T"), f.Client.Nom_prenom, f.MontantTTC, f.MontantReste, null, f.Supp });
            }
        }

        private void UpdateRowFacture(DataGridView data, Facture f)
        {
            data.Rows.RemoveAt(Utils.GetRowData(data, f.Id));
            AddRowFacture(data, f);
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
            AddRowContenu(dgv_contenu, c);
        }

        private void UpdateRowContenu(DataGridView data, Contenu f)
        {
            data.Rows.RemoveAt(Utils.GetRowData(data, f.Id));
            AddRowContenu(data, f);
        }

        private void UpdateRowContenu(Contenu c)
        {
            UpdateRowContenu(dgv_contenu, c);
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

        private void SetStateFacture(bool etat)
        {
            com_typeDoc.Enabled = etat;
            com_client.Enabled = etat;
            txt_reference.Enabled = etat;
        }


        private void ResetFicheFacture()
        {
            rowFacture = -1;
            facture = new Facture();
            facture.TypeDoc = Constantes.TYPE_FV;
            facture.Statut = Constantes.ETAT_EN_ATTENTE;
            facture.Client = BLL.ClientBll.Default();
            facture.Categorie = facture.Client.Categorie;
            facture.HeureDoc = DateTime.Now;
            facture.MouvStock = true;
            com_client.ResetText();
            dgv_contenu.Rows.Clear();
            dgv_reglement.Rows.Clear();
            configClient(facture.Client);
            com_typeDoc.Text = "Facture";
            SetStateFacture(true);
            configFacture(null);
            ResetFicheContenu();
        }

        private void ResetFicheContenu()
        {
            txt_prix_article.Text = "0";
            txt_qte_article.Text = "0";
            com_article.ResetText();
            contenu = new Contenu();
        }

        private Facture RecopieViewFacture()
        {
            Facture f = new Facture();
            f.Id = facture.Id;
            f.Categorie = facture.Categorie;
            f.Client = facture.Client;
            f.Entete = Constantes.Entete;
            f.HeureDoc = DateTime.Now;
            f.MontantAvance = Convert.ToDouble(txt_montantVerse.Text.Trim());
            f.MontantTTC = Convert.ToDouble(txt_montantTTC.Text.Trim());
            f.MontantReste = Convert.ToDouble(txt_montantReste.Text.Trim());
            f.Update = facture.Update;
            f.Statut = facture.Statut;
            f.TypeDoc = facture.TypeDoc;
            f.Solde = facture.Solde;
            if (facture.Update)
            {
                f.NumDoc = lb_numPiece.Text;
            }
            else
            {
                switch (facture.TypeDoc)
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
            f.MontantCommission = facture.MontantCommission;
            f.MontantHT = facture.MontantHT;
            f.MontantRemise = facture.MontantRemise;
            f.MontantRistourne = facture.MontantRistourne;
            f.MontantTaxe = facture.MontantTaxe;
            f.New_ = true;
            f.Contenus = facture.Contenus;
            f.Mensualites = facture.Mensualites;
            f.Remises = facture.Remises;
            f.MouvStock = facture.MouvStock;
            return f;
        }

        private Contenu RecopieViewContenu()
        {
            Contenu c = new Contenu();
            c.Id = contenu.Id;
            c.Article = contenu.Article;
            c.Facture = facture;
            c.Prix = Convert.ToDouble((!txt_prix_article.Text.Trim().Equals("")) ? txt_prix_article.Text.Trim() : "0");
            c.Quantite = Convert.ToDouble((!txt_qte_article.Text.Trim().Equals("")) ? txt_qte_article.Text.Trim() : "0");
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

        private Mensualite RecopieViewMensualite(double montant)
        {
            Mensualite m = new Mensualite();
            m.DateMensualite = DateTime.Now;
            m.Etat = Constantes.ETAT_EN_ATTENTE;
            m.Facture = facture;
            m.Montant = montant;
            m.Reglements = mensualite.Reglements;
            return m;
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
            p.NumPiece = Utils.GenererReference(Constantes.DOC_PIECE);
            p.NumRef = p.NumPiece + " - " + facture.NumDoc;
            p.Statut = Constantes.ETAT_REGLE;
            return p;
        }

        private PieceCaisse RecopieViewReglement(double montant)
        {
            PieceCaisse p = new PieceCaisse();
            p.DatePiece = DateTime.Now;
            p.IdExterne = mensualite.Id;
            p.TableEterne = Constantes.TABLE_EXTERNE_PIECE;
            p.Libelle = "Reglement Facture Vente";
            p.Montant = montant;
            p.Mouvement = Constantes.MOUV_ENTREE;
            p.Mode = reglement.Mode;
            p.OnCompte = reglement.OnCompte;
            p.NumPiece = Utils.GenererReference(Constantes.DOC_PIECE);
            p.NumRef = p.NumPiece + " - " + facture.NumDoc;
            p.Statut = Constantes.ETAT_REGLE;
            return p;
        }

        private void PopulateViewFacture(Facture f)
        {
            ResetFicheFacture();
            facture = f;
            configClient(f.Client);
            configFacture(f);
            FullContenu(f);
            FullReglement(f);
            com_client.SelectedText = clients.Find(a => a.Id == facture.Client.Id).Nom_prenom;
            btn_save.Enabled = !f.Statut.Equals(Constantes.ETAT_REGLE);
            btn_reglement.Enabled = !f.Statut.Equals(Constantes.ETAT_REGLE);
            btn_regl_tick.Enabled = !f.Statut.Equals(Constantes.ETAT_REGLE);
            btn_add_contenu.Enabled = !f.Statut.Equals(Constantes.ETAT_REGLE);
            txt_montantVerse.ReadOnly = f.Statut.Equals(Constantes.ETAT_REGLE);
            SetStateFacture(false);
        }

        private void PopulateViewContenu(Contenu c)
        {
            ResetFicheContenu();
            contenu = c;
            com_article.SelectedText = articles.Find(a => a.Id == c.Article.Article.Id).Designation;
            txt_prix_article.Text = c.Prix.ToString();
            txt_qte_article.Text = c.Quantite.ToString();
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

        private void Form_Caisse_Saisie_Load(object sender, EventArgs e)
        {
            Constantes.form_caisse_saisie = this;
            ResetFicheContenu();
        }

        private void Form_Caisse_Saisie_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constantes.form_caisse_saisie = null;
        }

        private void Form_Caisse_Saisie_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Constantes.form_caisse_click == null)
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

        private void com_article_SelectedIndexChanged(object sender, EventArgs e)
        {
            contenu = new Contenu();
            Article a = com_article.SelectedItem as Article;
            a = articles.Find(x => x.Id == a.Id);
            txt_prix_article.Text = a.Prix.ToString();
            txt_qte_article.Text = "0";
            contenu.Article = BLL.ArticleComBll.One(a);

            foreach (Contenu c in facture.Contenus)
            {
                if (c.Article.Id.Equals(contenu.Article.Id))
                {
                    contenu.Id = c.Id;
                    contenu.Update = true;
                    txt_qte_article.Text = c.Quantite.ToString();
                    Messages.Alert("Ce contenu existe deja. Passer en mode modification!");
                    break;
                }
            }
        }

        private void com_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client a = com_client.SelectedItem as Client;
            a = clients.Find(x => x.Id == a.Id);
            facture.Client = a;
            facture.Categorie = a.Categorie;
            configClient(a);
        }

        private void com_typeDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            String type = com_typeDoc.Text;
            String reference = "FV/271015/0000";
            if (!facture.Update)
            {
                switch (type)
                {
                    case Constantes.TYPE_BCV_NAME:
                        reference = Utils.GenererReference(Constantes.DOC_COMMANDE);
                        facture.TypeDoc = Constantes.TYPE_BCV;
                        lb_totalVerse.Text = "Somme Avancée : ";
                        facture.MouvStock = false;
                        break;
                    case Constantes.TYPE_FV_NAME:
                        reference = Utils.GenererReference(Constantes.DOC_FACTURE);
                        facture.TypeDoc = Constantes.TYPE_FV;
                        lb_totalVerse.Text = "Somme Versée : ";
                        facture.MouvStock = true;
                        break;
                }
                facture.NumDoc = reference;
            }
            else
            {
                reference = facture.NumDoc;
            }
            lb_numPiece.Text = reference;
        }

        private void com_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModePaiement a = com_mode.SelectedItem as ModePaiement;
            a = modes.Find(x => x.Id == a.Id);
            reglement.Mode = a;
        }

        private void btn_theme_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new Form_Caisse_Click().Show();
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

        private void btn_add_contenu_Click(object sender, EventArgs e)
        {
            Contenu c = RecopieViewContenu();
            if (c.Control())
            {
                if (!c.Update)
                {
                    c.DateContenu = DateTime.Now;
                    Contenu c_ = new BLL.ContenuBll(c).Insert();
                    if ((c_ != null) ? c_.Id > 0 : false)
                    {
                        c.Id = c_.Id;
                        contenu.DateContenu = DateTime.Now;
                        contenu.Id = c_.Id;
                        c.Update = true;
                        facture.Contenus.Add(c);
                        AddRowContenu(c);

                        contenu.Update = true;
                        Messages.Succes();
                    }
                }
                else
                {
                    if (new BLL.ContenuBll(c).Update())
                    {
                        c.Update = true;
                        facture.Contenus[facture.Contenus.FindIndex(x => x.Id == c.Id)] = c;
                        UpdateRowContenu(c);

                        contenu.Update = true;
                        Messages.Succes();
                    }
                }
                Utils.MontantTotalDoc(facture);
                configFacture(facture);
                UpdateCurrentFacture(facture);
                ResetFicheContenu();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ResetFicheFacture();
            com_client.SelectedText = facture.Client.Nom_prenom;
        }

        private void btn_save_Click(object sender, EventArgs e)
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
                        facture.Id = f_.Id;
                        AddCurrentFacture(f);
                        facture.Update = true;
                        Messages.Succes();
                    }
                }
                else
                {
                    if (new BLL.FactureBll(f).Update())
                    {
                        f.Update = true;
                        UpdateCurrentFacture(f);
                        facture.Update = true;
                        Messages.Succes();
                    }
                }
            }
        }

        private void btn_reglement_Click(object sender, EventArgs e)
        {
            if ((facture != null) ? facture.Id > 0 : false)
            {
                if (facture.MontantReste > 0)
                {
                    double montant = Convert.ToDouble(txt_montantVerse.Text);
                    if (montant > 0)
                    {
                        if (facture.Mensualites.Count > 0)
                        {
                            foreach (Mensualite m in facture.Mensualites)
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
                                            facture.Mensualites.Add(m);
                                            facture.MontantAvance += p.Montant;

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
                                    facture.Mensualites.Add(m);
                                    facture.MontantAvance += p.Montant;

                                    AddRowReglement(p);
                                }
                            }
                        }

                        String etat = Constantes.ETAT_EN_COURS;
                        if (Convert.ToDouble(txt_montantVerse.Text) >= facture.MontantTTC)
                        {
                            etat = Constantes.ETAT_REGLE;
                        }
                        if (BLL.FactureBll.ChangeEtat(facture.Id, etat))
                        {
                            facture.MontantReste = (facture.MontantTTC - Convert.ToDouble(txt_montantVerse.Text) < 0) ? facture.MontantTTC - Convert.ToDouble(txt_montantVerse.Text) : 0;
                            DeleteCurrentFacture(facture);
                            facture.Statut = etat;
                            AddCurrentFacture(facture);
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

        private void btn_ticket_Click(object sender, EventArgs e)
        {
            if ((facture != null) ? facture.Id > 0 : false)
            {
                new Form_Ticket(facture).Show();
            }
            else
            {
                Messages.ShowErreur("Vous devez selectionner une facture");
            }
        }

        private void btn_regl_tick_Click(object sender, EventArgs e)
        {
            btn_reglement_Click(sender, e);
            if ((facture != null) ? facture.Id > 0 : false)
            {
                new Form_Ticket(facture).Show();
            }
        }

        private void dgv_contenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_contenu.CurrentRow.Cells["idContenu"].Value != null)
                {
                    long id = Convert.ToInt64(dgv_contenu.CurrentRow.Cells["idContenu"].Value.ToString());
                    if (id > 0)
                    {
                        Contenu c = facture.Contenus.Find(x => x.Id == id);
                        if (e.ColumnIndex == 5)
                        {
                            if (!facture.Statut.Equals(Constantes.ETAT_REGLE))
                            {
                                if (DialogResult.Yes == Messages.Confirmation("supprimer"))
                                {
                                    if (BLL.ContenuBll.Delete(c.Id))
                                    {
                                        dgv_contenu.Rows.RemoveAt(Utils.GetRowData(dgv_contenu, c.Id));
                                        facture.Contenus.Remove(c);
                                        Utils.MontantTotalDoc(facture);
                                        configFacture(facture);
                                        UpdateCurrentFacture(facture);

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

        private void dgv_facture_cours_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_facture_cours.CurrentRow.Cells["idFactureCours"].Value != null)
                {
                    long id = Convert.ToInt64(dgv_facture_cours.CurrentRow.Cells["idFactureCours"].Value.ToString());
                    if (id > 0)
                    {
                        Facture f = Constantes.Entete.FacturesEnCours.Find(x => x.Id == id);
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

        private void dgv_facture_regle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_facture_regle.CurrentRow.Cells["idFactureRegle"].Value != null)
                {
                    long id = Convert.ToInt64(dgv_facture_regle.CurrentRow.Cells["idFactureRegle"].Value.ToString());
                    if (id > 0)
                    {
                        Facture f = Constantes.Entete.FacturesRegle.Find(x => x.Id == id);
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

        private void dgv_facture_wait_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_facture_wait.CurrentRow.Cells["idFactureWait"].Value != null)
                {
                    long id = Convert.ToInt64(dgv_facture_wait.CurrentRow.Cells["idFactureWait"].Value.ToString());
                    if (id > 0)
                    {
                        Facture f = Constantes.Entete.FacturesEnAttente.Find(x => x.Id == id);
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

        private void dgv_reglement_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgv_facture_cours_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int i = e.RowIndex;
            bool supp = (Boolean)((dgv_facture_cours.Rows[i].Cells[7].Value != null) ? dgv_facture_cours.Rows[i].Cells[7].Value : false);
            if (supp)
            {
                this.dgv_facture_cours.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;
            }
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

        private void dgv_commande_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int i = e.RowIndex;
            bool supp = (Boolean)((dgv_commande.Rows[i].Cells[7].Value != null) ? dgv_commande.Rows[i].Cells[7].Value : false);
            if (supp)
            {
                this.dgv_commande.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;
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

        private void txt_montantTTC_TextChanged(object sender, EventArgs e)
        {
            txt_montantTTC.Text = string.Format("{0:#,##0.00}", double.Parse(txt_montantTTC.Text));
        }

        private void txt_montantVerse_ValueChanged(object sender, EventArgs e)
        {
            txt_montantVerse.Text = string.Format("{0:#,##0.00}", double.Parse(txt_montantVerse.Text));
        }

        private void txt_montantVerse_Leave(object sender, EventArgs e)
        {
            txt_montantReste.Text = (facture.MontantReste - Convert.ToDouble(txt_montantVerse.Text)).ToString();
        }

        private void txt_montantReste_TextChanged(object sender, EventArgs e)
        {
            txt_montantReste.Text = string.Format("{0:#,##0.00}", double.Parse(txt_montantReste.Text));
        }

        private void txt_montantRemise_TextChanged(object sender, EventArgs e)
        {
            txt_montantRemise.Text = string.Format("{0:#,##0.00}", double.Parse(txt_montantRemise.Text));
        }

        private void txt_montantReste_TextChanged_1(object sender, EventArgs e)
        {
            txt_montantReste.Text = string.Format("{0:#,##0.00}", double.Parse(txt_montantReste.Text));
            double reste = Convert.ToDouble(txt_montantReste.Text);
            lb_totalRest.Text = (reste < 0) ? "A Rembourser : " : "Reste : ";
        }

        private void txt_montantHt_TextChanged(object sender, EventArgs e)
        {
            txt_montantHt.Text = string.Format("{0:#,##0.00}", double.Parse(txt_montantHt.Text));
        }

        private void txt_prix_article_TextChanged(object sender, EventArgs e)
        {
            txt_prix_article.Text = string.Format("{0:#,##0.00}", double.Parse(txt_prix_article.Text));
        }

        private void txt_qte_article_TextChanged(object sender, EventArgs e)
        {
            txt_qte_article.Text = string.Format("{0:#,##0}", double.Parse(txt_qte_article.Text));
        }

        private void lb_montant_caisse_TextChanged(object sender, EventArgs e)
        {
            lb_montant_caisse.Text = string.Format("{0:#,##0.00}", double.Parse(lb_montant_caisse.Text));
        }

        private void lb_nom_agence_TextChanged(object sender, EventArgs e)
        {
            lb_nom_agence.Text = lb_nom_agence.Text.ToUpper();
        }

        private void tool_codeClient_Click(object sender, EventArgs e)
        {
            lb_search_client.Text = "Client (Code) :";
        }

        private void tool_nomClient_Click(object sender, EventArgs e)
        {
            lb_search_client.Text = "Client (Nom) :";
        }

        private void tool_btn_wait_Click(object sender, EventArgs e)
        {
            facture.Statut = Constantes.ETAT_EN_ATTENTE;
        }

        private void tool_search_code_Click(object sender, EventArgs e)
        {
            lb_search_article.Text = "Article (Reference) :";
            FullArticlesByRef();
        }

        private void tool_search_name_Click(object sender, EventArgs e)
        {
            lb_search_article.Text = "Article (Désignation) :";
            FullArticlesByName();
        }

        private void tool_search_bar_Click(object sender, EventArgs e)
        {
            lb_search_article.Text = "Article (Code Barre) :";
        }

        private void tool_integre_data_Click(object sender, EventArgs e)
        {
            if (rowFacture > -1)
            {
                if (BLL.FactureBll.ChangeSupp(rowFacture, suppFacture))
                {
                    SetCurrentFacture(rowFacture, suppFacture, suppData);
                    Messages.Succes();
                }
            }
        }

        private void tool_mensualite_Click(object sender, EventArgs e)
        {
            if ((facture != null) ? facture.Id > 0 : false)
            {
                new Form_Caisse_Mensualite(this).ShowDialog();
            }
            else
            {
                Messages.ShowErreur("Vous devez dabord selectionner une facture!");
            }
        }

    }
}
