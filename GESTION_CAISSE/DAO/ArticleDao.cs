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
    class ArticleDao
    {
        public static Article getOneArticle(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_articles where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Article a = new Article();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Designation = lect["designation"].ToString();
                        a.CodeBarre = lect["code_barre"].ToString();
                        a.RefArt = lect["ref_art"].ToString();
                        a.Prix = Convert.ToDouble(((lect["puv"] != null) ? ((!lect["puv"].ToString().Trim().Equals("")) ? lect["puv"].ToString() : "0") : "0"));
                        a.Plans = BLL.PlanTarifaireBll.Liste("select * from yvs_base_plan_tarifaire_article where actif = true and article = " + a.Id);

                        String photo = lect["photo_1"].ToString();
                        if ((photo != null) ? !photo.Trim().Equals("") : false)
                        {
                            //a.Photos.Add(photo);
                        }
                        photo = lect["photo_2"].ToString();
                        if ((photo != null) ? !photo.Trim().Equals("") : false)
                        {
                            //a.Photos.Add(photo);
                        }
                        photo = lect["photo_3"].ToString();
                        if ((photo != null) ? !photo.Trim().Equals("") : false)
                        {
                            //a.Photos.Add(photo);
                        }
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
                String search = "select id from yvs_articles order by id desc limit 1";
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

        public static Article getAjoutArticle(Article a)
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

        public static bool getUpdateArticle(Article a)
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

        public static bool getDeleteArticle(long id)
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

        public static List<Article> getListArticle(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Article> l = new List<Article>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Article a = new Article();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Designation = lect["designation"].ToString();
                        a.CodeBarre = lect["code_barre"].ToString();
                        a.RefArt = lect["ref_art"].ToString();
                        a.Prix = Convert.ToDouble(((lect["puv"] != null) ? ((!lect["puv"].ToString().Trim().Equals("")) ? lect["puv"].ToString() : "0") : "0"));
                        a.Plans = BLL.PlanTarifaireBll.Liste("select * from yvs_base_plan_tarifaire_article where actif = true and article = " + a.Id);

                        String photo = lect["photo_1"].ToString();
                        if ((photo != null) ? !photo.Trim().Equals("") : false)
                        {
                            //a.Photos.Add(photo);
                        }
                        photo = lect["photo_2"].ToString();
                        if ((photo != null) ? !photo.Trim().Equals("") : false)
                        {
                            //a.Photos.Add(photo);
                        }
                        photo = lect["photo_3"].ToString();
                        if ((photo != null) ? !photo.Trim().Equals("") : false)
                        {
                            //a.Photos.Add(photo);
                        }

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
