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
    class CreneauDao
    {
        public static Creneau getOneCreneau(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select c.id as id, c.date_travail as date_travail, c.users as users, c.actif actif, h.depot as depot, h.type as type"
                    + " from yvs_com_creneau_horaire_users c "
                    + " inner join yvs_com_creneau_horaire h on c.creneau = h.id"
                    + " where c.id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Creneau a = new Creneau();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Actif = Convert.ToBoolean((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
                        a.DateTravail = (DateTime)((lect["date_travail"] != null) ? (!lect["date_travail"].ToString().Trim().Equals("") ? lect["date_travail"] : DateTime.Now) : DateTime.Now);
                        a.Personnel = (lect["users"] != null
                            ? (!lect["users"].ToString().Trim().Equals("")
                            ? BLL.PersonnelBll.One(Convert.ToInt64(lect["users"].ToString()))
                            : new Personnel())
                            : new Personnel());
                        a.Depot = (lect["depot"] != null
                            ? (!lect["depot"].ToString().Trim().Equals("")
                            ? BLL.DepotBll.One(Convert.ToInt64(lect["depot"].ToString()))
                            : new Depot())
                            : new Depot());
                        a.Tranche = (lect["type"] != null
                            ? (!lect["type"].ToString().Trim().Equals("")
                            ? BLL.TrancheHoraireBll.One(Convert.ToInt64(lect["type"].ToString()))
                            : new TrancheHoraire())
                            : new TrancheHoraire());
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

        public static Creneau getOneCreneau(Personnel pers)
        {
            return getOneCreneau(pers, DateTime.Now);
        }

        public static Creneau getOneCreneau(Personnel pers, DateTime date)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select c.id as id, c.date_travail as date_travail, c.users as users, c.actif actif, h.depot as depot, h.type as type"
                    + " from yvs_com_creneau_horaire_users c "
                    + " inner join yvs_com_creneau_horaire h on c.creneau = h.id"
                    + " where c.users = " + pers.Id + " and c.date_travail ='" + date + "'";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Creneau a = new Creneau();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Actif = Convert.ToBoolean((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
                        a.DateTravail = (DateTime)((lect["date_travail"] != null) ? (!lect["date_travail"].ToString().Trim().Equals("") ? lect["date_travail"] : DateTime.Now) : DateTime.Now);
                        a.Personnel = (lect["users"] != null
                            ? (!lect["users"].ToString().Trim().Equals("")
                            ? BLL.PersonnelBll.One(Convert.ToInt64(lect["users"].ToString()))
                            : new Personnel())
                            : new Personnel());
                        a.Depot = (lect["depot"] != null
                            ? (!lect["depot"].ToString().Trim().Equals("")
                            ? BLL.DepotBll.One(Convert.ToInt64(lect["depot"].ToString()))
                            : new Depot())
                            : new Depot());
                        a.Tranche = (lect["type"] != null
                            ? (!lect["type"].ToString().Trim().Equals("")
                            ? BLL.TrancheHoraireBll.One(Convert.ToInt64(lect["type"].ToString()))
                            : new TrancheHoraire())
                            : new TrancheHoraire());
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

        public static Creneau getOneCreneau(Personnel pers, DateTime date, DateTime heureDebut, DateTime heureFin)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select c.id as id, c.date_travail as date_travail, c.users as users, c.actif actif, h.depot as depot, h.type as type"
                    + " from yvs_com_creneau_horaire_users c "
                    + " inner join yvs_com_creneau_horaire h on c.creneau = h.id"
                    + " inner join yvs_com_type_creneau_horaire t on h.type = t.id"
                    + " where c.users = " + pers.Id + " and c.date_travail ='" + date + "' and t.heure_debut = '" + heureDebut + "' and t.heure_fin = '" + heureFin + "'";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Creneau a = new Creneau();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Actif = Convert.ToBoolean((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
                        a.DateTravail = (DateTime)((lect["date_travail"] != null) ? (!lect["date_travail"].ToString().Trim().Equals("") ? lect["date_travail"] : DateTime.Now) : DateTime.Now);
                        a.Personnel = (lect["users"] != null
                            ? (!lect["users"].ToString().Trim().Equals("")
                            ? BLL.PersonnelBll.One(Convert.ToInt64(lect["users"].ToString()))
                            : new Personnel())
                            : new Personnel());
                        a.Depot = (lect["depot"] != null
                            ? (!lect["depot"].ToString().Trim().Equals("")
                            ? BLL.DepotBll.One(Convert.ToInt64(lect["depot"].ToString()))
                            : new Depot())
                            : new Depot());
                        a.Tranche = (lect["type"] != null
                            ? (!lect["type"].ToString().Trim().Equals("")
                            ? BLL.TrancheHoraireBll.One(Convert.ToInt64(lect["type"].ToString()))
                            : new TrancheHoraire())
                            : new TrancheHoraire());
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
                String search = "select id from yvs_com_creneau_horaire_users order by id desc limit 1";
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

        public static Creneau getAjoutCreneau(Creneau a)
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

        public static bool getUpdateCreneau(Creneau a)
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

        public static bool getDeleteCreneau(long id)
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

        public static List<Creneau> getListCreneau(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Creneau> l = new List<Creneau>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Creneau a = new Creneau(); 
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Actif = Convert.ToBoolean((lect["actif"] != null) ? (!lect["actif"].ToString().Trim().Equals("") ? lect["actif"].ToString().Trim() : "false") : "false");
                        a.DateTravail = (DateTime)((lect["date_travail"] != null) ? (!lect["date_travail"].ToString().Trim().Equals("") ? lect["date_travail"] : DateTime.Now) : DateTime.Now);
                        a.Personnel = (lect["users"] != null
                            ? (!lect["users"].ToString().Trim().Equals("")
                            ? BLL.PersonnelBll.One(Convert.ToInt64(lect["users"].ToString()))
                            : new Personnel())
                            : new Personnel());
                        a.Depot = (lect["depot"] != null
                            ? (!lect["depot"].ToString().Trim().Equals("")
                            ? BLL.DepotBll.One(Convert.ToInt64(lect["depot"].ToString()))
                            : new Depot())
                            : new Depot());
                        a.Tranche = (lect["type"] != null
                            ? (!lect["type"].ToString().Trim().Equals("")
                            ? BLL.TrancheHoraireBll.One(Convert.ToInt64(lect["type"].ToString()))
                            : new TrancheHoraire())
                            : new TrancheHoraire());
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
