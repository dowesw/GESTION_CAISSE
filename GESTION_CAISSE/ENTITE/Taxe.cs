using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Taxe
    {
        public Taxe()
        {

        }

        public Taxe(long id)
        {
            this.id = id;
        }

        public Taxe(String codeTaxe)
        {
            this.codeTaxe = codeTaxe;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String codeTaxe;
        public String CodeTaxe
        {
            get { return codeTaxe; }
            set { codeTaxe = value; }
        }

        private String codeAppel;
        public String CodeAppel
        {
            get { return codeAppel; }
            set { codeAppel = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private double taux = 19.25;
        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }

        private double totalTaux;
        public double TotalTaux
        {
            get { return totalTaux; }
            set { totalTaux = value; }
        }

        private double totalMontant;
        public double TotalMontant
        {
            get { return totalMontant; }
            set { totalMontant = value; }
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
