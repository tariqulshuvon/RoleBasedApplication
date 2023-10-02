using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBased.Model;
using RoleBased.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Infrastructure.Persistence.Configurations;

public class StudentInfoConfigurations :IEntityTypeConfiguration<StudentInfo>
{
    public void Configure(EntityTypeBuilder<StudentInfo> builder)
    {

        builder.HasKey(x => x.RegNo);
        builder.HasData(new
        {
            RegNo = "2016-2-60-147",
            StudentName = "Tariqul",
            DOB = "30/08/1996",
            Phone = "01679784089",
            Email = "tariqulshuvon@gmail.com"
        });
    }
}
