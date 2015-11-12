using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.TOOLS;
using System.IO;

namespace GESTION_CAISSE.ENTITE
{
    public class Client
    {
        public Client()
        {

        }

        public Client(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private bool defaut;
        public bool Defaut
        {
            get { return defaut; }
            set { defaut = value; }
        }

        private Tiers tiers = new Tiers();
        internal Tiers Tiers
        {
            get { return tiers; }
            set { tiers = value; }
        }

        private String nom_prenom;
        public String Nom_prenom
        {
            get { return nom_prenom; }
            set { nom_prenom = value; }
        }

        private CategorieComptable categorie = new CategorieComptable();
        internal CategorieComptable Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        private CategorieClient categorieClt = new CategorieClient();
        internal CategorieClient CategorieClt
        {
            get { return categorieClt; }
            set { categorieClt = value; }
        }

        private string photo;
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public System.Drawing.Image Image
        {
            get
            {
                if ((photo != null) ? !photo.Trim().Equals("") : false)
                {
                    string chemin = Chemins.getCheminPhoto() + photo;
                    if (File.Exists(chemin))
                    {
                        return new System.Drawing.Bitmap(chemin);
                    }
                }
                return global::GESTION_CAISSE.Properties.Resources.user_m; ;
            }
            set { }
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
