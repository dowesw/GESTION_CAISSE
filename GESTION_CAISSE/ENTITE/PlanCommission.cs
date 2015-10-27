using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class PlanCommission
    {
        public PlanCommission()
        {
            commissions = new List<Commission>();
        }

        public PlanCommission(long id)
        {
            this.id = id;
            commissions = new List<Commission>();
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

        private String nature;
        public String Nature
        {
            get { return nature; }
            set { nature = value; }
        }

        private List<Commission> commissions;
        internal List<Commission> Commissions
        {
            get { return commissions; }
            set { commissions = value; }
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
