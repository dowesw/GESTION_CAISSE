using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class CreneauBll
    {
        static Creneau creneau;

        internal Creneau getCreneau
        {
            get { return creneau; }
            set { creneau = value; }
        }

        public CreneauBll(Creneau unCreneau)
        {
            creneau = unCreneau;
        }

        public static Creneau One(long id)
        {
            try
            {
                return CreneauDao.getOneCreneau(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static Creneau One(Personnel pers)
        {
            try
            {
                return CreneauDao.getOneCreneau(pers);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static Creneau One(Personnel pers, DateTime date)
        {
            try
            {
                return CreneauDao.getOneCreneau(pers, date);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static Creneau One(Personnel pers, DateTime date, DateTime heureDebut, DateTime heureFin)
        {
            try
            {
                return CreneauDao.getOneCreneau(pers, date, heureDebut, heureFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Creneau Insert()
        {
            try
            {
                return CreneauDao.getAjoutCreneau(creneau);
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
                return CreneauDao.getUpdateCreneau(creneau);
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
                return CreneauDao.getDeleteCreneau(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Creneau> Liste(String query)
        {
            try
            {
                return CreneauDao.getListCreneau(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
