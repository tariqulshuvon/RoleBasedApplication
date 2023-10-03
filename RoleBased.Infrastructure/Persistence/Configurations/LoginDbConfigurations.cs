using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBased.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Infrastructure.Persistence.Configurations;

public class LoginDbConfigurations : IEntityTypeConfiguration<LoginDB>
{
    public void Configure(EntityTypeBuilder<LoginDB> builder)
    {
        builder.HasKey(x => x.RegNo);
        builder.HasData(new
        {
            RegNo = "2016-2-60-147",
            Password = "12345",
            Role = "Admin"
        });
    }
}
