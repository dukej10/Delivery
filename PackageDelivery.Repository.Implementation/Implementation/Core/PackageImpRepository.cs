using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class PackageImpRepository : IPackageRepository
    {
        public PackageDbModel createRecord(PackageDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                paquete package = db.paquete.Where(x => x.peso.Equals(record.Weight) && x.altura.Equals(record.Height)
                    && x.ancho.Equals(record.Width) && x.profundidad.Equals(record.Depth)).FirstOrDefault();
                if (package != null)
                {
                    return null;
                }
                oficina ofic = db.oficina.Where(x => x.id == record.IdOffice).FirstOrDefault();
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                paquete paq = mapper.DbModelToDatabaseMapper(record);
                db.paquete.Add(paq);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(paq);
            }
        }

        public bool deleteRecordById(long id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    paquete record = db.paquete.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.paquete.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene el registro por Id
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>null cuando no lo encuentra o el objeto cuando si lo encuentra</returns>
        public PackageDbModel getRecordById(long id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                paquete record = db.paquete.Find(id);
                if (record == null)
                {
                    return null;
                }
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<PackageDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<paquete> list = db.paquete.Where(x => x.peso.ToString().Equals(filter) || x.altura.ToString().Equals(filter) || x.profundidad.ToString().Equals(filter) || x.ancho.ToString().Equals(filter));
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public PackageDbModel updateRecord(PackageDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                paquete ofc = db.paquete.Where(x => x.id == record.Id).FirstOrDefault();
                if (ofc == null)
                {
                    return null;
                }
                else
                {
                    ofc.peso = record.Weight;
                    ofc.altura = record.Height;
                    ofc.profundidad = record.Depth;
                    ofc.ancho = record.Width;
                    ofc.idOficina = record.IdOffice;
                    db.Entry(ofc).State = EntityState.Modified;
                    db.SaveChanges();
                    PackageRepositoryMapper mapper = new PackageRepositoryMapper();

                    return mapper.DatabaseToDbModelMapper(ofc);
                }
            }
        }
    }
}
