using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class AgenceBll
    {
        static Agence agence;

        internal Agence getAgence
        {
            get { return agence; }
            set { agence = value; }
        }

        public AgenceBll(Agence unAgence)
        {
            agence = unAgence;
        }

        public static Agence One(long id)
        {
            try
            {
                return AgenceDao.getOneAgence(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Agence Insert()
        {
            try
            {
                return AgenceDao.getAjoutAgence(agence);
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
                return AgenceDao.getUpdateAgence(agence);
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
                return AgenceDao.getDeleteAgence(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Agence> Liste(String query)
        {
            try
            {
                return AgenceDao.getListAgence(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
