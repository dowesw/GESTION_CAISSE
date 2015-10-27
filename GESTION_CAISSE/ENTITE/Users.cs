using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GESTION_CAISSE.TOOLS;

namespace GESTION_CAISSE.ENTITE
{
    public class Users
    {
        public Users()
        {

        }

        public Users(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String civilite;
        public String Civilite
        {
            get { return civilite; }
            set { civilite = value; }
        }

        private String codeUsers;
        public String CodeUsers
        {
            get { return codeUsers; }
            set { codeUsers = value; }
        }

        private String password;
        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        private String nomUser;
        public String NomUser
        {
            get { return nomUser; }
            set { nomUser = value; }
        }

        private String photo;
        public String Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        private bool connected;
        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }

        private Employe employe;
        internal Employe Employe
        {
            get { return employe; }
            set { employe = value; }
        }

        private bool actif;
        public bool Actif
        {
            get { return actif; }
            set { actif = value; }
        }

        public bool correct()
        {
            return correct(this);
        }

        public bool correct(Users users)
        {
            if (users.codeUsers == null || users.codeUsers.Trim().Equals(""))
            {
                Messages.Erreur("Le code ne peut pas être null!");
                return false;
            }
            if (users.password == null || users.password.Trim().Equals(""))
            {
                Messages.Erreur("Le mot de passe ne peut pas être null!");
                return false;
            }
            return true;
        }

    }
}