using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Commission
    {

        public Commission()
        {

        }

        public Commission(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private double montantMinimal;
        public double MontantMinimal
        {
            get { return montantMinimal; }
            set { montantMinimal = value; }
        }

        private double montantMaximal;
        public double MontantMaximal
        {
            get { return montantMaximal; }
            set { montantMaximal = value; }
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

        private DateTime dateDebut;
        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }

        private DateTime dateFin;
        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }

        private bool permanent;
        public bool Permanent
        {
            get { return permanent; }
            set { permanent = value; }
        }

        private bool actif;
        public bool Actif
        {
            get { return actif; }
            set { actif = value; }
        }

        private ArticleCom article = new ArticleCom();
        internal ArticleCom Article
        {
            get { return article; }
            set { article = value; }
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
