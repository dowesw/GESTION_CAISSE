using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class PlanRemise
    {
        public PlanRemise()
        {

        }

        public PlanRemise(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
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

        private ArticleCom article = new ArticleCom();
        internal ArticleCom Article
        {
            get { return article; }
            set { article = value; }
        }

        private CategorieClient categorie = new CategorieClient();
        internal CategorieClient Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        private Remise remise = new Remise();
        internal Remise Remise
        {
            get { return remise; }
            set { remise = value; }
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
