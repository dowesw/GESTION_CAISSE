using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.TOOLS;

namespace GESTION_CAISSE.ENTITE
{
    public class Contenu
    {
        public Contenu()
        {

        }

        public Contenu(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private double quantite;
        public double Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        private double prix;
        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        private double prixTotal;
        public double PrixTotal
        {
            get { return prixTotal; }
            set { prixTotal = value; }
        }

        private double prixTaxe;
        public double PrixTaxe
        {
            get { return prixTaxe; }
            set { prixTaxe = value; }
        }

        private double remiseCat;
        public double RemiseCat
        {
            get { return remiseCat; }
            set { remiseCat = value; }
        }

        private double remiseArt;
        public double RemiseArt
        {
            get { return remiseArt; }
            set { remiseArt = value; }
        }

        private double remise;
        public double Remise
        {
            get { return remise; }
            set { remise = value; }
        }

        private double commission;
        public double Commission
        {
            get { return commission; }
            set { commission = value; }
        }

        private double ristourne;
        public double Ristourne
        {
            get { return ristourne; }
            set { ristourne = value; }
        }

        private ArticleCom article = new ArticleCom();
        internal ArticleCom Article
        {
            get { return article; }
            set { article = value; }
        }

        private Facture facture = new Facture();
        internal Facture Facture
        {
            get { return facture; }
            set { facture = value; }
        }

        private DateTime dateContenu;
        public DateTime DateContenu
        {
            get { return dateContenu; }
            set { dateContenu = value; }
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

        public bool Control()
        {
            return Control(this);
        }

        public bool Control(Contenu bean)
        {
            if (bean == null)
            {
                Messages.ShowErreur("Le contenu ne peut pas être null");
                return false;
            }
            if ((bean.article != null) ? bean.article.Id < 1 : true)
            {
                Messages.ShowErreur("L'article ne peut pas être null");
                return false;
            }
            if (bean.Prix < 1)
            {
                Messages.ShowErreur("Le prix ne peut pas être négatif");
                return false;
            }
            if (bean.Quantite < 1)
            {
                Messages.ShowErreur("Vous devez entrer une quantitée");
                return false;
            }
            if ((bean.facture != null) ? bean.facture.Id < 1 : true)
            {
                Messages.ShowErreur("Vous devez dabord enregsitrer la facture!");
                return false;
            }
            return true;
        }
    }
}
