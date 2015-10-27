using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;
using GESTION_CAISSE.BLL;
using GESTION_CAISSE.TOOLS;

namespace GESTION_CAISSE.DAO
{
    class ConfigurationDAO
    {
        static string chemin = Chemins.getCheminParametre();
        Configuration config = new Configuration();
        static List<Configuration> listConf = new List<Configuration>();

        public static bool getCreateConfiguration(Configuration configuration)
        {
            FileStream ft = new FileStream(chemin + "Configuration.bin", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter ff = new BinaryFormatter();
                listConf.Add(configuration);
                ff.Serialize(ft, listConf);
                ft.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "L'erreur suivante a été rencontrée :");
                return false;
            }
            finally
            {
                ft.Close();
                ft.Dispose();
            }
        }

        public static void getConfigureForm(Form form)
        {
            try
            {
                Configuration config = getReturnConfiguration();
                form.BackColor = Color.FromName(config.getCouleurForm.ToString());

                foreach (Control crtl in form.Controls)
                {
                    if ((crtl.GetType().ToString() == "System.Windows.Forms.TextBox") ||
                        (crtl.GetType().ToString() == "System.Windows.Forms.ComboBox") ||
                        (crtl.GetType().ToString() == "System.Windows.Forms.MaskedTextBox"))
                    {
                        FontFamily Ptextfom = new FontFamily(config.getPoliceEcritText);
                        crtl.Font = new Font((FontFamily)Ptextfom, config.getTaillePoliceEcritText);
                        crtl.ForeColor = Color.FromName(config.getCouleurEcritText.ToString());
                        crtl.BackColor = Color.FromName(config.getCouleurTextbox.ToString());
                    }
                    else if ((crtl.GetType().ToString() == "System.Windows.Forms.Label") ||
                        (crtl.GetType().ToString() == "System.Windows.Forms.GroupBox"))
                    {
                        FontFamily Ptextfom = new FontFamily(config.getPoliceLabel);
                        crtl.Font = new Font((FontFamily)Ptextfom, config.getTaillePoliceLabel);
                        crtl.ForeColor = Color.FromName(config.getCouleurLabel.ToString());
                        if (crtl.GetType().ToString() == "System.Windows.Forms.GroupBox")
                        {
                            foreach (Control elt in crtl.Controls)
                            {
                                if (elt.GetType().ToString() == "System.Windows.Forms.Button")
                                    elt.ForeColor = Color.Black;
                                if (elt.GetType().ToString() == "System.Windows.Forms.GroupBox")
                                    elt.ForeColor = Color.FromName(config.getCouleurLabel.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "L'erreur suivante a été rencontrée :");
            }
        }

        public static Configuration getReturnConfiguration()
        {
            String path = chemin + "Configuration.bin";
            if (File.Exists(path))
            {
                FileStream ft = new FileStream(path, FileMode.Open);
                Configuration info = new Configuration();
                try
                {
                    List<Configuration> listCon = new List<Configuration>();
                    BinaryFormatter ff = new BinaryFormatter();
                    listCon = (List<Configuration>)ff.Deserialize(ft);

                    info.getCouleurLabel = (listCon.FirstOrDefault().getCouleurLabel != null)
                        ? listCon.FirstOrDefault().getCouleurLabel.ToString() : "";
                    info.getCouleurEcritText = (listCon.FirstOrDefault().getCouleurEcritText != null)
                        ? listCon.FirstOrDefault().getCouleurEcritText.ToString() : "";
                    info.getCouleurForm = (listCon.FirstOrDefault().getCouleurForm != null)
                        ? listCon.FirstOrDefault().getCouleurForm.ToString() : "";
                    info.getCouleurTextbox = (listCon.FirstOrDefault().getCouleurTextbox != null)
                        ? listCon.FirstOrDefault().getCouleurTextbox.ToString() : "";
                    info.getPoliceLabel = (listCon.FirstOrDefault().getPoliceLabel != null)
                        ? listCon.FirstOrDefault().getPoliceLabel.ToString() : "";
                    info.getPoliceEcritText = (listCon.FirstOrDefault().getPoliceEcritText != null)
                        ? listCon.FirstOrDefault().getPoliceEcritText.ToString() : "";
                    info.getTaillePoliceLabel = float.Parse((listCon.FirstOrDefault().getTaillePoliceLabel != null)
                    ? listCon.FirstOrDefault().getTaillePoliceLabel.ToString() : "12");
                    info.getTaillePoliceEcritText = float.Parse((listCon.FirstOrDefault().getTaillePoliceEcritText != null)
                        ? listCon.FirstOrDefault().getTaillePoliceEcritText.ToString() : "12");
                    info.getLangue = (listCon.FirstOrDefault().getLangue != null)
                        ? listCon.FirstOrDefault().getLangue.ToString() : "fr";
                    info.getNomTemplate = (listCon.FirstOrDefault().getNomTemplate != null)
                        ? listCon.FirstOrDefault().getNomTemplate.ToString() : "Basique";
                    info.getInstall = (listCon.FirstOrDefault() != null)
                        ? listCon.FirstOrDefault().getInstall : false;
                    info.Update = true;

                    return info;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "L'erreur suivante a été rencontrée :");
                    return new Configuration();
                }
                finally
                {
                    ft.Close();
                    ft.Dispose();
                }
            }
            else
            {
                return new Configuration();
            }
        }

        public static bool getUpdateConfiguration(Configuration configuration)
        {
            try
            {
                if (File.Exists(chemin + "Configuration.bin"))
                    File.Delete(chemin + "Configuration.bin");
                return getCreateConfiguration(configuration);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "L'erreur suivante a été rencontrée :");
                return false;
            }
        }
    }
}
