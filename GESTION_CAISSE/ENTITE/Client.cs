using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Client
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
