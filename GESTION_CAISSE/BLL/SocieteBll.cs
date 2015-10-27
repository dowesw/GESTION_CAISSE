using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class SocieteBll
    {
        static Societe societe;

        internal Societe getSociete
        {
            get { return societe; }
            set { societe = value; }
        }

        public SocieteBll(Societe unSociete)
        {
            societe = unSociete;
        }

        public static Societe One(long id)
        {
            try
            {
                return SocieteDao.getOneSociete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Societe Insert()
        {
            try
            {
                return SocieteDao.getAjoutSociete(societe);
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
                return SocieteDao.getUpdateSociete(societe);
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
                return SocieteDao.getDeleteSociete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Societe> Liste(String query)
        {
            try
            {
                return SocieteDao.getListSociete(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
