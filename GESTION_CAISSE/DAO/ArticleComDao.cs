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
    class ArticleComDao
    {
        public static ArticleCom getOneArticleCom(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_article where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                ArticleCom a = new ArticleCom();
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
                        a.Designation = a.Article.Designation;
                        a.RefArt = a.Article.RefArt;
                        a.CodeBarre = a.Article.CodeBarre;
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

        public static ArticleCom getOneArticleCom(Article article)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_article where article = " + article.Id + " limit 1";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                ArticleCom a = new ArticleCom();
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
                        a.Designation = a.Article.Designation;
                        a.RefArt = a.Article.RefArt;
                        a.CodeBarre = a.Article.CodeBarre;
                    }
                    a.Update = true;
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

        public static ArticleCom getOneArticleCom(ArticleDepot article)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_article where article = " + article.Article.Id + " limit 1";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                ArticleCom a = new ArticleCom();
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
                        a.Designation = a.Article.Designation;
                        a.RefArt = a.Article.RefArt;
                        a.CodeBarre = a.Article.CodeBarre;
                    }
                    a.Update = true;
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
                String search = "select id from yvs_com_article order by id desc limit 1";
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

        public static ArticleCom getAjoutArticleCom(ArticleCom a)
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

        public static bool getUpdateArticleCom(ArticleCom a)
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

        public static bool getDeleteArticleCom(long id)
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

        public static List<ArticleCom> getListArticleCom(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<ArticleCom> l = new List<ArticleCom>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        ArticleCom a = new ArticleCom();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Article = (lect["article"] != null
                            ? (!lect["article"].ToString().Trim().Equals("")
                            ? BLL.ArticleBll.One(Convert.ToInt64(lect["article"].ToString()))
                            : new Article())
                            : new Article());
                        a.Designation = a.Article.Designation;
                        a.RefArt = a.Article.RefArt;
                        a.CodeBarre = a.Article.CodeBarre;
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
