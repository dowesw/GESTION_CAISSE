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
                            for (int i = 0; i < (modele.Taille - Convert.ToString(num + 1).Length); i++)
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

        public static void MontantTotalDoc(Facture doc)
        {
            doc.MontantHT = 0;
            doc.MontantTTC = 0;
            doc.MontantTaxe = 0;
            doc.MontantRemise = 0;
            doc.MontantRistourne = 0;
            doc.MontantCommission = 0;

            foreach (Contenu c in doc.Contenus)
            {
                if (c.PrixTotal == 0)
                {
                    c.PrixTotal = (c.Quantite * c.Prix);
                }
                TotalTaxeContenuDoc(doc, c);
                TotalRRRContenuDoc(doc, c);

                doc.MontantRemise = (doc.MontantRemise + c.RemiseArt + c.RemiseCat);
                doc.MontantRistourne = (doc.MontantRistourne + c.Ristourne);
                doc.MontantCommission = (doc.MontantCommission + c.Commission);
                doc.MontantHT = (doc.MontantHT + c.PrixTotal);
                doc.MontantTaxe = (doc.MontantTaxe + c.PrixTaxe);
            }
            doc.MontantTTC = (doc.MontantHT + doc.MontantTaxe - doc.MontantRemise);
            TotalRRRDoc(doc);
            doc.MontantReste = (doc.MontantTTC - doc.MontantAvance);
        }

        public static void TotalRRRDoc(Facture doc)
        {
            if (doc.Remises != null)
            {
                foreach (RemiseFacture r in doc.Remises)
                {
                    if (r.Remise != null)
                    {
                        double mtant = doc.MontantTTC;
                        TotalRemiseDoc(r, doc);
                        doc.MontantTTC = mtant - r.Montant;
                    }
                }
            }
        }

        private static void TotalRemiseDoc(RemiseFacture r, Facture doc)
        {
            double qte = 0;
            foreach (Contenu c in doc.Contenus)
            {
                qte += c.Quantite;
            }
            Remise r_ = r.Remise;
            double remise = MontantRemise(r.Remise, qte, doc.MontantTTC);
            r.Montant = remise;
            doc.MontantRemise += remise;
        }


        public static void TotalTaxeContenuDoc(Facture doc, Contenu cont)
        {
            double taux = 0;
            double s = cont.PrixTotal;
            double r = cont.RemiseArt + cont.RemiseCat;

            CategorieComptable c = doc.Categorie;
            if (c != null)
            {
                foreach (ArticleComptable a in c.Articles)
                {
                    if (a.Article.Equals(cont.Article.Article) && a.Actif)
                    {
                        foreach (ArticleTaxe t in a.Articles)
                        {
                            taux += (s * (t.Taxe.Taux / 100));
                            if (t.AppRemise)
                            {
                                taux += (r * (t.Taxe.Taux / 100));
                            }
                        }
                    }
                }
            }
            cont.PrixTaxe = taux;
            doc.MontantTaxe += taux;
        }

        public static void TotalRRRContenuDoc(Facture d, Contenu c)
        {
            if ((d != null) ? d.Client != null : false)
            {
                TotalRemiseContenuDoc(c, d.Client.CategorieClt);
            }
        }

        public static void TotalRemiseContenuDoc(Contenu c, CategorieClient ca)
        {
            if ((ca != null) ? c != null : false)
            {
                ArticleCom a = c.Article;
                if (a != null)
                {
                    //Gestion Remise Sur l'article par le plan tarifaire
                    Article a_ = a.Article;
                    if ((a_ != null) ? ((a_.Plans != null) ? a_.Plans.Count > 0 : false) : false)
                    {
                        PlanTarifaire p = a_.Plans[0];
                        c.Prix = p.Puv;
                        c.RemiseArt = MontantRemise(p.Remise_, c.Quantite, c.PrixTotal);
                    }

                    //Gestion Remise Sur l'article par le plan de remise
                    foreach (PlanRemise p in ca.Remises)
                    {
                        if (p.Article.Equals(a))
                        {
                            c.RemiseCat = MontantRemise(p.Remise, c.Quantite, c.PrixTotal);
                            break;
                        }
                    }
                }
            }
        }

        private static double MontantRemise(Remise r, double quantite, double montant)
        {
            double remise = 0;
            if (r != null)
            {
                switch (r.BaseRemise)
                {
                    case Constantes.BASE_CA:
                        foreach (GrilleRabais g in r.Grilles)
                        {
                            if (g.Maximal >= montant && montant >= g.Minimal)
                            {
                                switch (g.Nature)
                                {
                                    case Constantes.NATURE_MTANT:
                                        remise = g.Montant;
                                        break;
                                    case Constantes.NATURE_TAUX:
                                        remise = (montant * g.Montant) / 100;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            }
                        }
                        break;
                    case Constantes.BASE_QTE:
                        foreach (GrilleRabais g in r.Grilles)
                        {
                            if (g.Maximal >= quantite && quantite >= g.Minimal)
                            {
                                switch (g.Nature)
                                {
                                    case Constantes.NATURE_MTANT:
                                        remise = g.Montant;
                                        break;
                                    case Constantes.NATURE_TAUX:
                                        remise = (montant * g.Montant) / 100;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            }
                        }
                        break;
                    default:
                        remise = 0;
                        break;
                }
            }
            return remise;
        }

        public static int GetRowData(DataGridView data, long id)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i].Cells[0].Value != null)
                {
                    long l = (Int64)data.Rows[i].Cells[0].Value;
                    if (l.Equals(id))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static void SetEnteteOfDay(DateTime date)
        {
            ENTITE.Entete e = BLL.EnteteBll.One(TOOLS.Constantes.Creneau, date);
            if ((e != null) ? e.Id > 0 : false)
            {
                TOOLS.Constantes.Entete = e;
            }
            else
            {
                e = new BLL.EnteteBll(e).Insert();
                if ((e != null) ? e.Id > 0 : false)
                {
                    TOOLS.Constantes.Entete = e;
                }
            }
        }

    }
}
