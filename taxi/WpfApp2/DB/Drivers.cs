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
    
    public partial class Drivers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drivers()
        {
            this.DriverBonuses = new HashSet<DriverBonuses>();
            this.Feedback = new HashSet<Feedback>();
            this.Orders = new HashSet<Orders>();
            this.VehicleAssignments = new HashSet<VehicleAssignments>();
        }
    
        public int driver_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string license_number { get; set; }
        public Nullable<System.DateTime> hire_date { get; set; }
        public string contract_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverBonuses> DriverBonuses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedback { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleAssignments> VehicleAssignments { get; set; }
    }
}
