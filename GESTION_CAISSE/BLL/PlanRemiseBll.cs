using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class PlanRemiseBll
    {
        static PlanRemise plan;

        internal PlanRemise getPlanRemise
        {
            get { return plan; }
            set { plan = value; }
        }

        public PlanRemiseBll(PlanRemise unPlanRemise)
        {
            plan = unPlanRemise;
        }

        public static PlanRemise One(long id)
        {
            try
            {
                return PlanRemiseDao.getOnePlanRemise(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public PlanRemise Insert()
        {
            try
            {
                return PlanRemiseDao.getAjoutPlanRemise(plan);
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
                return PlanRemiseDao.getUpdatePlanRemise(plan);
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
                return PlanRemiseDao.getDeletePlanRemise(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<PlanRemise> Liste(String query)
        {
            try
            {
                return PlanRemiseDao.getListPlanRemise(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
