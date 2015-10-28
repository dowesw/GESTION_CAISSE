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
    class FactureDao
    {
        public static Facture getOneFacture(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_doc_ventes where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Facture a = new Facture();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Solde = Convert.ToBoolean((lect["solde"] != null) ? (!lect["solde"].ToString().Trim().Equals("") ? lect["solde"].ToString().Trim() : "false") : "false");
                        a.Categorie = (lect["categorie_comptable"] != null
                            ? (!lect["categorie_comptable"].ToString().Trim().Equals("")
                            ? BLL.CategorieComptableBll.One(Convert.ToInt64(lect["categorie_comptable"].ToString()))
                            : new CategorieComptable())
                            : new CategorieComptable());
                        a.Client = (lect["client"] != null
                            ? (!lect["client"].ToString().Trim().Equals("")
                            ? BLL.ClientBll.One(Convert.ToInt64(lect["client"].ToString()))
                            : new Client())
                            : new Client());
                        a.HeureDoc = Convert.ToDateTime((lect["heure_doc"] != null) ? (!lect["heure_doc"].ToString().Trim().Equals("") ? lect["heure_doc"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.NumDoc = lect["num_doc"].ToString();
                        a.NumPiece = lect["num_piece"].ToString();
                        a.Statut = lect["statut"].ToString();
                        a.MontantAvance = (Double)((lect["montant_avance"] != null) ? ((!lect["montant_avance"].ToString().Trim().Equals("")) ? lect["montant_avance"] : 0) : 0);
                        a.Contenus = BLL.ContenuBll.Liste("select * from yvs_com_contenu_doc_vente where doc_vente = " + a.Id);
                        a.Remises = BLL.RemiseFactureBll.Liste("select * from yvs_com_remise_doc_vente where doc_vente = " + a.Id);
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

        public static Facture getOneFacture(String reference)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_doc_ventes where num_piece = '" + reference + "' or num_doc = '" + reference + "'";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Facture a = new Facture();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Solde = Convert.ToBoolean((lect["solde"] != null) ? (!lect["solde"].ToString().Trim().Equals("") ? lect["solde"].ToString().Trim() : "false") : "false");
                        a.Categorie = (lect["categorie_comptable"] != null
                            ? (!lect["categorie_comptable"].ToString().Trim().Equals("")
                            ? BLL.CategorieComptableBll.One(Convert.ToInt64(lect["categorie_comptable"].ToString()))
                            : new CategorieComptable())
                            : new CategorieComptable());
                        a.Client = (lect["client"] != null
                            ? (!lect["client"].ToString().Trim().Equals("")
                            ? BLL.ClientBll.One(Convert.ToInt64(lect["client"].ToString()))
                            : new Client())
                            : new Client());
                        a.HeureDoc = Convert.ToDateTime((lect["heure_doc"] != null) ? (!lect["heure_doc"].ToString().Trim().Equals("") ? lect["heure_doc"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.NumDoc = lect["num_doc"].ToString();
                        a.NumPiece = lect["num_piece"].ToString();
                        a.Statut = lect["statut"].ToString();
                        a.MontantAvance = (Double)((lect["montant_avance"] != null) ? ((!lect["montant_avance"].ToString().Trim().Equals("")) ? lect["montant_avance"] : 0) : 0);
                        a.Contenus = BLL.ContenuBll.Liste("select * from yvs_com_contenu_doc_vente where doc_vente = " + a.Id);
                        a.Remises = BLL.RemiseFactureBll.Liste("select * from yvs_com_remise_doc_vente where doc_vente = " + a.Id);
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

        public static Facture getOneFacture_(String reference)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_doc_ventes where num_doc like '" + reference + "' order by num_doc desc limit 1";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Facture a = new Facture();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Solde = Convert.ToBoolean((lect["solde"] != null) ? (!lect["solde"].ToString().Trim().Equals("") ? lect["solde"].ToString().Trim() : "false") : "false");
                        a.Categorie = (lect["categorie_comptable"] != null
                            ? (!lect["categorie_comptable"].ToString().Trim().Equals("")
                            ? BLL.CategorieComptableBll.One(Convert.ToInt64(lect["categorie_comptable"].ToString()))
                            : new CategorieComptable())
                            : new CategorieComptable());
                        a.Client = (lect["client"] != null
                            ? (!lect["client"].ToString().Trim().Equals("")
                            ? BLL.ClientBll.One(Convert.ToInt64(lect["client"].ToString()))
                            : new Client())
                            : new Client());
                        a.HeureDoc = Convert.ToDateTime((lect["heure_doc"] != null) ? (!lect["heure_doc"].ToString().Trim().Equals("") ? lect["heure_doc"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.NumDoc = lect["num_doc"].ToString();
                        a.NumPiece = lect["num_piece"].ToString();
                        a.Statut = lect["statut"].ToString();
                        a.MontantAvance = (Double)((lect["montant_avance"] != null) ? ((!lect["montant_avance"].ToString().Trim().Equals("")) ? lect["montant_avance"] : 0) : 0);
                        a.Contenus = BLL.ContenuBll.Liste("select * from yvs_com_contenu_doc_vente where doc_vente = " + a.Id);
                        a.Remises = BLL.RemiseFactureBll.Liste("select * from yvs_com_remise_doc_vente where doc_vente = " + a.Id);
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
                String search = "select id from yvs_com_doc_ventes order by id desc limit 1";
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

        public static Facture getAjoutFacture(Facture a)
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

        public static bool getUpdateFacture(Facture a)
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

        public static bool getDeleteFacture(long id)
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

        public static List<Facture> getListFacture(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Facture> l = new List<Facture>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Facture a = new Facture();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Solde = Convert.ToBoolean((lect["solde"] != null) ? (!lect["solde"].ToString().Trim().Equals("") ? lect["solde"].ToString().Trim() : "false") : "false");
                        a.Categorie = (lect["categorie_comptable"] != null
                             ? (!lect["categorie_comptable"].ToString().Trim().Equals("")
                             ? BLL.CategorieComptableBll.One(Convert.ToInt64(lect["categorie_comptable"].ToString()))
                             : new CategorieComptable())
                             : new CategorieComptable());
                        a.Client = (lect["client"] != null
                            ? (!lect["client"].ToString().Trim().Equals("")
                            ? BLL.ClientBll.One(Convert.ToInt64(lect["client"].ToString()))
                            : new Client())
                            : new Client());
                        a.HeureDoc = Convert.ToDateTime((lect["heure_doc"] != null) ? (!lect["heure_doc"].ToString().Trim().Equals("") ? lect["heure_doc"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.NumDoc = lect["num_doc"].ToString();
                        a.NumPiece = lect["num_piece"].ToString();
                        a.Statut = lect["statut"].ToString();
                        a.MontantAvance = (Double)((lect["montant_avance"] != null) ? ((!lect["montant_avance"].ToString().Trim().Equals("")) ? lect["montant_avance"] : 0) : 0);
                        a.Contenus = BLL.ContenuBll.Liste("select * from yvs_com_contenu_doc_vente where doc_vente = " + a.Id);
                        a.Remises = BLL.RemiseFactureBll.Liste("select * from yvs_com_remise_doc_vente where doc_vente = " + a.Id);
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
