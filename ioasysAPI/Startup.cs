using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Swashbuckle.Swagger;
using System;

[assembly: OwinStartup(typeof(ioasysAPI.Startup))]
namespace ioasysAPI
{
    public partial class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {      
            
            app.UseSwagger();            
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "IoasysAPI V1");
            });            
        }
        public void Configuration(IAppBuilder app)
        {

            ConfigureOAuth(app);            
        }
    }
}