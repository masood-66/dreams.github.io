//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Islamic_Dreams.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DATA_SETS
    {
        public int DATA_ID { get; set; }
        public string DATA_ENGLISH { get; set; }
        public string DATA_URDU { get; set; }
        public int FK_KEY_CODE { get; set; }
        public Nullable<int> FK_IMAM_CODE { get; set; }
    
        public virtual IMAM_INFO IMAM_INFO { get; set; }
        public virtual KEY_WORDS KEY_WORDS { get; set; }
    }
}