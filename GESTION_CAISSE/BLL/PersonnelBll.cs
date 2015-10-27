using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class PersonnelBll
    {
        static Personnel personnel;

        internal Personnel getPersonnel
        {
            get { return personnel; }
            set { personnel = value; }
        }

        public PersonnelBll(Personnel unPersonnel)
        {
            personnel = unPersonnel;
        }

        public static Personnel One(long id)
        {
            try
            {
                return PersonnelDao.getOnePersonnel(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static Personnel One(Users users)
        {
            try
            {
                return PersonnelDao.getOnePersonnel(users);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Personnel Insert()
        {
            try
            {
                return PersonnelDao.getAjoutPersonnel(personnel);
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
                return PersonnelDao.getUpdatePersonnel(personnel);
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
                return PersonnelDao.getDeletePersonnel(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Personnel> Liste(String query)
        {
            try
            {
                return PersonnelDao.getListPersonnel(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
