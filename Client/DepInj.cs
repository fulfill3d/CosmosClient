using Client.Interfaces;
using Client.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public static class DepInj
    {
        public static void RegisterCosmosDbClient(
            this IServiceCollection services,
            Action<CosmosDbClientOptions> configureCosmosDbClientOptions)
        {
            services.ConfigureServiceOptions<CosmosDbClientOptions>((_, options) => configureCosmosDbClientOptions(options));
            services.AddTransient<ICosmosDbClient, CosmosDbClient>();
        }

        private static void ConfigureServiceOptions<TOptions>(
            this IServiceCollection services,
            Action<IServiceProvider, TOptions> configure)
            where TOptions : class
        {
            services
                .AddOptions<TOptions>()
                .Configure<IServiceProvider>((options, resolver) => configure(resolver, options));
        }
    }
}