﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Contracts.DTO
{
    public class AddressDTO
    {
        public long Id { get; set; }
        public string TipoCalle { get; set; }
        public string Numero { get; set; }
        public string TipoInmueble { get; set; }
        public string Barrio { get; set; }
        public string Observaciones { get; set; }
        public bool Actual { get; set; }
        public long IdMunicipio { get; set; }
        public long IdPersona { get; set; }
        
        public string MunicipioName { get; set; }

        public string PersonaName { get; set; }
    }
}