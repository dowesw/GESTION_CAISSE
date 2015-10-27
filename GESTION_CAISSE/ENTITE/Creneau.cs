using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Creneau
    {
        public Creneau()
        {

        }

        public Creneau(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private Depot depot = new Depot();
        internal Depot Depot
        {
            get { return depot; }
            set { depot = value; }
        }

        private TrancheHoraire tranche = new TrancheHoraire();
        internal TrancheHoraire Tranche
        {
            get { return tranche; }
            set { tranche = value; }
        }

        private Personnel personnel = new Personnel();
        internal Personnel Personnel
        {
            get { return personnel; }
            set { personnel = value; }
        }

        private DateTime dateTravail;
        public DateTime DateTravail
        {
            get { return dateTravail; }
            set { dateTravail = value; }
        }

        private bool actif;
        public bool Actif
        {
            get { return actif; }
            set { actif = value; }
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
