//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dostavka.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Driver_Status
    {
        public int ID_status { get; set; }
        public Nullable<int> ID_Driver { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Last_update { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
