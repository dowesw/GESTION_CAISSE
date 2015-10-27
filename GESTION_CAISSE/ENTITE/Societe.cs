using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Societe
    {

        public Societe()
        {

        }

        public Societe(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String adresseSiege;
        public String AdresseSiege
        {
            get { return adresseSiege; }
            set { adresseSiege = value; }
        }

        private String codeAbbreviation;
        public String CodeAbbreviation
        {
            get { return codeAbbreviation; }
            set { codeAbbreviation = value; }
        }

        private String logo;
        public String Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }
    }
}
