using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Tiers
    {
        public Tiers()
        {

        }

        public Tiers(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String codeTiers;
        public String CodeTiers
        {
            get { return codeTiers; }
            set { codeTiers = value; }
        }

        private String civilite;
        public String Civilite
        {
            get { return civilite; }
            set { civilite = value; }
        }

        private String nom;
        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private String prenom;
        public String Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        private String nom_prenom;
        public String Nom_prenom
        {
            get { return nom_prenom; }
            set { nom_prenom = value; }
        }

        private String adresse;
        public String Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        private String tel;
        public String Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private String logo;
        public String Logo
        {
            get { return logo; }
            set { logo = value; }
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
