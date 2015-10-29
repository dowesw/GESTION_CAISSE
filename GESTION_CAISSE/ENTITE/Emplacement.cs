using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Emplacement
    {
        public Emplacement()
        {
            articles = new List<ArticleDepot>();
        }

        public Emplacement(long id)
        {
            this.id = id;
            articles = new List<ArticleDepot>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String code;
        public String Code
        {
            get { return code; }
            set { code = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private bool defaut;
        public bool Defaut
        {
            get { return defaut; }
            set { defaut = value; }
        }

        private List<ArticleDepot> articles;
        internal List<ArticleDepot> Articles
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
