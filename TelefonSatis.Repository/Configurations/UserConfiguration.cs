using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.UsersId);
            builder.Property(x => x.UsersId).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(250);
            builder.Property(x=>x.Surname).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.Address).IsRequired(true).HasMaxLength(250);
            builder.Property(x=>x.Email).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.RuleId);

            builder.HasOne(x => x.Rules).WithMany(x => x.Users).HasForeignKey(x => x.RuleId);

            // builder.HasMany(x=>x.Products).WithOne(x=>x.Users).HasForeignKey(x=>x.UserId);  


        }
    }
}
