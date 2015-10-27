using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class FamilleArticle
    {
        public FamilleArticle()
        {
            articles = new List<Article>();
        }

        public FamilleArticle(long id)
        {
            this.id = id;
            articles = new List<Article>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String reference;
        public String Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private String description;
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private FamilleArticle parent;
        internal FamilleArticle Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private List<Article> articles;
        internal List<Article> Articles
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
