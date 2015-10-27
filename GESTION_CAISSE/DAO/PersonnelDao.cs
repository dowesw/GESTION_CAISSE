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
    class PersonnelDao
    {
        public static Personnel getOnePersonnel(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_personnel where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Personnel a = new Personnel();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Users = (lect["users"] != null
                            ? (!lect["users"].ToString().Trim().Equals("")
                            ? BLL.UsersBll.One(Convert.ToInt64(lect["users"].ToString()))
                            : new Users())
                            : new Users());
                        a.Commission = (lect["plan_commission"] != null
                            ? (!lect["plan_commission"].ToString().Trim().Equals("")
                            ? BLL.PlanCommissionBll.One(Convert.ToInt64(lect["plan_commission"].ToString()))
                            : new PlanCommission())
                            : new PlanCommission());
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

        public static Personnel getOnePersonnel(Users users)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_personnel where users = " + users.Id + " limit 1";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Personnel a = new Personnel();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Users = (lect["users"] != null
                            ? (!lect["users"].ToString().Trim().Equals("")
                            ? BLL.UsersBll.One(Convert.ToInt64(lect["users"].ToString()))
                            : new Users())
                            : new Users());
                        a.Commission = (lect["plan_commission"] != null
                            ? (!lect["plan_commission"].ToString().Trim().Equals("")
                            ? BLL.PlanCommissionBll.One(Convert.ToInt64(lect["plan_commission"].ToString()))
                            : new PlanCommission())
                            : new PlanCommission());
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
                String search = "select id from yvs_com_personnel order by id desc limit 1";
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

        public static Personnel getAjoutPersonnel(Personnel a)
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

        public static bool getUpdatePersonnel(Personnel a)
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

        public static bool getDeletePersonnel(long id)
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

        public static List<Personnel> getListPersonnel(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Personnel> l = new List<Personnel>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Personnel a = new Personnel();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Users = (lect["users"] != null
                            ? (!lect["users"].ToString().Trim().Equals("")
                            ? BLL.UsersBll.One(Convert.ToInt64(lect["users"].ToString()))
                            : new Users())
                            : new Users());
                        a.Commission = (lect["plan_commission"] != null
                            ? (!lect["plan_commission"].ToString().Trim().Equals("")
                            ? BLL.PlanCommissionBll.One(Convert.ToInt64(lect["plan_commission"].ToString()))
                            : new PlanCommission())
                            : new PlanCommission());
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
