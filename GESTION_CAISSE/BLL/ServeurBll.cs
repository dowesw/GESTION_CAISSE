using System;
using System.Collections.Generic;
using System.Text;
using GESTION_CAISSE.DAO;
using GESTION_CAISSE.ENTITE;

namespace GESTION_CAISSE.BLL
{
    public class ServeurBll
    {

        static Serveur config = null;

        internal Serveur getConfig
        {
            get { return config; }
            set { config = value; }
        }

        public ServeurBll(Serveur uneConfig)
        {
            config = uneConfig;
        }

        public bool CreateServeur()
        {
            try
            {
                return ServeurDao.getCreateServeur(config);
            }
            catch (Exception ex)
            {
                throw new Exception("Echec de Création de fichier", ex);
            }
        }

        public static Serveur ReturnServeur()
        {
            try
            {
                return ServeurDao.getReturnServeur();
            }
            catch (Exception ex)
            {
                throw new Exception("Echec de Création de fichier", ex);
            }

        }

        public static bool UpdateServeur()
        {
            try
            {
                return ServeurDao.getUpdateServeur(config);
            }
            catch (Exception ex)
            {
                throw new Exception("Echec de Création de fichier", ex);
            }
        }
    }
}
