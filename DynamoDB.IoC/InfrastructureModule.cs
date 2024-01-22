using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using DynamoDB.Application.Services;
using DynamoDB.Core.Contracts;
using DynamoDB.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DynamoDB.IoC
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddServices()
                .AddRepositories();

            var awsOptions = configuration.GetAWSOptions();

            services.AddDefaultAWSOptions(awsOptions);
            services.TryAddAWSService<IAmazonDynamoDB>();
            services.AddScoped<IDynamoDBContext, DynamoDBContext>();


            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IShippingOrderService), typeof(ShippingOrderService));
            services.AddScoped(typeof(IShippingServiceService), typeof(ShippingServiceService));


            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IShippingOrderRepository), typeof(ShippingOrderRepository));
            services.AddScoped(typeof(IShippingServiceRepository), typeof(ShippingServiceRepository));


            return services;
        }

    }
}

