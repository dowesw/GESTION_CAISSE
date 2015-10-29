using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class PlanTarifaire
    {
        public PlanTarifaire()
        {

        }

        public PlanTarifaire(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String code;
        public String Code
        {
            get { return code; }
            set { code = value; }
        }

        private Remise remise_ = new Remise();
        internal Remise Remise_
        {
            get { return remise_; }
            set { remise_ = value; }
        }

        private double puv;
        public double Puv
        {
            get { return puv; }
            set { puv = value; }
        }

        private double remise;
        public double Remise
        {
            get { return remise; }
            set { remise = value; }
        }

        private double ristourne;
        public double Ristourne
        {
            get { return ristourne; }
            set { ristourne = value; }
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
