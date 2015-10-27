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
    class UsersDao
    {
        public static Users getOneUsers(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_users where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Users a = new Users();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Civilite = lect["civilite"].ToString().Trim();
                        a.NomUser = lect["nom_users"].ToString().Trim();
                        a.CodeUsers = lect["code_users"].ToString().Trim();
                        a.Password = lect["password_user"].ToString().Trim();
                        a.Photo = lect["photo"].ToString().Trim();
                        a.Actif = Convert.ToBoolean((lect["actif"].ToString() != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
                        a.Connected = Convert.ToBoolean((lect["connecte"].ToString() != null) ? (!lect["connecte"].ToString().Trim().Equals("") ? lect["connecte"].ToString().Trim() : "false") : "false");
                        a.Admin = false;
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
        public static Users getOneUsers(String codeUsers, String password)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_users where code_users = '" + codeUsers + "' and password_user = '" + password + "' and supp = false";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Users a = new Users();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Civilite = lect["civilite"].ToString().Trim();
                        a.NomUser = lect["nom_users"].ToString().Trim();
                        a.CodeUsers = lect["code_users"].ToString().Trim();
                        a.Password = lect["password_user"].ToString().Trim();
                        a.Photo = lect["photo"].ToString().Trim();
                        a.Actif = Convert.ToBoolean((lect["actif"].ToString() != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
                        a.Connected = Convert.ToBoolean((lect["connecte"].ToString() != null) ? (!lect["connecte"].ToString().Trim().Equals("") ? lect["connecte"].ToString().Trim() : "false") : "false");
                        TOOLS.Constantes.Agence = BLL.AgenceBll.One(Convert.ToInt64(lect["agence"].ToString()));
                        a.Employe = null;
                        a.Admin = false;
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
                String search = "select id from yvs_users order by id desc limit 1";
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

        public static Users getAjoutUsers(Users a)
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

        public static bool getUpdateUsers(Users a)
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

        public static bool getDeleteUsers(long id)
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

        public static List<Users> getListUsers(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Users> l = new List<Users>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Users a = new Users();

                        a.Admin = false;
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
