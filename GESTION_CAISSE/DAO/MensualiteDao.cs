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
    class MensualiteDao
    {
        public static Mensualite getOneMensualite(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_mensualite_facture_vente where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Mensualite a = new Mensualite();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.DateMensualite = (DateTime)((lect["date_reglement"] != null) ? ((!lect["date_reglement"].ToString().Trim().Equals("")) ? lect["date_reglement"] : DateTime.Now) : DateTime.Now);
                        a.Etat = lect["etat"].ToString();
                        a.Montant = (Double)((lect["montant"] != null) ? ((!lect["montant"].ToString().Trim().Equals("")) ? lect["montant"] : 0) : 0);
                        a.Reglements = BLL.PieceCaisseBll.Liste("setecl * from yvs_base_piece_tresorerie where id_externe = " + a.Id + " and table_externe = '" + Constantes.TABLE_EXTERNE_PIECE + "'");
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
                String search = "select id from yvs_com_mensualite_facture_vente order by id desc limit 1";
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

        public static Mensualite getAjoutMensualite(Mensualite a)
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

        public static bool getUpdateMensualite(Mensualite a)
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

        public static bool getDeleteMensualite(long id)
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

        public static List<Mensualite> getListMensualite(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Mensualite> l = new List<Mensualite>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Mensualite a = new Mensualite();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.DateMensualite = (DateTime)((lect["date_reglement"] != null) ? ((!lect["date_reglement"].ToString().Trim().Equals("")) ? lect["date_reglement"] : DateTime.Now) : DateTime.Now);
                        a.Etat = lect["etat"].ToString();
                        a.Montant = (Double)((lect["montant"] != null) ? ((!lect["montant"].ToString().Trim().Equals("")) ? lect["montant"] : 0) : 0);
                        a.Reglements = BLL.PieceCaisseBll.Liste("setecl * from yvs_base_piece_tresorerie where id_externe = " + a.Id + " and table_externe = '" + Constantes.TABLE_EXTERNE_PIECE + "'");
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
