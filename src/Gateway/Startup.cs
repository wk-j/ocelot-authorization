using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            var key = "testKey";
            Action<IdentityServerAuthenticationOptions> opt = o => {
                o.Authority = "http://identity-service:80";
                o.ApiName = "api1";
                o.RequireHttpsMetadata = false;
            };

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(key, opt);

            services.AddControllers();
            services.AddOcelot();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            var configuration = new OcelotPipelineConfiguration {
                PreErrorResponderMiddleware = async (ctx, next) => {
                    var path = ctx.Request.Path;
                    var method = ctx.Request.Method;
                    Console.WriteLine("Request -- [{1}] {0}", path, method);

                    var auth = ctx.Request.Headers["Authorization"];
                    if (auth.Count == 0) {
                        ctx.Request.Headers.Add("Authorization", "Basic YXBpOm9yMjAyMGFwaQ==");
                    }

                    await next.Invoke();
                },
            };

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
            app.UseOcelot(configuration).Wait();
        }
    }
}
