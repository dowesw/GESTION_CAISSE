using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Agence
    {
        public Agence()
        {

        }

        public Agence(long id)
        {
            this.id = id;
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

        private String adresse;
        public String Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        private String codeAgence;
        public String CodeAgence
        {
            get { return codeAgence; }
            set { codeAgence = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private Dictionnaire ville = new Dictionnaire();
        public Dictionnaire Ville
        {
            get { return ville; }
            set { ville = value; }
        }

        private String pays;
        public String Pays
        {
            get { return pays; }
            set { pays = value; }
        }

        private Societe societe = new Societe();
        internal Societe Societe
        {
            get { return societe; }
            set { societe = value; }
        }
    }
}
