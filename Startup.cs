using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;

namespace testIdentity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddTransient<ITokenProvider, TokenProvider>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

            services.AddIdentityServer(options => options.IssuerUri = "localhost")
                .AddInMemoryApiResources(ClientStore.GetApiResources())
                .AddInMemoryIdentityResources(ClientStore.GetIdentityResources())
                .AddInMemoryClients(ClientStore.GetClients())
                .AddDeveloperSigningCredential(false);

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        LifetimeValidator = (notBefore, expires, securityToken, validationParameter) =>
                            expires >= DateTime.UtcNow
                    };

                    options.RequireHttpsMetadata = false;
                    options.Authority = "http://localhost:5000";
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
            app.UseIdentityServer();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }

}
