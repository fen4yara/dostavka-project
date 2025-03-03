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
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.Feedback = new HashSet<Feedback>();
            this.OrderTracking = new HashSet<OrderTracking>();
        }
    
        public int order_id { get; set; }
        public string customer_name { get; set; }
        public string customer_phone { get; set; }
        public string pickup_location { get; set; }
        public string dropoff_location { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public Nullable<int> assigned_driver_id { get; set; }
    
        public virtual Drivers Drivers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedback { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTracking> OrderTracking { get; set; }
    }
}
