using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class PlanCommissionBll
    {
        static PlanCommission plan;

        internal PlanCommission getPlanCommission
        {
            get { return plan; }
            set { plan = value; }
        }

        public PlanCommissionBll(PlanCommission unPlanCommission)
        {
            plan = unPlanCommission;
        }

        public static PlanCommission One(long id)
        {
            try
            {
                return PlanCommissionDao.getOnePlanCommission(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public PlanCommission Insert()
        {
            try
            {
                return PlanCommissionDao.getAjoutPlanCommission(plan);
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
                return PlanCommissionDao.getUpdatePlanCommission(plan);
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
                return PlanCommissionDao.getDeletePlanCommission(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<PlanCommission> Liste(String query)
        {
            try
            {
                return PlanCommissionDao.getListPlanCommission(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
