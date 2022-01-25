using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smartway.Migrations;

namespace Smartway
{
    public static class DbMigrator
    {
        public static IHost Migrate(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var dapperDb = scope.ServiceProvider.GetRequiredService<DapperDatabase>();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            
            try
            {
                dapperDb.Create("smartway");
                
                runner.ListMigrations();
                runner.MigrateUp();
            }
            catch
            {
                Console.WriteLine("Cannot create a smartway database.");
                throw;
            }

            return host;
        }
    }
}