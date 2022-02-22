using MyCommunityBuilder.Identity.Data;
using MyCommunityBuilder.Identity.Helpers;
using MyCommunityBuilder.Identity.Models;
using MyCommunityBuilder.Identity.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Syncfusion.Blazor;
using Microsoft.OpenApi.Models;
using MyCommunityBuilder.Server.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using System.Net.Http;

using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Identity
{
    public class Startup
    {
        /// <summary>
        /// The token provider used to generate tokens used in account confirmation  emails.
        /// It could be a user friendly name define by user
        /// </summary>
        private const string EmailConfirmationTokenProviderName = "ConfirmEmail";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        private IWebHostEnvironment CurrentEnvironment { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure the identity option for the EmailConfirmationTokenProvider 
            services.Configure<IdentityOptions>(options =>
            {
                options.Tokens.EmailConfirmationTokenProvider = EmailConfirmationTokenProviderName;
            });

            services.Configure<ConfirmEmailDataProtectionTokenProviderOptions>(options =>
            {
                // Set confirmation email token life time for 5  Mins
                options.TokenLifespan = TimeSpan.FromMinutes(5);
            });
            string con = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    con));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                // True, so that when registering, account needs to be confirmed.
                options.SignIn.RequireConfirmedAccount = true;

                // Define/set our token ConfirmEmailDataProtectorTokenProvider to use for token
                options.Tokens.EmailConfirmationTokenProvider = EmailConfirmationTokenProviderName;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                 .AddTokenProvider<ConfirmEmailDataProtectorTokenProvider<ApplicationUser>>(EmailConfirmationTokenProviderName); // Register our DataProtector Token Provider token 

            var builder = services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                {
                    options.IdentityResources["openid"].UserClaims.Add("name");
                    options.ApiResources.Single().UserClaims.Add("name");
                    options.IdentityResources["openid"].UserClaims.Add("role");
                    options.ApiResources.Single().UserClaims.Add("role");
                })
                .AddProfileService<ProfileService>(); // Regiter our profile service

            if (!CurrentEnvironment.IsDevelopment())
            {
                builder.AddSigningCredentials();
                Console.WriteLine();
                //X509Certificate2 cert = null;
                //cert = new X509Certificate2(Path.Combine(env.ContentRootPath, "communitybuilder.pfx"), "communitybuilder");
            }
            // 
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role"); ;

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddAuthorization(options =>
            {
                //// Add new policy for Require MFA
                //// Will be used as attrubute  on Controller & Controller Action method as attrubute 
                //options.AddPolicy("RequireMfa", policyIsAdminRequirement =>
                //{
                //    // Register our Authorization handler MFA 
                //    policyIsAdminRequirement.Requirements.Add(new RequireMfa());
                //});
            });
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyCommunityBuilder.API", Version = "v1" });
                c.SchemaFilter<EnumSchemaFilter>();

            });


            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSyncfusionBlazor();
            services.AddScoped<HttpClient>();
            //using Tewr.Blazor.FileReader;
            //services.AddFileReaderService();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTMwOTAwQDMxMzkyZTMzMmUzMEVreTlQT2E5c0E0dkU2SE9zQlNrbllTc0I3cC8ybGFUcFFpbjZVcWZvcnM9");

            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins(Configuration.GetSection("AllowedHosts").Value)
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCommunityBuilder.API v1"));
            app.UseCors("CorsApi");
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
            
            string baseURL = AppDomain.CurrentDomain.BaseDirectory;
        }

        
    }
}
