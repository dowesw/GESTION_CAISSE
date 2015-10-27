using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GESTION_CAISSE.DAO;
using GESTION_CAISSE.ENTITE;
using System.Windows.Forms;

namespace GESTION_CAISSE.BLL
{
    class ConfigurationBLL
    {
        Form unForm = null;
        static Configuration uneConfig = null;

        internal Form getUnForm
        {
            get { return unForm; }
            set { unForm = value; }
        }
        
        internal Configuration getUneConfig
        {
            get { return uneConfig; }
            set { uneConfig = value; }
        }

        public ConfigurationBLL(Form unForm, Configuration config)
        {
            this.unForm = unForm;
            uneConfig = config;
        }

        public ConfigurationBLL(Form unForm)
        {
            this.unForm = unForm;
        }

        public ConfigurationBLL(Configuration config)
        {
           uneConfig = config;
        }

        public ConfigurationBLL() { }

        public void getConfigurerForm()
        {
            try
            {
                ConfigurationDAO.getConfigureForm(unForm);
            }
            catch (Exception ex)
            {
                throw new Exception("La configuration n'a pas pu se faire:", ex);
            }
        }

        public static void getConfigurerForm(Form form)
        {
            try
            {
                ConfigurationDAO.getConfigureForm(form);
            }
            catch (Exception ex)
            {
                throw new Exception("La configuration n'a pas pu se faire:", ex);
            }
        }
        
        public bool getCreateConfiguration()
        {
            try
            {
                return ConfigurationDAO.getCreateConfiguration(uneConfig);
            }
            catch (Exception ex)
            {
                throw new Exception("Echec de Création de fichier", ex);
            }
        }
        
        public static Configuration getReturnConfiguration()
        {
            try
            {
                return ConfigurationDAO.getReturnConfiguration();
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner le fichier", ex);
            }

        }
        
        public bool getUpdateConfiguration()
        {
            try
            {
                return ConfigurationDAO.getUpdateConfiguration(uneConfig);
            }
            catch (Exception ex)
            {
                throw new Exception("Echec de modification de fichier", ex);
            }
        }
    }
}
