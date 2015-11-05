using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class MouvementStockBll
    {
        static MouvementStock mouv;

        internal MouvementStock getMouvementStock
        {
            get { return mouv; }
            set { mouv = value; }
        }

        public MouvementStockBll(MouvementStock unMouvementStock)
        {
            mouv = unMouvementStock;
        }

        public static MouvementStock One(long id)
        {
            try
            {
                return MouvementStockDao.getOneMouvementStock(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public MouvementStock Insert()
        {
            try
            {
                return MouvementStockDao.getAjoutMouvementStock(mouv);
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
                return MouvementStockDao.getUpdateMouvementStock(mouv);
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
                return MouvementStockDao.getDeleteMouvementStock(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<MouvementStock> Liste(String query)
        {
            try
            {
                return MouvementStockDao.getListMouvementStock(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
