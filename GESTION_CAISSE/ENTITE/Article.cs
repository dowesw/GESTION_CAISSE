using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTION_CAISSE.TOOLS;
using System.IO;

namespace GESTION_CAISSE.ENTITE
{
    public class Article
    {
        public Article()
        {
            plans = new List<PlanTarifaire>();
        }

        public Article(long id)
        {
            this.id = id;
            plans = new List<PlanTarifaire>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
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

        private String description;
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private double prix;
        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        private string methodeVal;
        public string MethodeVal
        {
            get { return methodeVal; }
            set { methodeVal = value; }
        }

        private string photo1;
        public string Photo1
        {
            get { return photo1; }
            set { photo1 = value; }
        }

        private string photo2;
        public string Photo2
        {
            get { return photo2; }
            set { photo2 = value; }
        }

        private string photo3;
        public string Photo3
        {
            get { return photo3; }
            set { photo3 = value; }
        }

        public System.Drawing.Image Image
        {
            get
            {
                if ((photo1 != null) ? !photo1.Trim().Equals("") : false)
                {
                    string chemin = Chemins.getCheminArticle() + photo1;
                    if (File.Exists(chemin))
                    {
                        return new System.Drawing.Bitmap(chemin);
                    }
                }
                else if ((photo2 != null) ? !photo2.Trim().Equals("") : false)
                {
                    string chemin = Chemins.getCheminArticle() + photo2;
                    if (File.Exists(chemin))
                    {
                        return new System.Drawing.Bitmap(chemin);
                    }
                }
                else if ((photo3 != null) ? !photo3.Trim().Equals("") : false)
                {
                    string chemin = Chemins.getCheminArticle() + photo3;
                    if (File.Exists(chemin))
                    {
                        return new System.Drawing.Bitmap(chemin);
                    }
                }
                return global::GESTION_CAISSE.Properties.Resources.article; ;
            }
            set { }
        }

        private String categorie;
        public String Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        private FamilleArticle famille = new FamilleArticle();
        internal FamilleArticle Famille
        {
            get { return famille; }
            set { famille = value; }
        }

        private GroupeArticle groupe = new GroupeArticle();
        internal GroupeArticle Groupe
        {
            get { return groupe; }
            set { groupe = value; }
        }

        private List<PlanTarifaire> plans;
        internal List<PlanTarifaire> Plans
        {
            get { return plans; }
            set { plans = value; }
        }

        private double stock;
        public double Stock
        {
            get { return stock; }
            set { stock = value; }
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
