//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GreenE.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public int Id_acc { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Id_Role { get; set; }
        public int Id_Slakd { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual Sklad Sklad { get; set; }
    }
}
