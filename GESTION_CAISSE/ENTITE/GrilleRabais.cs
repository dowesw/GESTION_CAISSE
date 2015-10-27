using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class GrilleRabais
    {
        public GrilleRabais()
        {

        }

        public GrilleRabais(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private double minimal;
        public double Minimal
        {
            get { return minimal; }
            set { minimal = value; }
        }

        private double maximal;
        public double Maximal
        {
            get { return maximal; }
            set { maximal = value; }
        }

        private double montant;
        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        private String nature;
        public String Nature
        {
            get { return nature; }
            set { nature = value; }
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
