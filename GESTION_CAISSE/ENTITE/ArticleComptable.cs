using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class ArticleComptable
    {
        public ArticleComptable()
        {
            articles = new List<ArticleTaxe>();
        }

        public ArticleComptable(long id)
        {
            this.id = id;
            articles = new List<ArticleTaxe>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private Article article = new Article();
        internal Article Article
        {
            get { return article; }
            set { article = value; }
        }

        private CategorieComptable categorie = new CategorieComptable();
        internal CategorieComptable Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        private Compte compte = new Compte();
        internal Compte Compte
        {
            get { return compte; }
            set { compte = value; }
        }

        private List<ArticleTaxe> articles;
        internal List<ArticleTaxe> Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        private double montantTaux;
        public double MontantTaux
        {
            get { return montantTaux; }
            set { montantTaux = value; }
        }

        private double montantTotal;
        public double MontantTotal
        {
            get { return montantTotal; }
            set { montantTotal = value; }
        }

        private bool actif;
        public bool Actif
        {
            get { return actif; }
            set { actif = value; }
        }

        private bool update;
        public bool Update
        {
            get { return update; }
            set { update = value; }
        }

        private bool select;
        public bool Select
        {
            get { return select; }
            set { select = value; }
        }

        private bool new_;
        public bool New_
        {
            get { return new_; }
            set { new_ = value; }
        }
    }
}
