using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class CategorieClientBll
    {
        static CategorieClient categorie;

        internal CategorieClient getCategorieClient
        {
            get { return categorie; }
            set { categorie = value; }
        }

        public CategorieClientBll(CategorieClient unCategorieClient)
        {
            categorie = unCategorieClient;
        }

        public static CategorieClient One(long id)
        {
            try
            {
                return CategorieClientDao.getOneCategorieClient(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public CategorieClient Insert()
        {
            try
            {
                return CategorieClientDao.getAjoutCategorieClient(categorie);
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
                return CategorieClientDao.getUpdateCategorieClient(categorie);
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
                return CategorieClientDao.getDeleteCategorieClient(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<CategorieClient> Liste(String query)
        {
            try
            {
                return CategorieClientDao.getListCategorieClient(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
