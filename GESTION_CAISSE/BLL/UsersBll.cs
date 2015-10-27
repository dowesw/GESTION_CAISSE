using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class UsersBll
    {
        static Users users;

        internal Users getUsers
        {
            get { return users; }
            set { users = value; }
        }

        public UsersBll(Users unUsers)
        {
            users = unUsers;
        }

        public static Users One(long id)
        {
            try
            {
                return UsersDao.getOneUsers(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static Users One(String codeUsers, String password)
        {
            try
            {
                return UsersDao.getOneUsers(codeUsers, password);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Users Insert()
        {
            try
            {
                return UsersDao.getAjoutUsers(users);
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
                return UsersDao.getUpdateUsers(users);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de modifier cette enregistrement", ex);
            }
        }

        public bool Delete(long id)
        {
            try
            {
                return UsersDao.getDeleteUsers(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Users> Liste(String query)
        {
            try
            {
                return UsersDao.getListUsers(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
