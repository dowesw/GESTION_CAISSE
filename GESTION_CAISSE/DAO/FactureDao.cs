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
                String search = "select * from yvs_com_doc_ventes where id = " + id;
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Facture a = new Facture();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Solde = Convert.ToBoolean((lect["solde"] != null) ? (!lect["solde"].ToString().Trim().Equals("") ? lect["solde"].ToString().Trim() : "false") : "false");
                        a.Supp = (Boolean)((lect["supp"] != null) ? (!lect["supp"].ToString().Trim().Equals("") ? lect["supp"] : false) : false);
                        a.Impression = (Int32)((lect["impression"] != null) ? (!lect["impression"].ToString().Trim().Equals("") ? lect["impression"] : 0) : 0);
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
                        a.TypeDoc = lect["type_doc"].ToString();
                        a.Statut = lect["statut"].ToString();
                        a.MontantAvance = (Double)((lect["montant_avance"] != null) ? ((!lect["montant_avance"].ToString().Trim().Equals("")) ? lect["montant_avance"] : 0) : 0);
                        a.Contenus = BLL.ContenuBll.Liste("select * from yvs_com_contenu_doc_vente where doc_vente = " + a.Id);
                        a.Remises = BLL.RemiseFactureBll.Liste("select * from yvs_com_remise_doc_vente where doc_vente = " + a.Id);
                        a.Mensualites = BLL.MensualiteBll.Liste("select * from yvs_com_mensualite_facture_vente where facture = " + a.Id + " order by date_reglement");
                        double mtant = 0;
                        foreach (Mensualite m in a.Mensualites)
                        {
                            mtant += m.MontantVerse;
                            foreach (PieceCaisse p in m.Reglements)
                            {
                                a.Reglements.Add(p);
                            }
                        }
                        if (mtant > a.MontantAvance)
                        {
                            a.MontantAvance = mtant;
                        }
                        Utils.MontantTotalDoc(a);
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
                        a.Supp = (Boolean)((lect["supp"] != null) ? (!lect["supp"].ToString().Trim().Equals("") ? lect["supp"] : false) : false);
                        a.Impression = (Int32)((lect["impression"] != null) ? (!lect["impression"].ToString().Trim().Equals("") ? lect["impression"] : 0) : 0);
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
                        a.TypeDoc = lect["type_doc"].ToString();
                        a.Statut = lect["statut"].ToString();
                        a.MontantAvance = (Double)((lect["montant_avance"] != null) ? ((!lect["montant_avance"].ToString().Trim().Equals("")) ? lect["montant_avance"] : 0) : 0);
                        a.Contenus = BLL.ContenuBll.Liste("select * from yvs_com_contenu_doc_vente where doc_vente = " + a.Id);
                        a.Remises = BLL.RemiseFactureBll.Liste("select * from yvs_com_remise_doc_vente where doc_vente = " + a.Id);
                        a.Mensualites = BLL.MensualiteBll.Liste("select * from yvs_com_mensualite_facture_vente where facture = " + a.Id + " order by date_reglement");
                        double mtant = 0;
                        foreach (Mensualite m in a.Mensualites)
                        {
                            mtant += m.MontantVerse;
                            foreach (PieceCaisse p in m.Reglements)
                            {
                                a.Reglements.Add(p);
                            }
                        }
                        if (mtant > a.MontantAvance)
                        {
                            a.MontantAvance = mtant;
                        }
                        Utils.MontantTotalDoc(a);
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
                        a.Supp = (Boolean)((lect["supp"] != null) ? (!lect["supp"].ToString().Trim().Equals("") ? lect["supp"] : false) : false);
                        var t = lect["impression"];
                        a.Impression = (Int32)((lect["impression"] != null) ? (!lect["impression"].ToString().Trim().Equals("") ? lect["impression"] : 0) : 0);
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
                        a.TypeDoc = lect["type_doc"].ToString();
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
                String search = "select id from yvs_com_doc_ventes where entete_doc = " + Constantes.Entete.Id + " order by id desc limit 1";
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
                string insert = "insert into yvs_com_doc_ventes"
                        + "(num_piece, type_doc, statut, client,  supp, actif, "
                        + "num_doc, entete_doc, heure_doc, montant_avance, solde, date_save, mouv_stock)"
                        + "values ('" + a.NumPiece + "', '" + a.TypeDoc + "', '" + a.Statut + "', " + a.Client.Id + ",  false, true, "
                        + "'" + a.NumDoc + "', " + a.Entete.Id + ", '" + a.HeureDoc.ToString("T") + "', " + a.MontantAvance + ", " + a.Solde + ", '" + DateTime.Now + "', " + a.MouvStock + ")"; ;
                if ((a.Categorie != null) ? a.Categorie.Id > 0 : false)
                {
                    insert = "insert into yvs_com_doc_ventes"
                        + "(num_piece, type_doc, statut, client, categorie_comptable, supp, actif, "
                        + "num_doc, entete_doc, heure_doc, montant_avance, solde, date_save, mouv_stock)"
                        + "values ('" + a.NumPiece + "', '" + a.TypeDoc + "', '" + a.Statut + "', " + a.Client.Id + ", " + a.Categorie.Id + ", false, true, "
                        + "'" + a.NumDoc + "', " + a.Entete.Id + ", '" + a.HeureDoc.ToString("T") + "', " + a.MontantAvance + ", " + a.Solde + ", '" + DateTime.Now + "', " + a.MouvStock + ")";
                }
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

        public static bool getUpdateFacture(Facture a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string update = "update yvs_com_doc_ventes set "
                    + " num_piece = '" + a.NumPiece + "', type_doc = '" + a.TypeDoc + "', statut = '" + a.Statut + "', client = " + a.Client.Id + ","
                    + " num_doc = '" + a.NumDoc + "', entete_doc = " + a.Entete.Id + ", heure_doc = '" + a.HeureDoc.ToString("T") + "',"
                    + " montant_avance = " + a.MontantAvance + ", solde = " + a.Solde + ", date_save = '" + DateTime.Now + "', mouv_stock = " + a.MouvStock + ""
                    + " where id = " + a.Id;
                if ((a.Categorie != null) ? a.Categorie.Id > 0 : false)
                {
                    update = "update yvs_com_doc_ventes set "
                        + " num_piece = '" + a.NumPiece + "', type_doc = '" + a.TypeDoc + "', statut = '" + a.Statut + "', client = " + a.Client.Id + ","
                        + " categorie_comptable = " + a.Categorie.Id + ", num_doc = '" + a.NumDoc + "', entete_doc = " + a.Entete.Id + ", heure_doc = '" + a.HeureDoc.ToString("T") + "',"
                        + " montant_avance = " + a.MontantAvance + ", solde = " + a.Solde + ", date_save = '" + DateTime.Now + "', mouv_stock = " + a.MouvStock + ""
                        + " where id = " + a.Id;
                }
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
                string delete = "delete from yvs_com_doc_ventes where id = " + id;
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

        public static bool getChangeSuppFacture(long id, bool supp)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string delete = "update yvs_com_doc_ventes set supp = " + supp + " where id = " + id;
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

        public static bool getChangeEtatFacture(Facture a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string delete = "update yvs_com_doc_ventes set statut = '" + a.Statut + "' where id = " + a.Id;
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

        public static bool getChangeEtatFacture(long id, String etat)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string delete = "update yvs_com_doc_ventes set statut = '" + etat + "' where id = " + id;
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

        public static bool getChangeImpressionFacture(Facture a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string delete = "update yvs_com_doc_ventes set impression = " + a.Impression + " where id = " + a.Id;
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
                        a.Supp = (Boolean)((lect["supp"] != null) ? (!lect["supp"].ToString().Trim().Equals("") ? lect["supp"] : false) : false);
                        a.Impression = (Int32)((lect["impression"] != null) ? (!lect["impression"].ToString().Trim().Equals("") ? lect["impression"] : 0) : 0);
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
                        a.TypeDoc = lect["type_doc"].ToString();
                        a.Statut = lect["statut"].ToString();
                        a.MontantAvance = (Double)((lect["montant_avance"] != null) ? ((!lect["montant_avance"].ToString().Trim().Equals("")) ? lect["montant_avance"] : 0) : 0);
                        a.Contenus = BLL.ContenuBll.Liste("select * from yvs_com_contenu_doc_vente where doc_vente = " + a.Id);
                        a.Remises = BLL.RemiseFactureBll.Liste("select * from yvs_com_remise_doc_vente where doc_vente = " + a.Id);
                        a.Mensualites = BLL.MensualiteBll.Liste("select * from yvs_com_mensualite_facture_vente where facture = " + a.Id + " order by date_reglement");
                        double mtant = 0;
                        foreach (Mensualite m in a.Mensualites)
                        {
                            mtant += m.MontantVerse;
                            foreach (PieceCaisse p in m.Reglements)
                            {
                                a.Reglements.Add(p);
                            }
                        }
                        if (mtant > a.MontantAvance)
                        {
                            a.MontantAvance = mtant;
                        }
                        Utils.MontantTotalDoc(a);
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
