using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class CompteBll
    {
        static Compte compte;

        internal Compte getCompte
        {
            get { return compte; }
            set { compte = value; }
        }

        public CompteBll(Compte unCompte)
        {
            compte = unCompte;
        }

        public static Compte One(long id)
        {
            try
            {
                return CompteDao.getOneCompte(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Compte Insert()
        {
            try
            {
                return CompteDao.getAjoutCompte(compte);
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
                return CompteDao.getUpdateCompte(compte);
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
                return CompteDao.getDeleteCompte(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Compte> Liste(String query)
        {
            try
            {
                return CompteDao.getListCompte(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
