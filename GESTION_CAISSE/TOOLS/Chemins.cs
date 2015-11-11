using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GESTION_CAISSE.TOOLS
{
    class Chemins
    {
        public const string cheminDefault = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        public const string cheminStart = Application.StartupPath;

        public static string getCheminParametre()
        {
            string chemin = cheminStart + Constantes.FILE_SEPARATOR + "Parametres";
            DirectoryInfo dossier = new DirectoryInfo(chemin);
            if (!dossier.Exists)
                dossier.Create();
            return chemin + Constantes.FILE_SEPARATOR;
        }
    }
}
