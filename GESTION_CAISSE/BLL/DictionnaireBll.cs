using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class DictionnaireBll
    {
        static Dictionnaire dictionnaire;

        internal Dictionnaire getDictionnaire
        {
            get { return dictionnaire; }
            set { dictionnaire = value; }
        }

        public DictionnaireBll(Dictionnaire unDictionnaire)
        {
            dictionnaire = unDictionnaire;
        }

        public static Dictionnaire One(long id)
        {
            try
            {
                return DictionnaireDao.getOneDictionnaire(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public Dictionnaire Insert()
        {
            try
            {
                return DictionnaireDao.getAjoutDictionnaire(dictionnaire);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'inserer cette enregistrement", ex);
            }

        }

        public bool Update()
        {
            try
            {
                return DictionnaireDao.getUpdateDictionnaire(dictionnaire);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de modifier cette enregistrement", ex);
            }
        }

        public static bool Delete(long id)
        {
            try
            {
                return DictionnaireDao.getDeleteDictionnaire(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<Dictionnaire> Liste(String query)
        {
            try
            {
                return DictionnaireDao.getListDictionnaire(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
