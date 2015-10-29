using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Mensualite
    {
        public Mensualite()
        {
            reglements = new List<PieceCaisse>();
        }

        public Mensualite(long id)
        {
            this.id = id;
            reglements = new List<PieceCaisse>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime dateMensualite;
        public DateTime DateMensualite
        {
            get { return dateMensualite; }
            set { dateMensualite = value; }
        }

        private String etat;
        public String Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        private double montant;
        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        private List<PieceCaisse> reglements;
        internal List<PieceCaisse> Reglements
        {
            get { return reglements; }
            set { reglements = value; }
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
