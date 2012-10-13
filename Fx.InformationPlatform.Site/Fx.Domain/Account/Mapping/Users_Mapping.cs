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
    
    internal partial class Users_Mapping : EntityTypeConfiguration<Users>
    {
        public Users_Mapping()
        {                        
              this.HasKey(t => t.UserId);        
              this.ToTable("Users");
              this.Property(t => t.ApplicationId).HasColumnName("ApplicationId");
              this.Property(t => t.UserId).HasColumnName("UserId");
              this.Property(t => t.UserName).HasColumnName("UserName").IsRequired().HasMaxLength(256);
              this.Property(t => t.LoweredUserName).HasColumnName("LoweredUserName").IsRequired().HasMaxLength(256);
              this.Property(t => t.MobileAlias).HasColumnName("MobileAlias").HasMaxLength(16);
              this.Property(t => t.IsAnonymous).HasColumnName("IsAnonymous");
              this.Property(t => t.LastActivityDate).HasColumnName("LastActivityDate");
              this.HasRequired(t => t.Applications).WithMany(t => t.Users).HasForeignKey(d => d.ApplicationId);
         }
    }
}
