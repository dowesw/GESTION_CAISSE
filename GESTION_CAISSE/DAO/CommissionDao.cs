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
    class CommissionDao
    {
        public static Commission getOneCommission(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_commission where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Commission a = new Commission();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Nature = lect["nature_montant"].ToString();
                        a.DateDebut = Convert.ToDateTime((lect["date_debut"] != null) ? (!lect["date_debut"].ToString().Trim().Equals("") ? lect["date_debut"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.DateFin = Convert.ToDateTime((lect["date_fin"] != null) ? (!lect["date_fin"].ToString().Trim().Equals("") ? lect["date_fin"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.Actif = Convert.ToBoolean((lect["actif"]!= null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
                        a.Permanent = Convert.ToBoolean((lect["permanent"] != null) ? (!lect["permanent"].ToString().Trim().Equals("") ? lect["permanent"].ToString().Trim() : "false") : "false");
                        a.Montant = Convert.ToDouble(((lect["montant_commission"] != null) ? ((!lect["montant_commission"].ToString().Trim().Equals("")) ? lect["montant_commission"].ToString() : "0") : "0"));
                        a.MontantMaximal = Convert.ToDouble(((lect["montant_maximal"] != null) ? ((!lect["montant_maximal"].ToString().Trim().Equals("")) ? lect["montant_maximal"].ToString() : "0") : "0"));
                        a.MontantMinimal = Convert.ToDouble(((lect["montant_minimun"] != null) ? ((!lect["montant_minimun"].ToString().Trim().Equals("")) ? lect["montant_minimun"].ToString() : "0") : "0"));
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleComBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new ArticleCom())
                            : new ArticleCom());
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
                String search = "select id from yvs_com_commission order by id desc limit 1";
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

        public static Commission getAjoutCommission(Commission a)
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

        public static bool getUpdateCommission(Commission a)
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

        public static bool getDeleteCommission(long id)
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

        public static List<Commission> getListCommission(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Commission> l = new List<Commission>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Commission a = new Commission();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Nature = lect["nature_montant"].ToString();
                        a.DateDebut = Convert.ToDateTime((lect["date_debut"] != null) ? (!lect["date_debut"].ToString().Trim().Equals("") ? lect["date_debut"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.DateFin = Convert.ToDateTime((lect["date_fin"] != null) ? (!lect["date_fin"].ToString().Trim().Equals("") ? lect["date_fin"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.Actif = Convert.ToBoolean((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
                        a.Permanent = Convert.ToBoolean((lect["permanent"] != null) ? (!lect["permanent"].ToString().Trim().Equals("") ? lect["permanent"].ToString().Trim() : "false") : "false");
                        a.Montant = Convert.ToDouble(((lect["montant_commission"] != null) ? ((!lect["montant_commission"].ToString().Trim().Equals("")) ? lect["montant_commission"].ToString() : "0") : "0"));
                        a.MontantMaximal = Convert.ToDouble(((lect["montant_maximal"] != null) ? ((!lect["montant_maximal"].ToString().Trim().Equals("")) ? lect["montant_maximal"].ToString() : "0") : "0"));
                        a.MontantMinimal = Convert.ToDouble(((lect["montant_minimun"] != null) ? ((!lect["montant_minimun"].ToString().Trim().Equals("")) ? lect["montant_minimun"].ToString() : "0") : "0"));
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleComBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new ArticleCom())
                            : new ArticleCom());
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
