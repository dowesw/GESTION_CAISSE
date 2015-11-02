using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Depot
    {
        public Depot()
        {
            emplacements = new List<Emplacement>();
            articles = new List<ArticleDepot>();
        }

        public Depot(long id)
        {
            this.id = id;
            emplacements = new List<Emplacement>();
            articles = new List<ArticleDepot>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String abbreviation;
        public String Abbreviation
        {
            get { return abbreviation; }
            set { abbreviation = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private List<Emplacement> emplacements;
        internal List<Emplacement> Emplacements
        {
            get { return emplacements; }
            set { emplacements = value; }
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
