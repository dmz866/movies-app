using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Movies.Api.Filters
{
    // Custom parameter for header api key value (Swagger)
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiKeyHeader : Attribute, IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "ApiKey",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema() { Type = "string" }
            });
        }
    }
}
