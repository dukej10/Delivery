using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Core;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class ShippingStatusImpRepository : IShippingStatusRepository
    {
        public ShippingStatusDbModel createRecord(ShippingStatusDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                estadoEnvio status = db.estadoEnvio.Where(x => x.nombre.ToUpper().Trim().Equals(record.Name.ToUpper())).FirstOrDefault();
                if (status != null)
                {
                    return null;
                }
                ShippingStatusRepositoryMapper mapper = new ShippingStatusRepositoryMapper();
                estadoEnvio st = mapper.DbModelToDatabaseMapper(record);
                db.estadoEnvio.Add(st);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(st);
            }
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    estadoEnvio record = db.estadoEnvio.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.estadoEnvio.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public ShippingStatusDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                estadoEnvio record = db.estadoEnvio.Find(id);
                if (record == null)
                {
                    return null;
                }
                ShippingStatusRepositoryMapper mapper = new ShippingStatusRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<ShippingStatusDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<estadoEnvio> list = db.estadoEnvio.Where(x => x.nombre.Contains(filter));
                ShippingStatusRepositoryMapper mapper = new ShippingStatusRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public ShippingStatusDbModel updateRecord(ShippingStatusDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                estadoEnvio td = db.estadoEnvio.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.Name;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    ShippingStatusRepositoryMapper mapper = new ShippingStatusRepositoryMapper();

                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
