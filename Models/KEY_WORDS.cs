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
    
    public partial class KEY_WORDS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KEY_WORDS()
        {
            this.DATA_SETS = new HashSet<DATA_SETS>();
        }
    
        public int KEY_CODE { get; set; }
        public string KEY_ENGLISH { get; set; }
        public string KEY_URDU { get; set; }
        public int FK_BOOK_REF { get; set; }
    
        public virtual BOOKS_INFO BOOKS_INFO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATA_SETS> DATA_SETS { get; set; }
    }
}
