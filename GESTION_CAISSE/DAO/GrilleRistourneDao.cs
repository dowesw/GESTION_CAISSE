﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.TOOLS;

namespace GESTION_CAISSE.DAO
{
    class GrilleRistourneDao
    {
        public static GrilleRabais getOneGrilleRistourne(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_grille_ristourne where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                GrilleRabais a = new GrilleRabais();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Nature = lect["nature_montant"].ToString();
                        a.Minimal = (Double)((lect["montant_minimal"] != null) ? ((!lect["montant_minimal"].ToString().Trim().Equals("")) ? lect["montant_minimal"] : 0) : 0);
                        a.Maximal = (Double)((lect["montant_maximal"] != null) ? ((!lect["montant_maximal"].ToString().Trim().Equals("")) ? lect["montant_maximal"] : 0) : 0);
                        a.Montant = (Double)((lect["montant_ristourne"] != null) ? ((!lect["montant_ristourne"].ToString().Trim().Equals("")) ? lect["montant_ristourne"] : 0) : 0);
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
                String search = "select id from yvs_com_grille_ristourne order by id desc limit 1";
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

        public static GrilleRabais getAjoutGrilleRistourne(GrilleRabais a)
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

        public static bool getUpdateGrilleRistourne(GrilleRabais a)
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

        public static bool getDeleteGrilleRistourne(long id)
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

        public static List<GrilleRabais> getListGrilleRistourne(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<GrilleRabais> l = new List<GrilleRabais>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        GrilleRabais a = new GrilleRabais();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Nature = lect["nature_montant"].ToString();
                        a.Minimal = (Double)((lect["montant_minimal"] != null) ? ((!lect["montant_minimal"].ToString().Trim().Equals("")) ? lect["montant_minimal"] : 0) : 0);
                        a.Maximal = (Double)((lect["montant_maximal"] != null) ? ((!lect["montant_maximal"].ToString().Trim().Equals("")) ? lect["montant_maximal"] : 0) : 0);
                        a.Montant = (Double)((lect["montant_ristourne"] != null) ? ((!lect["montant_ristourne"].ToString().Trim().Equals("")) ? lect["montant_ristourne"] : 0) : 0);
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
