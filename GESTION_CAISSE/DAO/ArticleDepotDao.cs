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
    class ArticleDepotDao
    {
        public static ArticleDepot getOneArticleDepot(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_base_article_depot where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                ArticleDepot a = new ArticleDepot();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Emplcement = (lect["emplacement"] != null
                            ? (!lect["emplacement"].ToString().Trim().Equals("")
                            ? new Emplacement(Convert.ToInt64(lect["emplacement"].ToString()))
                            : new Emplacement())
                            : new Emplacement());
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new Article())
                            : new Article());
                        a.ModeAppro = lect["mode_appro"].ToString().Trim();
                        a.ModeReappro = lect["mode_reappro"].ToString().Trim();
                        a.StockAlert = (Double)((lect["stock_alert"] != null) ? (!lect["stock_alert"].ToString().Trim().Equals("") ? lect["stock_alert"] : 0) : 0);
                        a.StockMax = (Double)((lect["stock_max"] != null) ? (!lect["stock_max"].ToString().Trim().Equals("") ? lect["stock_max"] : 0) : 0);
                        a.StockMin = (Double)((lect["stock_min"] != null) ? (!lect["stock_min"].ToString().Trim().Equals("") ? lect["stock_min"] : 0) : 0);
                        a.Stock = (Double)((lect["quantite_stock"] != null) ? (!lect["quantite_stock"].ToString().Trim().Equals("") ? lect["quantite_stock"] : 0) : 0);
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

        public static ArticleDepot getOneArticleDepot(Article article)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_base_article_depot where article = " + article.Id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                ArticleDepot a = new ArticleDepot();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Emplcement = (lect["emplacement"] != null
                            ? (!lect["emplacement"].ToString().Trim().Equals("")
                            ? new Emplacement(Convert.ToInt64(lect["emplacement"].ToString()))
                            : new Emplacement())
                            : new Emplacement());
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new Article())
                            : new Article());
                        a.ModeAppro = lect["mode_appro"].ToString().Trim();
                        a.ModeReappro = lect["mode_reappro"].ToString().Trim();
                        a.StockAlert = (Double)((lect["stock_alert"] != null) ? (!lect["stock_alert"].ToString().Trim().Equals("") ? lect["stock_alert"] : 0) : 0);
                        a.StockMax = (Double)((lect["stock_max"] != null) ? (!lect["stock_max"].ToString().Trim().Equals("") ? lect["stock_max"] : 0) : 0);
                        a.StockMin = (Double)((lect["stock_min"] != null) ? (!lect["stock_min"].ToString().Trim().Equals("") ? lect["stock_min"] : 0) : 0);
                        a.Stock = (Double)((lect["quantite_stock"] != null) ? (!lect["quantite_stock"].ToString().Trim().Equals("") ? lect["quantite_stock"] : 0) : 0);
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
                String search = "select id from yvs_base_article_depot order by id desc limit 1";
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

        public static ArticleDepot getAjoutArticleDepot(ArticleDepot a)
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

        public static bool getUpdateArticleDepot(ArticleDepot a)
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

        public static bool getDeleteArticleDepot(long id)
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

        public static List<ArticleDepot> getListArticleDepot(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<ArticleDepot> l = new List<ArticleDepot>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        ArticleDepot a = new ArticleDepot();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Emplcement = (lect["emplacement"] != null
                            ? (!lect["emplacement"].ToString().Trim().Equals("")
                            ? new Emplacement(Convert.ToInt64(lect["emplacement"].ToString()))
                            : new Emplacement())
                            : new Emplacement());
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new Article())
                            : new Article());
                        a.ModeAppro = lect["mode_appro"].ToString().Trim();
                        a.ModeReappro = lect["mode_reappro"].ToString().Trim();
                        a.StockAlert = (Double)((lect["stock_alert"] != null) ? (!lect["stock_alert"].ToString().Trim().Equals("") ? lect["stock_alert"] : 0) : 0);
                        a.StockMax = (Double)((lect["stock_max"] != null) ? (!lect["stock_max"].ToString().Trim().Equals("") ? lect["stock_max"] : 0) : 0);
                        a.StockMin = (Double)((lect["stock_min"] != null) ? (!lect["stock_min"].ToString().Trim().Equals("") ? lect["stock_min"] : 0) : 0);
                        a.Stock = (Double)((lect["quantite_stock"] != null) ? (!lect["quantite_stock"].ToString().Trim().Equals("") ? lect["quantite_stock"] : 0) : 0);
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
