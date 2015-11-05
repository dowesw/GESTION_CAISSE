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
    class MouvementStockDao
    {
        public static MouvementStock getOneMouvementStock(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_base_mouvement_stock where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                MouvementStock a = new MouvementStock();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new Article())
                            : new Article());
                        a.Mouvement = lect["mouvement"].ToString();
                        a.Quantite = (Double)((lect["quantite"] != null) ? (!lect["quantite"].ToString().Trim().Equals("") ? lect["quantite"] : 0) : 0);
                        a.DateDoc = (DateTime)((lect["date_doc"] != null) ? (!lect["date_doc"].ToString().Trim().Equals("") ? lect["date_doc"] : DateTime.Now) : DateTime.Now);
                        a.Depot = (lect["depot"] != null
                            ? (!lect["depot"].ToString().Trim().Equals("")
                            ? new Depot(Convert.ToInt64(lect["depot"].ToString()))
                            : new Depot())
                            : new Depot());
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
                String search = "select id from yvs_base_mouvement_stock order by id desc limit 1";
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

        public static MouvementStock getAjoutMouvementStock(MouvementStock a)
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

        public static bool getUpdateMouvementStock(MouvementStock a)
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

        public static bool getDeleteMouvementStock(long id)
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

        public static List<MouvementStock> getListMouvementStock(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<MouvementStock> l = new List<MouvementStock>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        MouvementStock a = new MouvementStock();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new Article())
                            : new Article());
                        a.Mouvement = lect["mouvement"].ToString();
                        a.Quantite = (Double)((lect["quantite"] != null) ? (!lect["quantite"].ToString().Trim().Equals("") ? lect["quantite"] : 0) : 0);
                        a.DateDoc = (DateTime)((lect["date_doc"] != null) ? (!lect["date_doc"].ToString().Trim().Equals("") ? lect["date_doc"] : DateTime.Now) : DateTime.Now);
                        a.Depot = (lect["depot"] != null
                            ? (!lect["depot"].ToString().Trim().Equals("")
                            ? new Depot(Convert.ToInt64(lect["depot"].ToString()))
                            : new Depot())
                            : new Depot());
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
