using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class PlanTarifaireBll
    {
        static PlanTarifaire plan;

        internal PlanTarifaire getPlanTarifaire
        {
            get { return plan; }
            set { plan = value; }
        }

        public PlanTarifaireBll(PlanTarifaire unPlanTarifaire)
        {
            plan = unPlanTarifaire;
        }

        public static PlanTarifaire One(long id)
        {
            try
            {
                return PlanTarifaireDao.getOnePlanTarifaire(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public PlanTarifaire Insert()
        {
            try
            {
                return PlanTarifaireDao.getAjoutPlanTarifaire(plan);
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
                return PlanTarifaireDao.getUpdatePlanTarifaire(plan);
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
                return PlanTarifaireDao.getDeletePlanTarifaire(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<PlanTarifaire> Liste(String query)
        {
            try
            {
                return PlanTarifaireDao.getListPlanTarifaire(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
