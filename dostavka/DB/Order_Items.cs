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
    
    public partial class Order_Items
    {
        public int ID_item { get; set; }
        public Nullable<int> ID_Order { get; set; }
        public Nullable<int> ID_Product { get; set; }
        public Nullable<int> Quantity_product { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}
