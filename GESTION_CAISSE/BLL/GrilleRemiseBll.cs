using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class GrilleRemiseBll
    {
        static GrilleRabais grille;

        internal GrilleRabais getGrilleRabais
        {
            get { return grille; }
            set { grille = value; }
        }

        public GrilleRemiseBll(GrilleRabais unGrilleRabais)
        {
            grille = unGrilleRabais;
        }

        public static GrilleRabais One(long id)
        {
            try
            {
                return GrilleRemiseDao.getOneGrilleRemise(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public GrilleRabais Insert()
        {
            try
            {
                return GrilleRemiseDao.getAjoutGrilleRemise(grille);
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
                return GrilleRemiseDao.getUpdateGrilleRemise(grille);
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
                return GrilleRemiseDao.getDeleteGrilleRemise(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<GrilleRabais> Liste(String query)
        {
            try
            {
                return GrilleRemiseDao.getListGrilleRemise(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
