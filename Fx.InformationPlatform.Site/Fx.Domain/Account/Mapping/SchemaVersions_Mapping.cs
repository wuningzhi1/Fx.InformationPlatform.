//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fx.Domain.Account.Mapping
{
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.Infrastructure;
    using Fx.Entity;
    
    internal partial class SchemaVersions_Mapping : EntityTypeConfiguration<SchemaVersions>
    {
        public SchemaVersions_Mapping()
        {                        
              this.HasKey(t => new {t.Feature, t.CompatibleSchemaVersion});        
              this.ToTable("SchemaVersions");
              this.Property(t => t.Feature).HasColumnName("Feature").IsRequired().HasMaxLength(128);
              this.Property(t => t.CompatibleSchemaVersion).HasColumnName("CompatibleSchemaVersion").IsRequired().HasMaxLength(128);
              this.Property(t => t.IsCurrentVersion).HasColumnName("IsCurrentVersion");
         }
    }
}
