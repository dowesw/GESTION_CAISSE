using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class RistourneBll
    {
        static Ristourne ristourne;

        internal Ristourne getRistourne
        {
            get { return ristourne; }
            set { ristourne = value; }
        }

        public RistourneBll(Ristourne unRistourne)
        {
            ristourne = unRistourne;
        }

        public static Ristourne One(long id)
        {
            try
            {
                return RistourneDao.getOneRistourne(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Ristourne Insert()
        {
            try
            {
                return RistourneDao.getAjoutRistourne(ristourne);
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
                return RistourneDao.getUpdateRistourne(ristourne);
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
                return RistourneDao.getDeleteRistourne(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Ristourne> Liste(String query)
        {
            try
            {
                return RistourneDao.getListRistourne(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
