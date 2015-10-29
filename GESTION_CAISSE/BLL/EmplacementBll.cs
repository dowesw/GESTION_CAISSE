using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class EmplacementBll
    {
        static Emplacement emplacement;

        internal Emplacement getEmplacement
        {
            get { return emplacement; }
            set { emplacement = value; }
        }

        public EmplacementBll(Emplacement unEmplacement)
        {
            emplacement = unEmplacement;
        }

        public static Emplacement One(long id)
        {
            try
            {
                return EmplacementDao.getOneEmplacement(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Emplacement Insert()
        {
            try
            {
                return EmplacementDao.getAjoutEmplacement(emplacement);
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
                return EmplacementDao.getUpdateEmplacement(emplacement);
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
                return EmplacementDao.getDeleteEmplacement(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Emplacement> Liste(String query)
        {
            try
            {
                return EmplacementDao.getListEmplacement(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
