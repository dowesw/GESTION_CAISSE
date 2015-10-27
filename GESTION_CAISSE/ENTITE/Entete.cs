using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class Entete
    {
        public Entete()
        {
            commandes = new List<Facture>();
            facturesRegle = new List<Facture>();
            facturesEnCours = new List<Facture>();
            facturesEnAttente = new List<Facture>();
        }

        public Entete(long id)
        {
            this.id = id;
            commandes = new List<Facture>();
            facturesRegle = new List<Facture>();
            facturesEnCours = new List<Facture>();
            facturesEnAttente = new List<Facture>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime dateEntete = System.DateTime.Now;
        public DateTime DateEntete
        {
            get { return dateEntete; }
            set { dateEntete = value; }
        }

        private Creneau creneau = new Creneau();
        internal Creneau Creneau
        {
            get { return creneau; }
            set { creneau = value; }
        }

        private String etat;
        public String Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        private List<Facture> facturesRegle;
        internal List<Facture> FacturesRegle
        {
            get { return facturesRegle; }
            set { facturesRegle = value; }
        }

        private List<Facture> facturesEnCours;
        internal List<Facture> FacturesEnCours
        {
            get { return facturesEnCours; }
            set { facturesEnCours = value; }
        }

        private List<Facture> facturesEnAttente;
        internal List<Facture> FacturesEnAttente
        {
            get { return facturesEnAttente; }
            set { facturesEnAttente = value; }
        }

        private List<Facture> commandes;
        internal List<Facture> Commandes
        {
            get { return commandes; }
            set { commandes = value; }
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
