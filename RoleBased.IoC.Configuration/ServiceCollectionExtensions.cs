using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoleBased.Core;
using RoleBased.Core.Mapping;
using RoleBased.Infrastructure.Persistence;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace RoleBased.IoC.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection MapCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RoleBasedDbContext>(option => option.UseSqlServer
        (configuration.GetConnectionString("defaultconnection")));

        services.AddAutoMapper(typeof(MappingExtension).Assembly);
        services.AddTransient<IStudentInfoRepository, StudentInfoRepo>();
        services.AddTransient<ILoginDbRepository, LoginDbRepo>();
        services.AddValidatorsFromAssembly(typeof(ICore).Assembly);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
        });

        return services;
    }
}
