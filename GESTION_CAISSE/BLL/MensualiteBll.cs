using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class MensualiteBll
    {
        static Mensualite mensualite;

        internal Mensualite getMensualite
        {
            get { return mensualite; }
            set { mensualite = value; }
        }

        public MensualiteBll(Mensualite unMensualite)
        {
            mensualite = unMensualite;
        }

        public static Mensualite One(long id)
        {
            try
            {
                return MensualiteDao.getOneMensualite(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Mensualite Insert()
        {
            try
            {
                return MensualiteDao.getAjoutMensualite(mensualite);
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
                return MensualiteDao.getUpdateMensualite(mensualite);
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
                return MensualiteDao.getDeleteMensualite(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Mensualite> Liste(String query)
        {
            try
            {
                return MensualiteDao.getListMensualite(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
