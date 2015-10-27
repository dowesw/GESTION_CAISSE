using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class CategorieComptableBll
    {
        static CategorieComptable categorie;

        internal CategorieComptable getCategorieComptable
        {
            get { return categorie; }
            set { categorie = value; }
        }

        public CategorieComptableBll(CategorieComptable unCategorieComptable)
        {
            categorie = unCategorieComptable;
        }

        public static CategorieComptable One(long id)
        {
            try
            {
                return CategorieComptableDao.getOneCategorieComptable(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public CategorieComptable Insert()
        {
            try
            {
                return CategorieComptableDao.getAjoutCategorieComptable(categorie);
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
                return CategorieComptableDao.getUpdateCategorieComptable(categorie);
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
                return CategorieComptableDao.getDeleteCategorieComptable(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<CategorieComptable> Liste(String query)
        {
            try
            {
                return CategorieComptableDao.getListCategorieComptable(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
