//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lopushok
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductMaterial
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MaterialId { get; set; }
        public Nullable<int> MaterialQuantity { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Product Product { get; set; }
    }
}
