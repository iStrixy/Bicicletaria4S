﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD_BICICLETARIA_4SEntities : DbContext
    {
        public BD_BICICLETARIA_4SEntities()
            : base("name=BD_BICICLETARIA_4SEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<FABRICANTE> FABRICANTE { get; set; }
        public virtual DbSet<FORNECEDOR> FORNECEDOR { get; set; }
        public virtual DbSet<FUNCIONARIO> FUNCIONARIO { get; set; }
        public virtual DbSet<LOGIN> LOGIN { get; set; }
        public virtual DbSet<ORCAMENTO> ORCAMENTO { get; set; }
        public virtual DbSet<PESSOA> PESSOA { get; set; }
        public virtual DbSet<PROD_ORCAMENTO> PROD_ORCAMENTO { get; set; }
        public virtual DbSet<PRODUTO> PRODUTO { get; set; }
        public virtual DbSet<REG_SERV_ORCAMENTO> REG_SERV_ORCAMENTO { get; set; }
        public virtual DbSet<SERVICO> SERVICO { get; set; }
        public virtual DbSet<TELEFONE_FABRICANTE> TELEFONE_FABRICANTE { get; set; }
        public virtual DbSet<TELEFONE_FORNECEDOR> TELEFONE_FORNECEDOR { get; set; }
        public virtual DbSet<TELEFONE_PESSOA> TELEFONE_PESSOA { get; set; }
    }
}