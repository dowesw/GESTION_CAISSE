using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class ArticleTaxe
    {
        public ArticleTaxe()
        {

        }

        public ArticleTaxe(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private ArticleComptable article = new ArticleComptable();
        internal ArticleComptable Article
        {
            get { return article; }
            set { article = value; }
        }

        private String codeBarre;
        public String CodeBarre
        {
            get { return codeBarre; }
            set { codeBarre = value; }
        }

        private String refArt;
        public String RefArt
        {
            get { return refArt; }
            set { refArt = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private Taxe taxe = new Taxe();
        internal Taxe Taxe
        {
            get { return taxe; }
            set { taxe = value; }
        }

        private bool appRemise;
        public bool AppRemise
        {
            get { return appRemise; }
            set { appRemise = value; }
        }

        private bool actif;
        public bool Actif
        {
            get { return actif; }
            set { actif = value; }
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
