//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PackageDelivery.Repository.Implementation.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class paquete
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public paquete()
        {
            this.envio = new HashSet<envio>();
            this.historial = new HashSet<historial>();
        }
    
        public long id { get; set; }
        public double peso { get; set; }
        public double altura { get; set; }
        public double profundidad { get; set; }
        public string codigo { get; set; }
        public double ancho { get; set; }
        public Nullable<long> idOficina { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<envio> envio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historial> historial { get; set; }
        public virtual oficina oficina { get; set; }
    }
}
