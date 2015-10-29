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
    class PlanTarifaireDao
    {
        public static PlanTarifaire getOnePlanTarifaire(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_base_plan_tarifaire_article where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                PlanTarifaire a = new PlanTarifaire();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Code = lect["code"].ToString();
                        a.Actif = (Boolean)((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"] : false) : false);
                        a.Puv = (Double)((lect["puv_minimal"] != null) ? (!lect["puv_minimal"].ToString().Trim().Equals("") ? lect["puv_minimal"] : 0) : 0);
                        a.Remise = (Double)((lect["remise"] != null) ? (!lect["remise"].ToString().Trim().Equals("") ? lect["remise"] : 0) : 0);
                        a.Ristourne = (Double)((lect["ristourne"] != null) ? (!lect["ristourne"].ToString().Trim().Equals("") ? lect["ristourne"] : 0) : 0);
                        a.Remise_ = (lect["remise"] != null
                            ? (!lect["remise"].ToString().Trim().Equals("")
                            ? BLL.RemiseBll.One(Convert.ToInt64(lect["remise"].ToString()))
                            : new Remise())
                            : new Remise());
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
                String search = "select id from yvs_base_plan_tarifaire_article order by id desc limit 1";
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

        public static PlanTarifaire getAjoutPlanTarifaire(PlanTarifaire a)
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

        public static bool getUpdatePlanTarifaire(PlanTarifaire a)
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

        public static bool getDeletePlanTarifaire(long id)
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

        public static List<PlanTarifaire> getListPlanTarifaire(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<PlanTarifaire> l = new List<PlanTarifaire>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        PlanTarifaire a = new PlanTarifaire();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Code = lect["code"].ToString();
                        a.Actif = (Boolean)((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"] : false) : false);
                        a.Puv = (Double)((lect["puv_minimal"] != null) ? (!lect["puv_minimal"].ToString().Trim().Equals("") ? lect["puv_minimal"] : 0) : 0);
                        a.Remise = (Double)((lect["remise"] != null) ? (!lect["remise"].ToString().Trim().Equals("") ? lect["remise"] : 0) : 0);
                        a.Ristourne = (Double)((lect["ristourne"] != null) ? (!lect["ristourne"].ToString().Trim().Equals("") ? lect["ristourne"] : 0) : 0);
                        a.Remise_ = (lect["remise"] != null
                            ? (!lect["remise"].ToString().Trim().Equals("")
                            ? BLL.RemiseBll.One(Convert.ToInt64(lect["remise"].ToString()))
                            : new Remise())
                            : new Remise());
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
