using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class RemiseBll
    {
        static Remise remise;

        internal Remise getRemise
        {
            get { return remise; }
            set { remise = value; }
        }

        public RemiseBll(Remise unRemise)
        {
            remise = unRemise;
        }

        public static Remise One(long id)
        {
            try
            {
                return RemiseDao.getOneRemise(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Remise Insert()
        {
            try
            {
                return RemiseDao.getAjoutRemise(remise);
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
                return RemiseDao.getUpdateRemise(remise);
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
                return RemiseDao.getDeleteRemise(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Remise> Liste(String query)
        {
            try
            {
                return RemiseDao.getListRemise(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
