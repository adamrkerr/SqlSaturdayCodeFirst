using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using SqlSaturdayCodeFirst.Context;
using SqlSaturdayCodeFirst.DI;
using AutoMapper;

namespace SqlSaturdayCodeFirst.Tests
{
    /// <summary>
    /// Test implementation of IApplicationBuilder so we can use our startup extensions in testing
    /// </summary>
    public class TestAppBuilder : IApplicationBuilder
    {
        public IServiceProvider ApplicationServices { get; set; }

        public IFeatureCollection ServerFeatures => throw new NotImplementedException();

        public IDictionary<string, object> Properties => throw new NotImplementedException();

        public RequestDelegate Build()
        {
            throw new NotImplementedException();
        }

        public IApplicationBuilder New()
        {
            throw new NotImplementedException();
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            throw new NotImplementedException();
        }
    }

    public class DatabaseTestingFixture<T> : IDisposable where T : class
    {
        public DatabaseTestingFixture()
        {
            var serviceCollection = new ServiceCollection();

            var args = new UniversityDbArguments
            {
                ConnectionString = $"Server=(localdb)\\mssqllocaldb;Database={typeof(T)}_University;Trusted_Connection=True;MultipleActiveResultSets=true",
                CreateDbIfNotFound = true
            };

            serviceCollection.RegisterUniversityDb(args);

            var app = new TestAppBuilder();
            
            ServiceProvider = serviceCollection.BuildServiceProvider();

            //Delete the database before we start
            var context = ServiceProvider.GetRequiredService<UniversityDbContext>();
            context.Database.EnsureDeleted();

            app.ApplicationServices = ServiceProvider;
            
            //set up automapper
            var mapperProfiles = ServiceProvider.GetServices<Profile>();

            Mapper.Initialize(cfg =>
            {
                foreach(var profile in mapperProfiles)
                {
                    cfg.AddProfile(profile);
                }
            });
            
            app.UseUniversityDb();
        }

        public void Dispose()
        {
            var context = ServiceProvider.GetRequiredService<UniversityDbContext>();

            context.Database.EnsureDeleted();
        }

        public IServiceProvider ServiceProvider { get; set; }
        
    }
}
