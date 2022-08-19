using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TTMapi.Models;
using TTMapi.Services;

namespace TTMapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // requires using Microsoft.Extensions.Options
            services.Configure<TTMDBSettings>(Configuration.GetSection(nameof(TTMDBSettings)));
            services.Configure<Authenticator>(Configuration.GetSection(nameof(Authenticator)));

            services.AddSingleton<TTMDBSettings>(sp =>
                sp.GetRequiredService<IOptions<TTMDBSettings>>().Value);
            services.AddSingleton<Authenticator>(sp =>
                sp.GetRequiredService<IOptions<Authenticator>>().Value);
            services.AddSingleton<UserService>();
            services.AddSingleton<DialService>();
            services.AddSingleton<TagCatService>();
            services.AddSingleton<TagService>();
            services.AddSingleton<LangService>();
            services.AddMvc();//.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            var appSettingsSection = Configuration.GetSection("Authenticator");
            services.Configure<Authenticator>(appSettingsSection);
            var appSettings = appSettingsSection.Get<Authenticator>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Secret));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        { 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
