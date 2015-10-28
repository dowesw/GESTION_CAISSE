using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class ArticleComptableBll
    {
        static ArticleComptable article;

        internal ArticleComptable getArticleComptable
        {
            get { return article; }
            set { article = value; }
        }

        public ArticleComptableBll(ArticleComptable unArticleComptable)
        {
            article = unArticleComptable;
        }

        public static ArticleComptable One(long id)
        {
            try
            {
                return ArticleComptableDao.getOneArticleComptable(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public ArticleComptable Insert()
        {
            try
            {
                return ArticleComptableDao.getAjoutArticleComptable(article);
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
                return ArticleComptableDao.getUpdateArticleComptable(article);
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
                return ArticleComptableDao.getDeleteArticleComptable(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<ArticleComptable> Liste(String query)
        {
            try
            {
                return ArticleComptableDao.getListArticleComptable(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
