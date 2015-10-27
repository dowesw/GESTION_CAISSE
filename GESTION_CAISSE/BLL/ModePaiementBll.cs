using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class ModePaiementBll
    {
        static ModePaiement mode;

        internal ModePaiement getModePaiement
        {
            get { return mode; }
            set { mode = value; }
        }

        public ModePaiementBll(ModePaiement unModePaiement)
        {
            mode = unModePaiement;
        }

        public static ModePaiement One(long id)
        {
            try
            {
                return ModePaiementDao.getOneModePaiement(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public ModePaiement Insert()
        {
            try
            {
                return ModePaiementDao.getAjoutModePaiement(mode);
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
                return ModePaiementDao.getUpdateModePaiement(mode);
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
                return ModePaiementDao.getDeleteModePaiement(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<ModePaiement> Liste(String query)
        {
            try
            {
                return ModePaiementDao.getListModePaiement(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }

    }
}
