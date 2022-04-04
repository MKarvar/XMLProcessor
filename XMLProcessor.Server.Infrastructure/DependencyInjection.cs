using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using XMLProcessor.Server.Application.Contracts;
using XMLProcessor.Server.Infrastructure.Context.EF;
using XMLProcessor.Server.Infrastructure.Context.EF.Repositories;

namespace XMLProcessor.Server.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<INodeRepository, NodeRepository>();
            services.AddDbContext<NodeProcessorDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(NodeProcessorDbContext).Assembly.FullName)));
            return services;
        }
    }
}
