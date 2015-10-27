using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class ModePaiement
    {
        public ModePaiement()
        {

        }

        public ModePaiement(long id)
        {

        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String typePaiement;
        public String TypePaiement
        {
            get { return typePaiement; }
            set { typePaiement = value; }
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
