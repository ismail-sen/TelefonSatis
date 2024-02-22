using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.TelefonSatisDatabase;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TelefonSatis.Repository.Configurations
{
   public class RuleConfiguration : IEntityTypeConfiguration<Rules>
    {
        public void Configure(EntityTypeBuilder<Rules> builder)
        {
            builder.HasKey(x => x.RulesId);
            builder.Property(x => x.RulesId).IsRequired(true).UseIdentityColumn(100,1);
            builder.Property(x=>x.RulesName).IsRequired(true).HasMaxLength(250);
            builder.Property(x=>x.Description).HasMaxLength(250);

            
        }
    }
}
