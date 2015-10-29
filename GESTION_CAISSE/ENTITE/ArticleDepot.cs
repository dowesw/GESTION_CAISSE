using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class ArticleDepot
    {
        public ArticleDepot()
        {
        }

        public ArticleDepot(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private Article article = new Article();
        internal Article Article
        {
            get { return article; }
            set { article = value; }
        }

        private String codeBarre;
        public String CodeBarre
        {
            get { return codeBarre; }
            set { codeBarre = value; }
        }

        private String refArt;
        public String RefArt
        {
            get { return refArt; }
            set { refArt = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private double stockMax;
        public double StockMax
        {
            get { return stockMax; }
            set { stockMax = value; }
        }

        private double stockMin;
        public double StockMin
        {
            get { return stockMin; }
            set { stockMin = value; }
        }

        private double stock;
        public double Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private double stockAlert;
        public double StockAlert
        {
            get { return stockAlert; }
            set { stockAlert = value; }
        }

        private String modeAppro;
        public String ModeAppro
        {
            get { return modeAppro; }
            set { modeAppro = value; }
        }

        private String modeReappro;
        public String ModeReappro
        {
            get { return modeReappro; }
            set { modeReappro = value; }
        }

        private Emplacement emplcement = new Emplacement();
        internal Emplacement Emplcement
        {
            get { return emplcement; }
            set { emplcement = value; }
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
