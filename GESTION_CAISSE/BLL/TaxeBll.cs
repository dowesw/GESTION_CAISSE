using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class TaxeBll
    {
        static Taxe taxe;

        internal Taxe getTaxe
        {
            get { return taxe; }
            set { taxe = value; }
        }

        public TaxeBll(Taxe unTaxe)
        {
            taxe = unTaxe;
        }

        public static Taxe One(long id)
        {
            try
            {
                return TaxeDao.getOneTaxe(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Taxe Insert()
        {
            try
            {
                return TaxeDao.getAjoutTaxe(taxe);
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
                return TaxeDao.getUpdateTaxe(taxe);
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
                return TaxeDao.getDeleteTaxe(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Taxe> Liste(String query)
        {
            try
            {
                return TaxeDao.getListTaxe(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
