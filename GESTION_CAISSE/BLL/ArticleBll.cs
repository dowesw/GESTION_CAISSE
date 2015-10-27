using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class ArticleBll
    {
        static Article article;

        internal Article getArticle
        {
            get { return article; }
            set { article = value; }
        }

        public ArticleBll(Article unArticle)
        {
            article = unArticle;
        }

        public static Article One(long id)
        {
            try
            {
                return ArticleDao.getOneArticle(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Article Insert()
        {
            try
            {
                return ArticleDao.getAjoutArticle(article);
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
                return ArticleDao.getUpdateArticle(article);
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
                return ArticleDao.getDeleteArticle(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Article> Liste(String query)
        {
            try
            {
                return ArticleDao.getListArticle(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
