using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoleBased.Infrastructure.Persistence;
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

        //services.AddAutoMapper(typeof(MappingExtension).Assembly);
        //services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        //services.AddTransient<ICountryRepository, CountryRepository>();
        //services.AddTransient<IStateRepository, StateRepository>();

        //services.AddValidatorsFromAssembly(typeof(ICore).Assembly);

        //services.AddMediatR(cfg =>
        //{
        //    cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
        //    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //});
        return services;
    }
}
