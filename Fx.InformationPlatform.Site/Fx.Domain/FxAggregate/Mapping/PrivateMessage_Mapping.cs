//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fx.Domain.FxAggregate.Mapping
{
    #pragma warning disable 1573
    using System.Data.Entity.ModelConfiguration;
    using Fx.Entity.FxAggregate;
    
    internal partial class PrivateMessage_Mapping : EntityTypeConfiguration<PrivateMessage>
    {
        public PrivateMessage_Mapping()
        {                        
              this.HasKey(t => t.PrivateMessageId);        
              this.ToTable("PrivateMessage","Aggregate");
              this.Property(t => t.PrivateMessageId).HasColumnName("PrivateMessageId");
              this.Property(t => t.CreatedTime).HasColumnName("CreatedTime");
              this.Property(t => t.Title).HasColumnName("Title").HasMaxLength(128);
              this.Property(t => t.InterestingEmail).HasColumnName("InterestingEmail").HasMaxLength(128);
              this.Property(t => t.ChannelCatagroy).HasColumnName("ChannelCatagroy");
              this.Property(t => t.SourceId).HasColumnName("SourceId");
         }
    }
}
