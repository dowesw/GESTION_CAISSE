using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class TrancheHoraireBll
    {
        static TrancheHoraire tranche;

        internal TrancheHoraire getTrancheHoraire
        {
            get { return tranche; }
            set { tranche = value; }
        }

        public TrancheHoraireBll(TrancheHoraire unTrancheHoraire)
        {
            tranche = unTrancheHoraire;
        }

        public static TrancheHoraire One(long id)
        {
            try
            {
                return TrancheHoraireDao.getOneTrancheHoraire(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public TrancheHoraire Insert()
        {
            try
            {
                return TrancheHoraireDao.getAjoutTrancheHoraire(tranche);
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
                return TrancheHoraireDao.getUpdateTrancheHoraire(tranche);
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
                return TrancheHoraireDao.getDeleteTrancheHoraire(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<TrancheHoraire> Liste(String query)
        {
            try
            {
                return TrancheHoraireDao.getListTrancheHoraire(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
