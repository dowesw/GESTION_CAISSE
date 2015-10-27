using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class DepotBll
    {
        static Depot depot;

        internal Depot getDepot
        {
            get { return depot; }
            set { depot = value; }
        }

        public DepotBll(Depot unDepot)
        {
            depot = unDepot;
        }

        public static Depot One(long id)
        {
            try
            {
                return DepotDao.getOneDepot(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Depot Insert()
        {
            try
            {
                return DepotDao.getAjoutDepot(depot);
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
                return DepotDao.getUpdateDepot(depot);
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
                return DepotDao.getDeleteDepot(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Depot> Liste(String query)
        {
            try
            {
                return DepotDao.getListDepot(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
