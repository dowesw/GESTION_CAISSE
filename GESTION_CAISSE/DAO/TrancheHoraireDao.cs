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
    class TrancheHoraireDao
    {
        public static TrancheHoraire getOneTrancheHoraire(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_type_creneau_horaire where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                TrancheHoraire a = new TrancheHoraire();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Reference = lect["reference"].ToString();
                        a.Critere = lect["critere"].ToString();
                        a.HeureDebut = Convert.ToDateTime((lect["heure_debut"] != null) ? (!lect["heure_debut"].ToString().Trim().Equals("") ? lect["heure_debut"].ToString().Trim() : "00:00:0000") : "00:00:0000");
                        a.HeureFin = Convert.ToDateTime((lect["heure_fin"] != null) ? (!lect["heure_fin"].ToString().Trim().Equals("") ? lect["heure_fin"].ToString().Trim() : "00:00:0000") : "00:00:0000");
                        a.Actif = Convert.ToBoolean((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
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
                String search = "select id from yvs_com_type_creneau_horaire order by id desc limit 1";
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

        public static TrancheHoraire getAjoutTrancheHoraire(TrancheHoraire a)
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

        public static bool getUpdateTrancheHoraire(TrancheHoraire a)
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

        public static bool getDeleteTrancheHoraire(long id)
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

        public static List<TrancheHoraire> getListTrancheHoraire(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<TrancheHoraire> l = new List<TrancheHoraire>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        TrancheHoraire a = new TrancheHoraire();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Reference = lect["reference"].ToString();
                        a.Critere = lect["critere"].ToString();
                        a.HeureDebut = Convert.ToDateTime((lect["heure_debut"] != null) ? (!lect["heure_debut"].ToString().Trim().Equals("") ? lect["heure_debut"].ToString().Trim() : "00:00:0000") : "00:00:0000");
                        a.HeureFin = Convert.ToDateTime((lect["heure_fin"] != null) ? (!lect["heure_fin"].ToString().Trim().Equals("") ? lect["heure_fin"].ToString().Trim() : "00:00:0000") : "00:00:0000");
                        a.Actif = Convert.ToBoolean((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
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
