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
    class PieceCaisseDao
    {
        public static PieceCaisse getOnePieceCaisse(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_base_piece_tresorerie where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                PieceCaisse a = new PieceCaisse();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Description = lect["description"].ToString();
                        a.Libelle = lect["libelle"].ToString();
                        a.Montant = (Double)((lect["montant"] != null) ? ((!lect["montant"].ToString().Trim().Equals("")) ? lect["montant"] : 0) : 0);
                        a.IdExterne = (Int64)((lect["id_externe"] != null) ? ((!lect["id_externe"].ToString().Trim().Equals("")) ? lect["id_externe"] : 0) : 0);
                        a.DatePiece = (DateTime)((lect["date_piece"] != null) ? ((!lect["date_piece"].ToString().Trim().Equals("")) ? lect["date_piece"] : DateTime.Now) : DateTime.Now);
                        a.Mouvement = lect["mouvement"].ToString();
                        a.NumPiece = lect["num_piece"].ToString();
                        a.NumRef = lect["num_ref"].ToString();
                        a.Statut = lect["statut"].ToString();
                        a.TableEterne = lect["table_externe"].ToString();
                        a.Mode = (lect["mode_paiement"] != null
                            ? (!lect["mode_paiement"].ToString().Trim().Equals("")
                            ? BLL.ModePaiementBll.One(Convert.ToInt64(lect["mode_paiement"].ToString()))
                            : new ModePaiement())
                            : new ModePaiement());
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
                String search = "select id from yvs_base_piece_tresorerie order by id desc limit 1";
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

        public static PieceCaisse getAjoutPieceCaisse(PieceCaisse a)
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

        public static bool getUpdatePieceCaisse(PieceCaisse a)
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

        public static bool getDeletePieceCaisse(long id)
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

        public static List<PieceCaisse> getListPieceCaisse(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<PieceCaisse> l = new List<PieceCaisse>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        PieceCaisse a = new PieceCaisse();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Description = lect["description"].ToString();
                        a.Libelle = lect["libelle"].ToString();
                        a.Montant = (Double)((lect["montant"] != null) ? ((!lect["montant"].ToString().Trim().Equals("")) ? lect["montant"] : 0) : 0);
                        a.IdExterne = (Int64)((lect["id_externe"] != null) ? ((!lect["id_externe"].ToString().Trim().Equals("")) ? lect["id_externe"] : 0) : 0);
                        a.DatePiece = (DateTime)((lect["date_piece"] != null) ? ((!lect["date_piece"].ToString().Trim().Equals("")) ? lect["date_piece"] : DateTime.Now) : DateTime.Now);
                        a.Mouvement = lect["mouvement"].ToString();
                        a.NumPiece = lect["num_piece"].ToString();
                        a.NumRef = lect["num_ref"].ToString();
                        a.Statut = lect["statut"].ToString();
                        a.TableEterne = lect["table_externe"].ToString();
                        a.Mode = (lect["mode_paiement"] != null
                            ? (!lect["mode_paiement"].ToString().Trim().Equals("")
                            ? BLL.ModePaiementBll.One(Convert.ToInt64(lect["mode_paiement"].ToString()))
                            : new ModePaiement())
                            : new ModePaiement());
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
