using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class ArticleTaxeBll
    {
        static ArticleTaxe article;

        internal ArticleTaxe getArticleTaxe
        {
            get { return article; }
            set { article = value; }
        }

        public ArticleTaxeBll(ArticleTaxe unArticleTaxe)
        {
            article = unArticleTaxe;
        }

        public static ArticleTaxe One(long id)
        {
            try
            {
                return ArticleTaxeDao.getOneArticleTaxe(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public ArticleTaxe Insert()
        {
            try
            {
                return ArticleTaxeDao.getAjoutArticleTaxe(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'inserer cette enregistrement", ex);
            }

        }

        public bool Update()
        {
            try
            {
                return ArticleTaxeDao.getUpdateArticleTaxe(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de modifier cette enregistrement", ex);
            }
        }

        public static bool Delete(long id)
        {
            try
            {
                return ArticleTaxeDao.getDeleteArticleTaxe(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<ArticleTaxe> Liste(String query)
        {
            try
            {
                return ArticleTaxeDao.getListArticleTaxe(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
