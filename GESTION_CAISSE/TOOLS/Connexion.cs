using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using GESTION_CAISSE.TOOLS;
using GESTION_CAISSE.BLL;

namespace GESTION_CAISSE.TOOLS
{
    class Connexion
    {

        public static NpgsqlConnection Connection()
        {
            return getConnexion(ServeurBll.ReturnServeur());
        }

        private static NpgsqlConnection getConnexion(ENTITE.Serveur bean)
        {
            try
            {
                if (bean.Control_())
                {
                    NpgsqlConnection con = isConnection(bean);
                    con.Open();
                    return con;
                }
                else
                {
                    if (DialogResult.Retry == Messages.Erreur_Retry("Connexion impossible ! Entrer de nouveaux parametres"))
                    {
                        new IHM.Form_Serveur().Show();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Messages.Exception(ex);
            }
            return null;
        }

        private static NpgsqlConnection isConnection(ENTITE.Serveur bean)
        {
            try
            {
                string constr = "PORT=" + bean.getPort + ";TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;COMPATIBLE= 2.0.14.3;DATABASE=" + bean.getDatabase + ";HOST=" + bean.getAdresse + ";PASSWORD=" + bean.getPassword + ";USER ID=" + bean.getUser + "";
                return new NpgsqlConnection(constr);
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
            return null;
        }

        public static NpgsqlConnection Connection_Test()
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection();
                string constr = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;COMPATIBLE= 2.0.14.3;DATABASE=lymytz_demo_0;HOST=192.168.1.251;PASSWORD=yves1910/;USER ID=postgres";
                con = new NpgsqlConnection(constr);
                con.Open();
                Messages.Succes();
                return con;
            }
            catch (NpgsqlException ex)
            {
                Messages.Exception(ex);
                return null;
            }
        }

        public static void Deconnection(NpgsqlConnection con)
        {
            if (con != null)
            {
                try
                {
                    con.Close();
                    con.Dispose();
                }
                catch (NpgsqlException ex)
                {
                    Messages.Exception(ex);
                }
                finally
                {
                    con = null;
                }
            }
        }
    }
}
