using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Data.Entity;
using System.Web.Http;

namespace ioasysAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(FilterConfig.Configure);
            Database.SetInitializer(new Core.Initializer());
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
