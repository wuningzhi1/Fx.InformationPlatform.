//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fx.Domain.FxCar.Mapping
{
    #pragma warning disable 1573
    using System.Data.Entity.ModelConfiguration;
    using Fx.Entity.FxCar;
    
    internal partial class CarBuyLogs_Mapping : EntityTypeConfiguration<CarBuyLog>
    {
        public CarBuyLogs_Mapping()
        {                        
              this.HasKey(t => t.CarBuyLogId);        
              this.ToTable("CarBuyLog","Car");
              this.Property(t => t.CarBuyLogId).HasColumnName("CarBuyLogId");
              this.Property(t => t.OperteName).HasColumnName("OperteName").HasMaxLength(32);
              this.Property(t => t.Source).HasColumnName("Source").HasMaxLength(32);
              this.Property(t => t.OperteTime).HasColumnName("OperteTime");
         }
    }
}