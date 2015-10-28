using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class PieceCaisseBll
    {
        static PieceCaisse piece;

        internal PieceCaisse getPieceCaisse
        {
            get { return piece; }
            set { piece = value; }
        }

        public PieceCaisseBll(PieceCaisse unPieceCaisse)
        {
            piece = unPieceCaisse;
        }

        public static PieceCaisse One(long id)
        {
            try
            {
                return PieceCaisseDao.getOnePieceCaisse(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public PieceCaisse Insert()
        {
            try
            {
                return PieceCaisseDao.getAjoutPieceCaisse(piece);
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
                return PieceCaisseDao.getUpdatePieceCaisse(piece);
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
                return PieceCaisseDao.getDeletePieceCaisse(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<PieceCaisse> Liste(String query)
        {
            try
            {
                return PieceCaisseDao.getListPieceCaisse(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
