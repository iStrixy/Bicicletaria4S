//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJ_INTER_BC4S
{
    using System;
    using System.Collections.Generic;
    
    public partial class FORNECEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FORNECEDOR()
        {
            this.PRODUTO = new HashSet<PRODUTO>();
            this.TELEFONE_FORNECEDOR = new HashSet<TELEFONE_FORNECEDOR>();
        }
    
        public int ID { get; set; }
        public string NOME { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUTO> PRODUTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TELEFONE_FORNECEDOR> TELEFONE_FORNECEDOR { get; set; }
    }
}
