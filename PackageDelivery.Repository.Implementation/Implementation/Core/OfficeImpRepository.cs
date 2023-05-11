using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class OfficeImpRepository : IOfficeRepository
    {
        public OfficeDbModel createRecord(OfficeDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                oficina office = db.oficina.Where(x => x.nombre.ToUpper().Equals(record.Name.ToUpper())).FirstOrDefault();
                if (office != null)
                {
                    return null;
                    //throw new Exception();
                }
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                oficina ofic = mapper.DbModelToDatabaseMapper(record);
                db.oficina.Add(ofic);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(ofic);
            }
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    oficina record = db.oficina.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.oficina.Remove(record);
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
        public OfficeDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                oficina record = db.oficina.Find(id);
                if (record == null)
                {
                    return null;
                }
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<OfficeDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<oficina> list = db.oficina.Where(x => x.nombre.Contains(filter));
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public OfficeDbModel updateRecord(OfficeDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
