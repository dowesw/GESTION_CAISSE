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
    class ContenuDao
    {
        public static Contenu getOneContenu(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_contenu_doc_vente where id = " + id;
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Contenu a = new Contenu();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Commission = (Double)((lect["comission"] != null) ? (!lect["comission"].ToString().Trim().Equals("") ? lect["comission"] : 0.0) : 0.0);
                        a.Prix = (Double)((lect["prix"] != null) ? (!lect["prix"].ToString().Trim().Equals("") ? lect["prix"] : 0.0) : 0.0);
                        a.Quantite = (Double)((lect["quantite"] != null) ? (!lect["quantite"].ToString().Trim().Equals("") ? lect["quantite"] : 0.0) : 0.0);
                        a.PrixTotal = a.Prix * a.Quantite;
                        a.RemiseArt = (Double)((lect["remise_art"] != null) ? (!lect["remise_art"].ToString().Trim().Equals("") ? lect["remise_art"] : 0.0) : 0.0);
                        a.RemiseCat = (Double)((lect["remise_cat"] != null) ? (!lect["remise_cat"].ToString().Trim().Equals("") ? lect["remise_cat"] : 0.0) : 0.0);
                        a.Remise = a.RemiseCat + a.RemiseArt;
                        a.Ristourne = (Double)((lect["ristourne"] != null) ? (!lect["ristourne"].ToString().Trim().Equals("") ? lect["ristourne"] : 0.0) : 0.0);
                        a.DateContenu = (DateTime)((lect["date_contenu"] != null) ? (!lect["date_contenu"].ToString().Trim().Equals("") ? lect["date_contenu"] : DateTime.Now) : DateTime.Now);
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
                String search = "select c.id as id from yvs_com_contenu_doc_vente c inner join yvs_com_doc_ventes d on c.doc_vente = d.id where d.entete_doc = " + Constantes.Entete.Id + " order by id desc limit 1"; ;
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

        public static Contenu getAjoutContenu(Contenu a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string insert = "insert into yvs_com_contenu_doc_vente"
                    + "(article, doc_vente, quantite, prix, remise_art, remise_cat, ristourne, comission, supp, actif, date_contenu, date_save)"
                    + " values (" + a.Article.Id + ", " + a.Facture.Id + ", " + a.Quantite + ", " + a.Prix + ", " + a.RemiseArt + ", " + a.RemiseCat + ", "
                    + a.Ristourne + ", " + a.Commission + ", false, true, '" + a.DateContenu + "', '" + DateTime.Now + "')";
                NpgsqlCommand cmd = new NpgsqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                a.Id = getCurrent();
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

        public static bool getUpdateContenu(Contenu a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string update = "update yvs_com_contenu_doc_vente set "
                    + " article=" + a.Article.Id + ", doc_vente=" + a.Facture.Id + ", quantite=" + a.Quantite + ", prix=" + a.Prix + ","
                    + " remise_art=" + a.RemiseArt + ", remise_cat=" + a.RemiseCat + ", ristourne=" + a.Ristourne + ", comission=" + a.Commission + ","
                    + " date_contenu='" + a.DateContenu + "', date_save='" + DateTime.Now + "'"
                    + " where id = " + a.Id;
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

        public static bool getDeleteContenu(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string delete = "delete from yvs_com_contenu_doc_vente where id = " + id;
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

        public static List<Contenu> getListContenu(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Contenu> l = new List<Contenu>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Contenu a = new Contenu();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Commission = (Double)((lect["comission"] != null) ? (!lect["comission"].ToString().Trim().Equals("") ? lect["comission"] : 0.0) : 0.0);
                        a.Prix = (Double)((lect["prix"] != null) ? (!lect["prix"].ToString().Trim().Equals("") ? lect["prix"] : 0.0) : 0.0);
                        a.Quantite = (Double)((lect["quantite"] != null) ? (!lect["quantite"].ToString().Trim().Equals("") ? lect["quantite"] : 0.0) : 0.0);
                        a.PrixTotal = a.Prix * a.Quantite;
                        a.RemiseArt = (Double)((lect["remise_art"] != null) ? (!lect["remise_art"].ToString().Trim().Equals("") ? lect["remise_art"] : 0.0) : 0.0);
                        a.RemiseCat = (Double)((lect["remise_cat"] != null) ? (!lect["remise_cat"].ToString().Trim().Equals("") ? lect["remise_cat"] : 0.0) : 0.0);
                        a.Remise = a.RemiseCat + a.RemiseArt;
                        a.Ristourne = (Double)((lect["ristourne"] != null) ? (!lect["ristourne"].ToString().Trim().Equals("") ? lect["ristourne"] : 0.0) : 0.0);
                        a.DateContenu = (DateTime)((lect["date_contenu"] != null) ? (!lect["date_contenu"].ToString().Trim().Equals("") ? lect["date_contenu"] : DateTime.Now) : DateTime.Now);
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
