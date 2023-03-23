using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    internal class AddressRepositoryMapper : DbModelMapperBase<AddressDbModel, direccion>
    {

        public override AddressDbModel DatabaseToDbModelMapper(direccion input)
        {
            return new AddressDbModel()
            {
                Id = input.id,
                TipoCalle = input.tipoCalle,
                Numero = input.numero,
                TipoInmueble = input.tipoInmueble,
                Barrio = input.barrio,
                Observaciones = input.observaciones,
                Actual = input.actual,
                IdMunicipio = input.idMunicipio,
                IdPersona = input.idPersona

            };
        }

        public override IEnumerable<AddressDbModel> DatabaseToDbModelMapper(IEnumerable<direccion> input)
        {
            IList<AddressDbModel> list = new List<AddressDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override direccion DbModelToDatabaseMapper(AddressDbModel input)
        {
            return new direccion()
            {
                id = input.Id,
                tipoCalle = input.TipoCalle,
                numero = input.Numero,
                tipoInmueble = input.TipoInmueble,
                barrio = input.Barrio,
                observaciones = input.Observaciones,
                actual = input.Actual,
                idMunicipio = input.IdMunicipio,
                idPersona = input.IdPersona

            };
        }

        public override IEnumerable<direccion> DbModelToDatabaseMapper(IEnumerable<AddressDbModel> input)
        {
            IList<direccion> list = new List<direccion>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
