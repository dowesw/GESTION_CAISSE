using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class ElementReferenceBll
    {
        static ElementReference element;

        internal ElementReference getElementReference
        {
            get { return element; }
            set { element = value; }
        }

        public ElementReferenceBll(ElementReference unElementReference)
        {
            element = unElementReference;
        }

        public static ElementReference One(long id)
        {
            try
            {
                return ElementReferenceDao.getOneElementReference(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static ElementReference One(String designation)
        {
            try
            {
                return ElementReferenceDao.getOneElementReference(designation);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public ElementReference Insert()
        {
            try
            {
                return ElementReferenceDao.getAjoutElementReference(element);
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
                return ElementReferenceDao.getUpdateElementReference(element);
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
                return ElementReferenceDao.getDeleteElementReference(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<ElementReference> Liste(String query)
        {
            try
            {
                return ElementReferenceDao.getListElementReference(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
