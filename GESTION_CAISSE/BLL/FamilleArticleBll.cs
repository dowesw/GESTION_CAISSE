using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class FamilleArticleBll
    {
        static FamilleArticle famille;

        internal FamilleArticle getFamilleArticle
        {
            get { return famille; }
            set { famille = value; }
        }

        public FamilleArticleBll(FamilleArticle unFamilleArticle)
        {
            famille = unFamilleArticle;
        }

        public static FamilleArticle One(long id)
        {
            try
            {
                return FamilleArticleDao.getOneFamilleArticle(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public FamilleArticle Insert()
        {
            try
            {
                return FamilleArticleDao.getAjoutFamilleArticle(famille);
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
                return FamilleArticleDao.getUpdateFamilleArticle(famille);
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
                return FamilleArticleDao.getDeleteFamilleArticle(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<FamilleArticle> Liste(String query)
        {
            try
            {
                return FamilleArticleDao.getListFamilleArticle(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
