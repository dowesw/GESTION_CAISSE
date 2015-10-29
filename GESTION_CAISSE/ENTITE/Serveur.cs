using System;
using System.Collections.Generic;
using System.Text;
using GESTION_CAISSE.TOOLS;

namespace GESTION_CAISSE.ENTITE
{
    [Serializable]
    public class Serveur
    {
        private string adresse;
        private int port;
        private string user;
        private string password;
        private string database;

        public string getAdresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public string getUser
        {
            get { return user; }
            set { user = value; }
        }

        public string getPassword
        {
            get { return password; }
            set { password = value; }
        }

        public string getDatabase
        {
            get { return database; }
            set { database = value; }
        }

        public int getPort
        {
            get { return port; }
            set { port = value; }
        }

        public Boolean Control()
        {
            Serveur bean = this;
            return Control(bean);
        }

        public static Boolean Control(Serveur bean)
        {
            if (bean == null)
            {
                Messages.ShowErreur("Serveur Incorrect!");
                return false;
            }
            if (bean.adresse == null || bean.adresse.Trim().Equals(""))
            {
                Messages.ShowErreur("L'adresse du serveur ne peut pas être null!");
                return false;
            }
            if (bean.database == null || bean.database.Trim().Equals(""))
            {
                Messages.ShowErreur("La base de donnée ne peut pas être null!");
                return false;
            }
            if (bean.port < 0)
            {
                Messages.ShowErreur("Le numéro du port ne peut pas être inferieur a 0!");
                return false;
            }
            return true;
        }

        public Boolean Control_()
        {
            return Control_(this);
        }

        public static Boolean Control_(Serveur bean)
        {
            if (bean == null)
            {
                return false;
            }
            if (bean.adresse == null || bean.adresse.Trim().Equals(""))
            {
                return false;
            }
            if (bean.database == null || bean.database.Trim().Equals(""))
            {
                return false;
            }
            if (bean.port < 0)
            {
                return false;
            }
            return true;
        }
    }
}
