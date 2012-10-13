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
    
    internal partial class Roles_Mapping : EntityTypeConfiguration<Roles>
    {
        public Roles_Mapping()
        {                        
              this.HasKey(t => t.RoleId);        
              this.ToTable("Roles");
              this.Property(t => t.ApplicationId).HasColumnName("ApplicationId");
              this.Property(t => t.RoleId).HasColumnName("RoleId");
              this.Property(t => t.RoleName).HasColumnName("RoleName").IsRequired().HasMaxLength(256);
              this.Property(t => t.LoweredRoleName).HasColumnName("LoweredRoleName").IsRequired().HasMaxLength(256);
              this.Property(t => t.Description).HasColumnName("Description").HasMaxLength(256);
              this.HasRequired(t => t.Applications).WithMany(t => t.Roles).HasForeignKey(d => d.ApplicationId);
    			this.HasMany(t => t.Users).WithMany(t => t.Roles)
    				.Map(m => 
    				{
    					m.ToTable("UsersInRoles");
    					m.MapLeftKey("RoleId");
    					m.MapRightKey("UserId");
    				});
         }
    }
}
