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
