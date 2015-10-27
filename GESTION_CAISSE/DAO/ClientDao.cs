using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.TOOLS;

namespace GESTION_CAISSE.DAO
{
    class ClientDao
    {
        public static Client getOneClient(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_client where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Client a = new Client();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Defaut = Convert.ToBoolean((lect["defaut"] != null) ? (!lect["defaut"].ToString().Trim().Equals("") ? lect["defaut"].ToString() : "false") : "false");
                        a.Tiers = (lect["tiers"] != null
                            ? (!lect["tiers"].ToString().Trim().Equals("")
                            ? BLL.TiersBll.One(Convert.ToInt64(lect["tiers"].ToString()))
                            : new Tiers())
                            : new Tiers());
                        a.Nom_prenom = a.Tiers.Nom_prenom;
                        a.CategorieClt = (lect["categorie"] != null
                            ? (!lect["categorie"].ToString().Trim().Equals("")
                            ? BLL.CategorieClientBll.One(Convert.ToInt64(lect["categorie"].ToString()))
                            : new CategorieClient())
                            : new CategorieClient());
                        a.Categorie = (lect["categorie_comptable"] != null
                            ? (!lect["categorie_comptable"].ToString().Trim().Equals("")
                            ? BLL.CategorieComptableBll.One(Convert.ToInt64(lect["categorie_comptable"].ToString()))
                            : new CategorieComptable())
                            : new CategorieComptable());
                        a.Update = true;
                    }
                    lect.Close();
                }
                return a;
            }
            catch (NpgsqlException e)
            {
                Messages.Exception(e);
                return null;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }
        public static Client getDefaultClient()
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_client where defaut = true limit 1";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Client a = new Client();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Defaut = Convert.ToBoolean((lect["defaut"] != null) ? (!lect["defaut"].ToString().Trim().Equals("") ? lect["defaut"].ToString() : "false") : "false");
                        a.Tiers = (lect["tiers"] != null
                            ? (!lect["tiers"].ToString().Trim().Equals("")
                            ? BLL.TiersBll.One(Convert.ToInt64(lect["tiers"].ToString()))
                            : new Tiers())
                            : new Tiers());
                        a.Nom_prenom = a.Tiers.Nom_prenom;
                        a.CategorieClt = (lect["categorie"] != null
                            ? (!lect["categorie"].ToString().Trim().Equals("")
                            ? BLL.CategorieClientBll.One(Convert.ToInt64(lect["categorie"].ToString()))
                            : new CategorieClient())
                            : new CategorieClient());
                        a.Categorie = (lect["categorie_comptable"] != null
                            ? (!lect["categorie_comptable"].ToString().Trim().Equals("")
                            ? BLL.CategorieComptableBll.One(Convert.ToInt64(lect["categorie_comptable"].ToString()))
                            : new CategorieComptable())
                            : new CategorieComptable());
                        a.Update = true;
                    }
                    lect.Close();
                }
                return a;
            }
            catch (NpgsqlException e)
            {
                Messages.Exception(e);
                return null;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        private static long getCurrent()
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select id from yvs_com_client order by id desc limit 1";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                long id = 0;
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        id = Convert.ToInt64(lect["id"].ToString());
                    }
                    lect.Close();
                }
                return id;
            }
            catch (NpgsqlException e)
            {
                Messages.Exception(e);
                return 0;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        public static Client getAjoutClient(Client a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string insert = "";
                NpgsqlCommand cmd = new NpgsqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                a.Id = getCurrent();
                return a;
            }
            catch
            {
                return null;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        public static bool getUpdateClient(Client a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string update = "";
                NpgsqlCommand Ucmd = new NpgsqlCommand(update, con);
                Ucmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Messages.Exception(e);
                return false;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        public static bool getDeleteClient(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string delete = "";
                NpgsqlCommand Ucmd = new NpgsqlCommand(delete, con);
                Ucmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Messages.Exception(e);
                return false;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        public static List<Client> getListClient(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Client> l = new List<Client>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Client a = new Client();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Defaut = Convert.ToBoolean((lect["defaut"] != null) ? (!lect["defaut"].ToString().Trim().Equals("") ? lect["defaut"].ToString() : "false") : "false");
                        a.Tiers = (lect["tiers"] != null
                            ? (!lect["tiers"].ToString().Trim().Equals("")
                            ? BLL.TiersBll.One(Convert.ToInt64(lect["tiers"].ToString()))
                            : new Tiers())
                            : new Tiers());
                        a.Nom_prenom = a.Tiers.Nom_prenom;
                        a.CategorieClt = (lect["categorie"] != null
                            ? (!lect["categorie"].ToString().Trim().Equals("")
                            ? BLL.CategorieClientBll.One(Convert.ToInt64(lect["categorie"].ToString()))
                            : new CategorieClient())
                            : new CategorieClient());
                        a.Categorie = (lect["categorie_comptable"] != null
                            ? (!lect["categorie_comptable"].ToString().Trim().Equals("")
                            ? BLL.CategorieComptableBll.One(Convert.ToInt64(lect["categorie_comptable"].ToString()))
                            : new CategorieComptable())
                            : new CategorieComptable());
                        a.Update = true;
                        l.Add(a);
                    }
                    lect.Close();
                }
                return l;
            }
            catch (NpgsqlException e)
            {
                Messages.Exception(e);
                return null;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }
    }
}
