using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Dictionnaire
    {
        public Dictionnaire()
        {

        }

        public Dictionnaire(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String libelle;
        public String Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }
    }
}
