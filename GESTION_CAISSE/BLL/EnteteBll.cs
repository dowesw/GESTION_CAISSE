using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class EnteteBll
    {
        static Entete entete;

        internal Entete getEntete
        {
            get { return entete; }
            set { entete = value; }
        }

        public EnteteBll(Entete unEntete)
        {
            entete = unEntete;
        }

        public static Entete One(long id)
        {
            try
            {
                return EnteteDao.getOneEntete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static Entete One(Creneau creneau, DateTime date)
        {
            try
            {
                return EnteteDao.getOneEntete(creneau, date);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Entete Insert()
        {
            try
            {
                return EnteteDao.getAjoutEntete(entete);
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
                return EnteteDao.getUpdateEntete(entete);
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
                return EnteteDao.getDeleteEntete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Entete> Liste(String query)
        {
            try
            {
                return EnteteDao.getListEntete(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
