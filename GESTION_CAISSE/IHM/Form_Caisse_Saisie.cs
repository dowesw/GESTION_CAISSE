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

        Entete entete = new Entete();
        Facture facture = new Facture();


        ArticleCom article = new ArticleCom();
        Contenu contenu = new Contenu();

        int rowContenu, rowFactureWait, rowFactureCours, rowCommande;
        Form F_parent;

        public Form_Caisse_Saisie()
        {
            InitializeComponent();
            articles = new List<Article>();
            modes = new List<ModePaiement>();
            clients = new List<Client>();

            LoadAll();
            configForm();
        }

        public Form_Caisse_Saisie(Form parent)
        {
            InitializeComponent();
            articles = new List<Article>();
            modes = new List<ModePaiement>();
            clients = new List<Client>();

            LoadAll();
            F_parent = parent;
            configForm();
        }

        private void configForm()
        {
            lb_numPiece.Text = Utils.GenererReference(Constantes.DOC_FACTURE);
            lb_nom_agence.Text = Constantes.Agence.Designation;
            lb_nom_user.Text = Constantes.Users.NomUser;
            lb_nom_depot.Text = Constantes.Creneau.Depot.Designation;
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
            lb_nom_client.Text = a.Tiers.Nom;
            lb_prenom_client.Text = a.Tiers.Prenom;
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
            }
            else
            {
                lb_numPiece.Text = Utils.GenererReference(Constantes.DOC_FACTURE);
                txt_reference.ResetText();
                txt_montantTTC.Text = "0";
                txt_montantReste.Text = "0";
                txt_montantVerse.Text = "0";
                txt_montantRemise.Text = "0";
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
            DateTime date = Convert.ToDateTime("2015-10-10");
            Entete e = BLL.EnteteBll.One(Constantes.Creneau, date);
            if ((e != null) ? e.Id > 0 : false)
            {
                entete = e;
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

        public void SetClientDefaut()
        {
            Client v = BLL.ClientBll.Default();
            com_client.SelectedIndex = clients.FindIndex(a => a.Id == v.Id);
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
            string query = "select * FROM yvs_articles where societe = " + Constantes.Societe.Id;
            articles = BLL.ArticleBll.Liste(query);
            com_article.Items.Clear();
            com_article.DisplayMember = "Designation";
            com_article.ValueMember = "Id";
            com_article.DataSource = new BindingSource(articles, null);

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
                data.Rows.Add(new object[] { f.Id, f.NumDoc, f.HeureDoc.ToString("T"), f.Client.Nom_prenom, f.MontantTTC, f.MontantReste });
            }
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
                foreach (Mensualite c in f.Mensualites)
                {
                    if (c != null)
                    {
                        foreach (PieceCaisse p in c.Reglements)
                        {
                            AddRowReglement(p);
                        }
                    }
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
            rowFactureWait = 0;
            rowFactureCours = 0;
            rowCommande = 0;
            facture = new Facture();
            facture.TypeDoc = Constantes.TYPE_FV;
            facture.Statut = Constantes.ETAT_EN_ATTENTE;
            facture.HeureDoc = DateTime.Now;
            com_client.ResetText();
            dgv_contenu.Rows.Clear();
            dgv_reglement.Rows.Clear();
            configClient(BLL.ClientBll.Default());
            SetStateFacture(true);
            configFacture(null);
            ResetFicheContenu();
        }

        private void ResetFicheContenu()
        {
            rowContenu = 0;
            txt_prix_article.Text = "0";
            txt_qte_article.Text = "0";
            com_article.ResetText();
            article = new ArticleCom();
            contenu = new Contenu();
        }

        private Facture RecopieViewFacture()
        {
            Facture f = new Facture();
            f.Id = facture.Id;
            f.Categorie = facture.Categorie;
            f.Client = facture.Client;
            f.Entete = entete;
            f.HeureDoc = DateTime.Now;
            f.MontantAvance = Convert.ToDouble(txt_montantVerse.Text.Trim());
            f.MontantTTC = Convert.ToDouble(txt_montantTTC.Text.Trim());
            f.MontantReste = Convert.ToDouble(txt_montantReste.Text.Trim());
            f.Update = facture.Update;
            f.Statut = facture.Statut;
            f.TypeDoc = facture.TypeDoc;
            f.Solde = facture.Solde;
            f.NumDoc = lb_numPiece.Text;
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
            return f;
        }

        private Contenu RecopieViewContenu()
        {
            Contenu c = new Contenu();
            c.Id = contenu.Id;
            c.Article = article;
            c.Commission = 0;
            c.Facture = facture;
            c.Prix = Convert.ToDouble((!txt_prix_article.Text.Trim().Equals("")) ? txt_prix_article.Text.Trim() : "0");
            c.Quantite = Convert.ToDouble((!txt_qte_article.Text.Trim().Equals("")) ? txt_qte_article.Text.Trim() : "0");
            c.PrixTotal = c.Prix * c.Quantite;
            c.RemiseArt = 0;
            c.RemiseCat = 0;
            c.Remise = c.RemiseArt + c.RemiseCat;
            c.Ristourne = 0;
            c.Select = false;
            c.Update = contenu.Update;
            c.New_ = true;
            return c;
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
            SetStateFacture(false);
        }

        private void PopulateViewContenu(Contenu c)
        {
            ResetFicheContenu();
            contenu = c;
            article = c.Article;
            com_article.SelectedText = articles.Find(a => a.Id == article.Article.Id).Designation;
            txt_prix_article.Text = c.Prix.ToString();
            txt_qte_article.Text = c.Quantite.ToString();
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
            if (Constantes.form_caisse_click == null && DialogResult.OK == Messages.FermerApplication())
                Application.Exit();

        }

        private void com_article_SelectedIndexChanged(object sender, EventArgs e)
        {
            Article a = com_article.SelectedItem as Article;
            a = articles.Find(x => x.Id == a.Id);
            txt_prix_article.Text = a.Prix.ToString();
            article = BLL.ArticleComBll.One(a);
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
                        break;
                    case Constantes.TYPE_FV_NAME:
                        reference = Utils.GenererReference(Constantes.DOC_FACTURE);
                        facture.TypeDoc = Constantes.TYPE_FV;
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

        private void btn_theme_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new Form_Caisse_Click().Show();
        }

        private void btn_deconnect_Click(object sender, EventArgs e)
        {
            Form_Login l = (Form_Login)F_parent;
            l.bubble.Visible = false;
            l.Show();
            this.Dispose();
        }

        private void btn_add_contenu_Click(object sender, EventArgs e)
        {
            Contenu c = RecopieViewContenu();
            if (c.Control())
            {
                if (!c.Update)
                {
                    c.Id = dgv_contenu.Rows.Count + 1;
                    c.Update = true;
                    facture.Contenus.Add(c);
                }
                else
                {
                    c.Update = true;
                    dgv_contenu.Rows.RemoveAt(rowContenu);
                }
                dgv_contenu.Rows.Add(new object[] { c.Id, c.Article.Article.Designation, c.Prix, c.Quantite, c.PrixTotal, null });
                Utils.MontantTotalDoc(facture);
                configFacture(facture);
                ResetFicheContenu();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ResetFicheFacture();
            facture.Client = BLL.ClientBll.Default();
            com_client.SelectedText = clients.Find(a => a.Id == facture.Client.Id).Nom_prenom;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Facture f = RecopieViewFacture();
            String type = f.TypeDoc;
            String etat = f.Statut;
            if (!f.Update)
            {
                switch (type)
                {
                    case Constantes.TYPE_BCV:
                        f.Id = dgv_commande.Rows.Count + 1;
                        entete.Commandes.Add(f);
                        AddRowFacture(dgv_commande, f);
                        break;
                    case Constantes.TYPE_FV:
                        switch (etat)
                        {
                            case Constantes.ETAT_EN_ATTENTE:
                                f.Id = dgv_facture_wait.Rows.Count + 1;
                                entete.FacturesEnAttente.Add(f);
                                AddRowFacture(dgv_facture_wait, f);
                                break;
                            case Constantes.ETAT_EN_COURS:
                                f.Id = dgv_facture_cours.Rows.Count + 1;
                                entete.FacturesEnCours.Add(f);
                                AddRowFacture(dgv_facture_cours, f);
                                break;
                            case Constantes.ETAT_REGLE:
                                f.Id = dgv_facture_regle.Rows.Count + 1;
                                entete.FacturesRegle.Add(f);
                                AddRowFacture(dgv_facture_regle, f);
                                break;
                        }
                        break;
                }
            }
            else
            {

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
                        PopulateViewContenu(c);
                        rowContenu = e.RowIndex;
                        if (e.ColumnIndex == 5)
                        {
                            if (DialogResult.Yes == Messages.Confirmation("supprimer"))
                            {
                                dgv_contenu.Rows.RemoveAt(rowContenu);
                                facture.Contenus.Remove(c);
                                Utils.MontantTotalDoc(facture);
                                configFacture(facture);
                                ResetFicheContenu();
                            }
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
                        Facture f = entete.Commandes.Find(x => x.Id == id);
                        com_typeDoc.Text = "Commande";
                        PopulateViewFacture(f);
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
                        Facture f = entete.FacturesEnCours.Find(x => x.Id == id);
                        com_typeDoc.Text = "Facture";
                        PopulateViewFacture(f);
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
                        Facture f = entete.FacturesRegle.Find(x => x.Id == id);
                        com_typeDoc.Text = "Facture";
                        PopulateViewFacture(f);
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
                        Facture f = entete.FacturesEnAttente.Find(x => x.Id == id);
                        com_typeDoc.Text = "Facture";
                        PopulateViewFacture(f);
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

        private void txt_montantTTC_TextChanged(object sender, EventArgs e)
        {
            txt_montantTTC.Text = string.Format("{0:#,##0.00}", double.Parse(txt_montantTTC.Text));
        }

        private void txt_montantVerse_TextChanged(object sender, EventArgs e)
        {
            txt_montantVerse.Text = string.Format("{0:#,##0.00}", double.Parse(txt_montantVerse.Text));
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
    }
}
