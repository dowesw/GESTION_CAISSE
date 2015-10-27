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
        Client client_ = new Client();


        ArticleCom article = new ArticleCom();
        Contenu contenu = new Contenu();

        int rowContenu;
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
            lb_nom_agence.Text = Constantes.Agence.Designation;
            lb_nom_user.Text = Constantes.Users.NomUser;

            Timer timer1 = new Timer();
            timer1.Tick += (s, e) => { lb_date.Text = DateTime.Now.ToString(); };
            timer1.Interval = 100;
            timer1.Start();
        }

        private void LoadAll()
        {
            LoadAllArticle();
            LoadAllModes();
            LoadAllClients();

            SetClientDefaut();
        }

        public void SetClientDefaut()
        {
            List<Client> l = new List<Client>();
            string query = "select * FROM yvs_com_client c inner join yvs_tiers t on c.tiers = t.id where c.defaut = true and t.agence = " + Constantes.Agence.Id;
            l = BLL.ClientBll.Liste(query);
            if ((l != null) ? l.Count > 0 : false)
            {
                Client v = l[0];
                com_client.SelectedIndex = clients.FindIndex(a => a.Id == v.Id);
            }
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

        private void ResetFicheContenu()
        {
            rowContenu = 0;
            txt_prix_article.Text = "0";
            txt_qte_article.Text = "0";
            com_article.ResetText();
            article = new ArticleCom();
            contenu = new Contenu();
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

        private void PopulateViewContenu(Contenu c)
        {
            ResetFicheContenu();
            contenu = c;
            article = c.Article;
            com_article.SelectedText = articles.Find(a => a.Id == article.Article.Id).Designation;
            txt_prix_article.Text = c.Prix.ToString();
            txt_qte_article.Text = c.Quantite.ToString();
            var t = 0;
        }

        private void setMontantTTC(Facture bean)
        {
            double mtant = 0;
            if (bean != null)
            {
                foreach (Contenu c in bean.Contenus)
                {
                    mtant += c.PrixTotal;
                }
            }
            txt_montantTTC.Text = mtant.ToString();
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

        private void tool_search_code_Click(object sender, EventArgs e)
        {
            lb_article.Text = "Article (Reference) :";
            FullArticlesByRef();
        }

        private void tool_search_name_Click(object sender, EventArgs e)
        {
            lb_article.Text = "Article (Désignation) :";
            FullArticlesByName();
        }

        private void tool_search_bar_Click(object sender, EventArgs e)
        {
            lb_article.Text = "Article (Code Barre) :";
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
            lb_adr_client.Text = a.Tiers.Adresse;
            lb_nom_client.Text = a.Tiers.Nom;
            lb_prenom_client.Text = a.Tiers.Prenom;
            lb_tel_client.Text = a.Tiers.Tel;
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
                setMontantTTC(facture);
                ResetFicheContenu();
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
                                setMontantTTC(facture);
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
    }
}
