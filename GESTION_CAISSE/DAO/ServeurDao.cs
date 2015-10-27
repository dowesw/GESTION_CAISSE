using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.TOOLS;

namespace GESTION_CAISSE.DAO
{
    class ServeurDao
    {
        static string chemin = Chemins.getCheminParametre();
        static List<Serveur> listeServeur = new List<Serveur>();

        public static bool getCreateServeur(Serveur Serveur)
        {
            FileStream ft = new FileStream(chemin + "Serveur.bin", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter ff = new BinaryFormatter();
                listeServeur.Add(Serveur);
                ff.Serialize(ft, listeServeur);
                ft.Close();
                return true;
            }
            catch (Exception e)
            {
                Messages.Exception(e);
                return false;
            }
            finally
            {
                ft.Close();
                ft.Dispose();
            }
        }

        public static Serveur getReturnServeur()
        {
            FileStream ft = null;
            if (!File.Exists(chemin + "Serveur.bin"))
            {
                return new Serveur();
            }
            try
            {
                ft = new FileStream(chemin + "Serveur.bin", FileMode.Open);
                Serveur info = new Serveur();
                List<Serveur> listCon = new List<Serveur>();
                BinaryFormatter ff = new BinaryFormatter();
                listCon = (List<Serveur>)ff.Deserialize(ft);
                foreach (Serveur s in listCon)
                {
                    if (s.getAdresse != null)
                    {
                        info.getAdresse = s.getAdresse.ToString();
                    }
                    if (s.getPort != 0)
                    {
                        info.getPort = Convert.ToInt32(s.getPort.ToString());
                    }
                    if (s.getUser != null)
                    {
                        info.getUser = s.getUser.ToString();
                    }
                    if (s.getPassword != null)
                    {
                        info.getPassword = s.getPassword.ToString();
                    }
                    if (s.getDatabase != null)
                    {
                        info.getDatabase = s.getDatabase;
                    }
                    break;
                }
                return info;
            }
            catch (Exception e)
            {
                Messages.Exception(e);
                return new Serveur();
            }
            finally
            {
                ft.Close();
                ft.Dispose();
            }
        }

        public static bool getUpdateServeur(Serveur Serveur)
        {
            try
            {
                if (File.Exists(chemin + "Serveur.bin"))
                    File.Delete(chemin + "Serveur.bin");
                return getCreateServeur(Serveur);
            }
            catch (Exception e)
            {
                Messages.Exception(e);
                return false;
            }
        }
    }
}
