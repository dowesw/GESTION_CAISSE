using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.BLL;

namespace GESTION_CAISSE.TOOLS
{
    class Utils
    {

        static public Form Form_Open = null;

        static public string[] MOIS = new string[] { "Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre" };


        public static string jourSemaine(DateTime date)
        {
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

        public static byte[] ConvertStringToByte(string text)
        {
            String[] tempAry = text.Split('-');
            byte[] decBytes2 = new byte[tempAry.Length];
            for (int i = 0; i < tempAry.Length; i++)
                decBytes2[i] = Convert.ToByte(tempAry[i], 16);
            return decBytes2;
        }

        public static double ParsedMaxDouble(String value)
        {
            String d = Double.MaxValue.ToString();
            if (value.Equals(d))
            {
                return Int64.MaxValue;
            }
            return Convert.ToDouble(value);
        }

        public static String GenererReference(String element)
        {
            ModelReference model = SearchModelReference(element);
            if ((model != null) ? model.Id > 0 : false)
            {
                return ReferenceElement(model);
            }
            Messages.ShowErreur("Cet élément n'a pas de modele de reference!");
            return "";
        }

        private static ENTITE.ModelReference SearchModelReference(String designation)
        {
            if (!designation.Trim().Equals(""))
            {
                ENTITE.ElementReference element = BLL.ElementReferenceBll.One(designation);
                if ((element != null) ? element.Id > 0 : false)
                {
                    return BLL.ModelReferenceBll.One(element);
                }
                else
                {
                    TOOLS.Messages.ShowErreur("L'element de reference n'existe pas!");
                }
            }
            else
            {
                TOOLS.Messages.ShowErreur("La designation ne peut pas être vide");
            }
            return null;
        }

        private static String ReferenceElement(ENTITE.ModelReference modele)
        {
            if ((modele != null) ? modele.Id > 0 : false)
            {
                String reference = "";
                String apercu = modele.Prefix + modele.Separateur;
                if (modele.Jour)
                {
                    if ((int)DateTime.Now.Day > 9)
                    {
                        apercu += (int)DateTime.Now.Day;
                    }
                    if ((int)DateTime.Now.Day < 10)
                    {
                        apercu += ("0" + (int)DateTime.Now.Day);
                    }
                }
                if (modele.Mois)
                {
                    if ((int)DateTime.Now.Month > 9)
                    {
                        apercu += (int)DateTime.Now.Month;
                    }
                    if ((int)DateTime.Now.Month < 10)
                    {
                        apercu += ("0" + (int)DateTime.Now.Month);
                    }
                }
                if (modele.Annee)
                {
                    apercu += DateTime.Now.Year.ToString().Substring(2);
                }
                apercu += modele.Separateur;

                switch (modele.Element.Designation)
                {
                    case Constantes.DOC_COMMANDE:
                    case Constantes.DOC_FACTURE:
                        Facture f = FactureBll.One_(apercu + "%");
                        if ((f != null) ? f.Id > 0 : false)
                        {
                            reference = f.NumDoc;
                        }
                        else
                        {
                            reference = "";
                        }
                        break;
                    case Constantes.DOC_PIECE:

                        break;
                    default:
                        return "";
                }

                if (!reference.Trim().Equals(""))
                {
                    String partieNum = reference.Replace(apercu, "");
                    if (apercu.Equals(reference.Replace(partieNum, "")))
                    {
                        int num = Convert.ToInt16(partieNum);
                        if (Convert.ToString(num + 1).Length > modele.Taille)
                        {
                            Messages.ShowErreur("Vous ne pouvez plus ajouter ce type de document");
                            return "";
                        }
                        else
                        {
                            for (int i = 0; i < (modele.Taille - Convert.ToString(num).Length); i++)
                            {
                                apercu += "0";
                            }
                        }
                        apercu += Convert.ToString(Convert.ToInt16(partieNum) + 1);
                    }
                    else
                    {
                        for (int i = 0; i < modele.Taille; i++)
                        {
                            apercu += "0";
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < modele.Taille; i++)
                    {
                        apercu += "0";
                    }
                }

                return apercu;
            }
            else
            {
                TOOLS.Messages.ShowErreur("Le model de reference n'existe pas!");
            }
            return null;
        }

        private void setMontantRemiseDoc(RemiseFacture r, Facture doc)
        {
            double remise = 0, qte = 0, mtant = doc.MontantTTC;
            switch (r.Remise.BaseRemise)
            {
                case Constantes.BASE_CA:
                    foreach (GrilleRabais g in r.Remise.Grilles)
                    {
                        if (g.Maximal >= mtant && mtant >= g.Minimal)
                        {
                            switch (g.Nature)
                            {
                                case Constantes.NATURE_MTANT:
                                    remise = g.Montant;
                                    break;
                                case Constantes.NATURE_TAUX:
                                    remise = (mtant * g.Montant) / 100;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    }
                    break;
                case Constantes.BASE_QTE:
                    foreach (Contenu c in doc.Contenus)
                    {
                        qte += c.Quantite;
                    }
                    foreach (GrilleRabais g in r.Remise.Grilles)
                    {
                        if (g.Maximal >= qte && qte >= g.Minimal)
                        {
                            switch (g.Nature)
                            {
                                case Constantes.NATURE_MTANT:
                                    remise = g.Montant;
                                    break;
                                case Constantes.NATURE_TAUX:
                                    remise = (mtant * g.Montant) / 100;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    }
                    break;
                default:
                    Messages.ShowErreur("Impossible d'attribuer cette remise!");
                    break;
            }
            r.Montant = remise;
        }


    }
}
