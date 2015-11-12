using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GESTION_CAISSE.TOOLS
{
    class Chemins
    {
        public static string cheminDefault = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        public static string cheminStart = Application.StartupPath;

        public static string getCheminParametre()
        {
            string chemin = cheminStart + Constantes.FILE_SEPARATOR + "Parametres";
            DirectoryInfo dossier = new DirectoryInfo(chemin);
            if (!dossier.Exists)
                dossier.Create();
            return chemin + Constantes.FILE_SEPARATOR;
        }

        public static string getCheminPhoto()
        {
            string chemin = cheminDefault;
            if ((Constantes.Societe != null) ? Constantes.Societe.Id > 0 : false)
            {
                if ((Constantes.Societe.Designation != null) ? !Constantes.Societe.Designation.Trim().Equals("") : false)
                {
                    chemin += Constantes.FILE_SEPARATOR + Constantes.Societe.Designation;
                }
            }
            chemin += Constantes.FILE_SEPARATOR + "documents" + Constantes.FILE_SEPARATOR + "docUsers";
            DirectoryInfo dossier = new DirectoryInfo(chemin);
            if (!dossier.Exists)
                dossier.Create();
            return chemin + Constantes.FILE_SEPARATOR;
        }

        public static string getCheminArticle()
        {
            string chemin = cheminDefault;
            if ((Constantes.Societe != null) ? Constantes.Societe.Id > 0 : false)
            {
                if ((Constantes.Societe.Designation != null) ? !Constantes.Societe.Designation.Trim().Equals("") : false)
                {
                    chemin += Constantes.FILE_SEPARATOR + Constantes.Societe.Designation;
                }
            }
            chemin += Constantes.FILE_SEPARATOR + "documents" + Constantes.FILE_SEPARATOR + "docArticle";
            DirectoryInfo dossier = new DirectoryInfo(chemin);
            if (!dossier.Exists)
                dossier.Create();
            return chemin + Constantes.FILE_SEPARATOR;
        }
    }
}
