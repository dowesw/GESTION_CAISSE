using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class ModelReference
    {

        public ModelReference()
        {

        }

        public ModelReference(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String prefix;
        public String Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        private bool jour;
        public bool Jour
        {
            get { return jour; }
            set { jour = value; }
        }

        private bool mois;
        public bool Mois
        {
            get { return mois; }
            set { mois = value; }
        }

        private bool annee;
        public bool Annee
        {
            get { return annee; }
            set { annee = value; }
        }

        private int taille;
        public int Taille
        {
            get { return taille; }
            set { taille = value; }
        }

        private String separateur;
        public String Separateur
        {
            get { return separateur; }
            set { separateur = value; }
        }

        private String module = "COM";
        public String Module
        {
            get { return module; }
            set { module = value; }
        }

        private ElementReference element = new ElementReference();
        internal ElementReference Element
        {
            get { return element; }
            set { element = value; }
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
