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
    
    public partial class PROD_ORCAMENTO
    {
        public int ID { get; set; }
        public int ID_ORCAMENTO { get; set; }
        public int ID_PRODUTO { get; set; }
        public double SUB_TOTAL { get; set; }
        public Nullable<int> QUANTIDADE { get; set; }
    
        public virtual ORCAMENTO ORCAMENTO { get; set; }
        public virtual PRODUTO PRODUTO { get; set; }
    }
}
