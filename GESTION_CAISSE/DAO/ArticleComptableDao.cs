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
    class ArticleComptableDao
    {
        public static ArticleComptable getOneArticleComptable(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_base_article_categorie_comptable where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                ArticleComptable a = new ArticleComptable();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Actif = (Boolean)((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"] : false) : false);
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new Article())
                            : new Article());
                        a.Designation = a.Article.Designation;
                        a.RefArt = a.Article.RefArt;
                        a.CodeBarre = a.Article.CodeBarre;
                        a.Compte = (lect["compte"] != null
                            ? (!lect["compte"].ToString().Trim().Equals("")
                            ? BLL.CompteBll.One(Convert.ToInt64(lect["compte"].ToString()))
                            : new Compte())
                            : new Compte());
                        a.Categorie = (lect["categorie"] != null
                            ? (!lect["categorie"].ToString().Trim().Equals("")
                            ? new CategorieComptable(Convert.ToInt64(lect["categorie"].ToString()))
                            : new CategorieComptable())
                            : new CategorieComptable());
                        a.Articles = BLL.ArticleTaxeBll.Liste("select * from yvs_base_article_categorie_comptable_taxe where article_categorie = " + a.Id);
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
                String search = "select id from yvs_base_article_categorie_comptable order by id desc limit 1";
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

        public static ArticleComptable getAjoutArticleComptable(ArticleComptable a)
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

        public static bool getUpdateArticleComptable(ArticleComptable a)
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

        public static bool getDeleteArticleComptable(long id)
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

        public static List<ArticleComptable> getListArticleComptable(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<ArticleComptable> l = new List<ArticleComptable>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        ArticleComptable a = new ArticleComptable();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Actif = (Boolean)((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"] : false) : false);
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new Article())
                            : new Article());
                        a.Designation = a.Article.Designation;
                        a.RefArt = a.Article.RefArt;
                        a.CodeBarre = a.Article.CodeBarre;
                        a.Compte = (lect["compte"] != null
                            ? (!lect["compte"].ToString().Trim().Equals("")
                            ? BLL.CompteBll.One(Convert.ToInt64(lect["compte"].ToString()))
                            : new Compte())
                            : new Compte());
                        a.Categorie = (lect["categorie"] != null
                            ? (!lect["categorie"].ToString().Trim().Equals("")
                            ? new CategorieComptable(Convert.ToInt64(lect["categorie"].ToString()))
                            : new CategorieComptable())
                            : new CategorieComptable());
                        a.Articles = BLL.ArticleTaxeBll.Liste("select * from yvs_base_article_categorie_comptable_taxe where article_categorie = " + a.Id);
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
