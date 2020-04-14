using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Nordisk.Common.SSO.Library.AutoMapper;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using vexpenses.business.Security;
using vexpenses.data.IRepositories;
using vexpenses.data.Repositories;
using vexpenses.business.Components;
using vexpenses.data.Context;

namespace vexpenses
{
    /// <summary>
    /// Class Startup
    /// </summary>
    public class Startup
    {
        private const string DefaultCorsPolicy = "DefaultCorsPolicy";

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc(opt =>
            {
                opt.EnableEndpointRouting = false;
            });

            services.AddMvcCore().AddApiExplorer().AddNewtonsoftJson();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            ConfiguracaoContext(services);
            ConfigureAppSettings(services);
            ConfigureAutoMapper(services);
            ConfigureSwagger(services);
            ConfigureCors(services);
            ConfigureRepository(services);
            ConfigureComponentServices(services);
            ConfigureJWT(services);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseCors(DefaultCorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "default",
                        template: "/api/{culture}/{controller}/{action}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "vexpenses");
            });
        }

        private void ConfiguracaoContext(IServiceCollection services)
        {
            //injetando contexto do banco de dados
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<VExpensesContext>()
                    .BuildServiceProvider();
        }

        private void ConfigureComponentServices(IServiceCollection services)
        {
            services.AddScoped<UserComponent>();
            services.AddScoped<AgendaComponent>();
            services.AddScoped<AgendaContatoComponent>();
            services.AddScoped<EnderecoComponent>();
            services.AddScoped<TelefoneComponent>();
            services.AddScoped<TipoAgendaComponent>();
            services.AddScoped<TipoTelefoneComponent>();
            services.AddScoped<ContatoComponent>();
        }

        private void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IAgendaContatoRepository, AgendaContatoRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<ITipoAgendaRepository, TipoAgendaRepository>();
            services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(setup =>
            {
                setup.AddPolicy(DefaultCorsPolicy, builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            var swaggerXMLPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{PlatformServices.Default.Application.ApplicationName}.xml");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "VExpenses API",
                    Description = "Microserviços para a aplicação de cadastro de agendas de contato",
                    Contact = new OpenApiContact() { Name = "Willian Menezes", Email = "willian_menezes_santos@hotmail.com", Url = new System.Uri("https://www.linkedin.com/in/willian-menezes-9932b1b9") }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.IncludeXmlComments(swaggerXMLPath);
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mappingConfig.CompileMappings();

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

        private void ConfigureAppSettings(IServiceCollection services)
        {

        }

        private void ConfigureJWT(IServiceCollection services)
        {
            // autenticação com JWT
            var signingConfiguration = new SigningConfiguration();
            services.AddSingleton(signingConfiguration);//apenas uma instancia enquanto a aplicação estiver executando

            var tokenConfiguration = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfiguration);

            services.AddSingleton(tokenConfiguration);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfiguration.Key;
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidIssuer = tokenConfiguration.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Enables the use of the token as a means of
            // authorizing access to this project's resources
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
        }

    }
}
