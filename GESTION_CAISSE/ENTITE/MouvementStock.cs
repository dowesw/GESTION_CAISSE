using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class MouvementStock
    {
        public MouvementStock()
        {

        }

        public MouvementStock(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime dateDoc = DateTime.Now;
        public DateTime DateDoc
        {
            get { return dateDoc; }
            set { dateDoc = value; }
        }

        private double quantite;
        public double Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        private String mouvement;
        public String Mouvement
        {
            get { return mouvement; }
            set { mouvement = value; }
        }

        private Article article = new Article();
        public Article Article
        {
            get { return article; }
            set { article = value; }
        }

        private Depot depot = new Depot();
        internal Depot Depot
        {
            get { return depot; }
            set { depot = value; }
        }

        private System.Drawing.Bitmap image;
        public System.Drawing.Bitmap Image
        {
            get {
                if (mouvement == TOOLS.Constantes.MOUV_ENTREE)
                {
                    image = global::GESTION_CAISSE.Properties.Resources._in;
                }
                else
                {
                    image = global::GESTION_CAISSE.Properties.Resources._out;
                }
                return image; 
            }
            set { }
        }

    }
}
