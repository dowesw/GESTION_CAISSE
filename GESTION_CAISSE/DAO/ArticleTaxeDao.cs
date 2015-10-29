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
    class ArticleTaxeDao
    {
        public static ArticleTaxe getOneArticleTaxe(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_base_article_categorie_comptable_taxe where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                ArticleTaxe a = new ArticleTaxe();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Actif = (Boolean)((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"] : false) : false);
                        a.Article = (lect["article_categorie"] != null
                            ? (!lect["article_categorie"].ToString().Trim().Equals("")
                            ? new ArticleComptable(Convert.ToInt64(lect["article_categorie"].ToString()))
                            : new ArticleComptable())
                            : new ArticleComptable());
                        a.Taxe = (lect["taxe"] != null
                            ? (!lect["taxe"].ToString().Trim().Equals("")
                            ? BLL.TaxeBll.One(Convert.ToInt64(lect["taxe"].ToString()))
                            : new Taxe())
                            : new Taxe());
                        a.AppRemise = (Boolean)((lect["app_remise"] != null) ? (!lect["app_remise"].ToString().Trim().Equals("") ? lect["app_remise"] : false) : false);
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
                String search = "select id from yvs_base_article_categorie_comptable_taxe order by id desc limit 1";
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

        public static ArticleTaxe getAjoutArticleTaxe(ArticleTaxe a)
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

        public static bool getUpdateArticleTaxe(ArticleTaxe a)
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

        public static bool getDeleteArticleTaxe(long id)
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

        public static List<ArticleTaxe> getListArticleTaxe(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<ArticleTaxe> l = new List<ArticleTaxe>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        ArticleTaxe a = new ArticleTaxe();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Actif = (Boolean)((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"] : false) : false);
                        a.Article = (lect["article_categorie"] != null
                            ? (!lect["article_categorie"].ToString().Trim().Equals("")
                            ? new ArticleComptable(Convert.ToInt64(lect["article_categorie"].ToString()))
                            : new ArticleComptable())
                            : new ArticleComptable());
                        a.Taxe = (lect["taxe"] != null
                            ? (!lect["taxe"].ToString().Trim().Equals("")
                            ? BLL.TaxeBll.One(Convert.ToInt64(lect["taxe"].ToString()))
                            : new Taxe())
                            : new Taxe());
                        a.AppRemise = (Boolean)((lect["app_remise"] != null) ? (!lect["app_remise"].ToString().Trim().Equals("") ? lect["app_remise"] : false) : false);
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
