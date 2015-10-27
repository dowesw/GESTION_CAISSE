using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class CommissionBll
    {
        static Commission commission;

        internal Commission getCommission
        {
            get { return commission; }
            set { commission = value; }
        }

        public CommissionBll(Commission unCommission)
        {
            commission = unCommission;
        }

        public static Commission One(long id)
        {
            try
            {
                return CommissionDao.getOneCommission(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Commission Insert()
        {
            try
            {
                return CommissionDao.getAjoutCommission(commission);
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
                return CommissionDao.getUpdateCommission(commission);
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
                return CommissionDao.getDeleteCommission(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Commission> Liste(String query)
        {
            try
            {
                return CommissionDao.getListCommission(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
