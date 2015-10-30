using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class ArticleComBll
    {
        static ArticleCom article;

        internal ArticleCom getArticleCom
        {
            get { return article; }
            set { article = value; }
        }

        public ArticleComBll(ArticleCom unArticleCom)
        {
            article = unArticleCom;
        }

        public static ArticleCom One(long id)
        {
            try
            {
                return ArticleComDao.getOneArticleCom(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static ArticleCom One(Article article)
        {
            try
            {
                return ArticleComDao.getOneArticleCom(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static ArticleCom One(ArticleDepot article)
        {
            try
            {
                return ArticleComDao.getOneArticleCom(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public ArticleCom Insert()
        {
            try
            {
                return ArticleComDao.getAjoutArticleCom(article);
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
                return ArticleComDao.getUpdateArticleCom(article);
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
                return ArticleComDao.getDeleteArticleCom(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<ArticleCom> Liste(String query)
        {
            try
            {
                return ArticleComDao.getListArticleCom(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
