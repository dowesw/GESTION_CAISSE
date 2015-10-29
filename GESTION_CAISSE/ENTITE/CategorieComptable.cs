using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class CategorieComptable
    {
        public CategorieComptable()
        {
            articles = new List<ArticleComptable>();
        }

        public CategorieComptable(long id)
        {
            this.id = id;
            articles = new List<ArticleComptable>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private String codeAppel;
        public String CodeAppel
        {
            get { return codeAppel; }
            set { codeAppel = value; }
        }

        private List<ArticleComptable> articles;
        internal List<ArticleComptable> Articles
        {
            get { return articles; }
            set { articles = value; }
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
