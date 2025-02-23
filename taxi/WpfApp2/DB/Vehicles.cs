//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicles()
        {
            this.VehicleAssignments = new HashSet<VehicleAssignments>();
        }
    
        public int vehicle_id { get; set; }
        public string model { get; set; }
        public Nullable<int> year { get; set; }
        public Nullable<int> mileage { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> last_service_date { get; set; }
        public Nullable<System.DateTime> next_service_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleAssignments> VehicleAssignments { get; set; }
    }
}
