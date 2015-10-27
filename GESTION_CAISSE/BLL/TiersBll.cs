using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class TiersBll
    {
        static Tiers tiers;

        internal Tiers getTiers
        {
            get { return tiers; }
            set { tiers = value; }
        }

        public TiersBll(Tiers unTiers)
        {
            tiers = unTiers;
        }

        public static Tiers One(long id)
        {
            try
            {
                return TiersDao.getOneTiers(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Tiers Insert()
        {
            try
            {
                return TiersDao.getAjoutTiers(tiers);
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
                return TiersDao.getUpdateTiers(tiers);
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
                return TiersDao.getDeleteTiers(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Tiers> Liste(String query)
        {
            try
            {
                return TiersDao.getListTiers(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
