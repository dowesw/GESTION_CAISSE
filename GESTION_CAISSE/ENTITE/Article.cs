using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTION_CAISSE.ENTITE
{
    class Article
    {
        public Article()
        {

        }

        public Article(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
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

        private String description;
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private double prix;
        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        private List<String> photos;
        public List<String> Photos
        {
            get { return photos; }
            set { photos = value; }
        }

        private String categorie;
        public String Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        private FamilleArticle famille = new FamilleArticle();
        internal FamilleArticle Famille
        {
            get { return famille; }
            set { famille = value; }
        }

        private GroupeArticle groupe = new GroupeArticle();
        internal GroupeArticle Groupe
        {
            get { return groupe; }
            set { groupe = value; }
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
