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
    
    public partial class PRODUTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUTO()
        {
            this.PROD_ORCAMENTO = new HashSet<PROD_ORCAMENTO>();
        }
    
        public int ID { get; set; }
        public string DESCRICAO { get; set; }
        public double VALOR { get; set; }
        public int ID_FORNECEDOR { get; set; }
        public int ID_FABRICANTE { get; set; }
    
        public virtual FABRICANTE FABRICANTE { get; set; }
        public virtual FORNECEDOR FORNECEDOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROD_ORCAMENTO> PROD_ORCAMENTO { get; set; }
    }
}
