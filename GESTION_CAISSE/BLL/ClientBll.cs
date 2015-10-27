using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class ClientBll
    {
        static Client client;

        internal Client getClient
        {
            get { return client; }
            set { client = value; }
        }

        public ClientBll(Client unClient)
        {
            client = unClient;
        }

        public static Client One(long id)
        {
            try
            {
                return ClientDao.getOneClient(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static Client Default()
        {
            try
            {
                return ClientDao.getDefaultClient();
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Client Insert()
        {
            try
            {
                return ClientDao.getAjoutClient(client);
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
                return ClientDao.getUpdateClient(client);
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
                return ClientDao.getDeleteClient(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Client> Liste(String query)
        {
            try
            {
                return ClientDao.getListClient(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
