using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PropertyManagementAPI.Entities;
using PropertyManagementAPI.Services;

namespace PropertyManagementAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter())
                );
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=PropertyInfoDB;Trusted_Connection=True";
            services.AddDbContext<DbInfoContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IBuyerInfoRepository, BuyerInfoRepository>();
            services.AddScoped<IApartmentInfoRepository, ApartmentInfoRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbInfoContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            context.EnsureSeedDataForContext();
            app.UseStatusCodePages();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Apartment, Models.ApartmentDto>();
                // map to Buyer with all information (including list of apartments owned)
                cfg.CreateMap<Entities.Buyer, Models.BuyerDto>();
                // map to Buyer with minimum information (without the apartments owned)
                cfg.CreateMap<Entities.Buyer, Models.BuyerWithoutApartmentsDto>()
                    .ForMember(dest => dest.NbOfOwnedApartments, opt => opt.MapFrom(src => src.OwnedApartments.Count));
                // the price of an apartments is always NbOfRooms * 3000 (assignement 1)
                cfg.CreateMap<Models.ApartmentForCreationDto, Entities.Apartment>()
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.NbOfRooms * 3000));
                // mapper for the update of an apartment
                cfg.CreateMap<Models.ApartmentForUpdateDto, Entities.Apartment>();
                // mapper for the partial update of an apartment
                cfg.CreateMap<Entities.Apartment, Models.ApartmentForUpdateDto>();
                

            });
            app.UseCors("CorsPolicy");
            app.UseMvc();

        }
    }
}
