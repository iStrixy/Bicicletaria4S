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
    
    public partial class SERVICO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICO()
        {
            this.REG_SERV_ORCAMENTO = new HashSet<REG_SERV_ORCAMENTO>();
        }
    
        public int ID { get; set; }
        public string DESCRICAO { get; set; }
        public double VALOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REG_SERV_ORCAMENTO> REG_SERV_ORCAMENTO { get; set; }
    }
}
