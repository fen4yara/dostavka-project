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
    
    public partial class DriverBonuses
    {
        public int bonus_id { get; set; }
        public Nullable<int> driver_id { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string reason { get; set; }
        public Nullable<System.DateTime> bonus_date { get; set; }
    
        public virtual Drivers Drivers { get; set; }
    }
}
