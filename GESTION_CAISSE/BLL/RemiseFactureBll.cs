using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class RemiseFactureBll
    {
        static RemiseFacture remise;

        internal RemiseFacture getRemiseFacture
        {
            get { return remise; }
            set { remise = value; }
        }

        public RemiseFactureBll(RemiseFacture unRemiseFacture)
        {
            remise = unRemiseFacture;
        }

        public static RemiseFacture One(long id)
        {
            try
            {
                return RemiseFactureDao.getOneRemiseFacture(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public RemiseFacture Insert()
        {
            try
            {
                return RemiseFactureDao.getAjoutRemiseFacture(remise);
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
                return RemiseFactureDao.getUpdateRemiseFacture(remise);
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
                return RemiseFactureDao.getDeleteRemiseFacture(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<RemiseFacture> Liste(String query)
        {
            try
            {
                return RemiseFactureDao.getListRemiseFacture(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
