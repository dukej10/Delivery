using PackageDelivery.Repository.Contracts.DbModels.Core;
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
    public class AddressImpRepository : IAddressRepository
    {
        public AddressDbModel createRecord(AddressDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                direccion direccion = db.direccion.Where(x => x.tipoCalle.ToUpper().Trim().Equals(record.TipoCalle.ToUpper())).FirstOrDefault();
                if (direccion != null)
                {
                    return null;
                }
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                direccion dc = mapper.DbModelToDatabaseMapper(record);
                db.direccion.Add(dc);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(dc);
            }
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    direccion record = db.direccion.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.direccion.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public AddressDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                direccion record = db.direccion.Find(id);
                if (record == null)
                {
                    return null;
                }
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<AddressDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<direccion> list = db.direccion.Where(x => x.numero.Contains(filter));
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public AddressDbModel updateRecord(AddressDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                direccion td = db.direccion.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }

                else
                {
                    td.idMunicipio = record.IdMunicipio;
                    td.numero = record.Numero;
                    td.idPersona = record.IdPersona;
                    td.tipoCalle = record.TipoCalle;
                    td.tipoInmueble = record.TipoInmueble;
                    td.observaciones = record.Observaciones;
                    td.barrio = record.Barrio;
                    td.actual = record.Actual;

                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    AddressRepositoryMapper mapper = new AddressRepositoryMapper();

                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
