using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.DAO;

namespace GESTION_CAISSE.BLL
{
    class ModelReferenceBll
    {
        static ModelReference model;

        internal ModelReference getModelReference
        {
            get { return model; }
            set { model = value; }
        }

        public ModelReferenceBll(ModelReference unModelReference)
        {
            model = unModelReference;
        }

        public static ModelReference One(long id)
        {
            try
            {
                return ModelReferenceDao.getOneModelReference(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public static ModelReference One(ElementReference element)
        {
            try
            {
                return ModelReferenceDao.getOneModelReference(element);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible d'atteindre l'enregistrement", ex);
            }
        }

        public ModelReference Insert()
        {
            try
            {
                return ModelReferenceDao.getAjoutModelReference(model);
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
                return ModelReferenceDao.getUpdateModelReference(model);
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
                return ModelReferenceDao.getDeleteModelReference(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de supprimer cette enregistrement", ex);
            }
        }

        public static List<ModelReference> Liste(String query)
        {
            try
            {
                return ModelReferenceDao.getListModelReference(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible de retourner la liste des élements", ex);
            }
        }
    }
}
