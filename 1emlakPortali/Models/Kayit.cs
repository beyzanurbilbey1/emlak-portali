//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1emlakPortali.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kayit
    {
        public string KayitId { get; set; }
        public string kayitKatId { get; set; }
        public string kayitEvId { get; set; }
        public string kayitKulId { get; set; }
    
        public virtual Evler Evler { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
