using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.TOOLS;

namespace GESTION_CAISSE.ENTITE
{
    class ArticleCom
    {
        public ArticleCom()
        {

        }

        public ArticleCom(long id)
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

        public bool Control(ArticleCom bean)
        {
            if (bean == null)
            {
                Messages.ShowErreur("L'article ne peut pas être null");
                return false;
            }
            if ((bean.article == null) ? bean.article.Id < 1 : true)
            {
                Messages.ShowErreur("L'article ne peut pas être null");
                return false;
            }
            return true;
        }
    }
}
