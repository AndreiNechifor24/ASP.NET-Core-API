using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ParkyAPI
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var providerApiVersionDescription in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    providerApiVersionDescription.GroupName,
                    new OpenApiInfo()
                    {
                        Title = $"Parky API {providerApiVersionDescription.ApiVersion}",
                        Version = providerApiVersionDescription.ApiVersion.ToString()
                    });
            }
        }
    }
}
