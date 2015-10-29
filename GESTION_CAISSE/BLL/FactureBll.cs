using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class FactureBll
    {
        static Facture facture;

        internal Facture getFacture
        {
            get { return facture; }
            set { facture = value; }
        }

        public FactureBll(Facture unFacture)
        {
            facture = unFacture;
        }

        public static Facture One(long id)
        {
            try
            {
                return FactureDao.getOneFacture(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static Facture One(String reference)
        {
            try
            {
                return FactureDao.getOneFacture(reference);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static Facture One_(String reference)
        {
            try
            {
                return FactureDao.getOneFacture_(reference);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Facture Insert()
        {
            try
            {
                return FactureDao.getAjoutFacture(facture);
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
                return FactureDao.getUpdateFacture(facture);
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
                return FactureDao.getDeleteFacture(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Facture> Liste(String query)
        {
            try
            {
                return FactureDao.getListFacture(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
