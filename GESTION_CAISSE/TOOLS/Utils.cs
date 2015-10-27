using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace GESTION_CAISSE.TOOLS
{
    class Utils
    {

        static public Form Form_Open = null;

        static public string[] MOIS = new string[] { "Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre" };


        public static string jourSemaine(DateTime date){
            string jour = date.ToString("dddd", new CultureInfo("fr-FR").DateTimeFormat);            
            return jour;
        }

        public delegate void delegateUpdateListBox(string text);

        public static void Log(string logMessage)
        {
            string file = Chemins.getCheminParametre() + "Log.txt";
            if (!File.Exists(file))
                File.Create(file);
            using (StreamWriter log = File.AppendText(file))
            {
                WriteLog(logMessage, log);
            }
        }

        public static void WriteLog(string logMessage, TextWriter log)
        {
            log.Write("\r\nLog Entry : ");
            log.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            log.WriteLine("  :");
            log.WriteLine("  :{0}", logMessage);
            log.WriteLine("-------------------------------");
        }

        public static List<List<string>> DumpLog()
        {
            List<List<string>> list = new List<List<string>>();
            string file = Chemins.getCheminParametre() + "Log.txt";
            if (File.Exists(file))
            {
                using (StreamReader r = File.OpenText(file))
                {
                    list.Add(ReadLog(r));
                }
            }
            return list;
        }

        public static List<string> ReadLog(StreamReader log)
        {
            List<string> list = new List<string>();
            string line;
            while ((line = log.ReadLine()) != null)
            {
                list.Add(line);
            }
            return list;
        }

        public static byte[] convertStringToByte(string text)
        {
            String[] tempAry = text.Split('-');
            byte[] decBytes2 = new byte[tempAry.Length];
            for (int i = 0; i < tempAry.Length; i++)
                decBytes2[i] = Convert.ToByte(tempAry[i], 16);
            return decBytes2;
        }
    }
}
