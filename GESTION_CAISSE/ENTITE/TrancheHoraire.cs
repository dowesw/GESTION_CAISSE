using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class TrancheHoraire
    {
        public TrancheHoraire()
        {

        }

        public TrancheHoraire(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String reference;
        public String Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        private String critere;
        public String Critere
        {
            get { return critere; }
            set { critere = value; }
        }

        private DateTime heureDebut = DateTime.Now;
        public DateTime HeureDebut
        {
            get { return heureDebut; }
            set { heureDebut = value; }
        }

        private DateTime heureFin = DateTime.Now;
        public DateTime HeureFin
        {
            get { return heureFin; }
            set { heureFin = value; }
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
