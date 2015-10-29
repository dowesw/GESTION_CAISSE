using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class ArticleDepotBll
    {
        static ArticleDepot article;

        internal ArticleDepot getArticleDepot
        {
            get { return article; }
            set { article = value; }
        }

        public ArticleDepotBll(ArticleDepot unArticleDepot)
        {
            article = unArticleDepot;
        }

        public static ArticleDepot One(long id)
        {
            try
            {
                return ArticleDepotDao.getOneArticleDepot(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static ArticleDepot One(Article article)
        {
            try
            {
                return ArticleDepotDao.getOneArticleDepot(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public ArticleDepot Insert()
        {
            try
            {
                return ArticleDepotDao.getAjoutArticleDepot(article);
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
                return ArticleDepotDao.getUpdateArticleDepot(article);
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
                return ArticleDepotDao.getDeleteArticleDepot(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<ArticleDepot> Liste(String query)
        {
            try
            {
                return ArticleDepotDao.getListArticleDepot(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
