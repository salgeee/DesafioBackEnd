using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class SwaggerResponseExamplesFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.HttpMethod == "GET" && operation.Responses.ContainsKey("200"))
        {
            operation.Responses["200"].Content["application/json"] = new OpenApiMediaType
            {
                Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["identifier"] = new Microsoft.OpenApi.Any.OpenApiString("Moto123"),
                    ["year"] = new Microsoft.OpenApi.Any.OpenApiInteger(2022),
                    ["model"] = new Microsoft.OpenApi.Any.OpenApiString("Mottu Sport"),
                    ["plate"] = new Microsoft.OpenApi.Any.OpenApiString("ABC-1234")
                }
            };
        }
        
        if (operation.Responses.ContainsKey("200"))
        {
            operation.Responses["200"].Content["application/json"] = new OpenApiMediaType
            {
                Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["identifier"] = new Microsoft.OpenApi.Any.OpenApiString("Moto123"),
                    ["year"] = new Microsoft.OpenApi.Any.OpenApiInteger(2022),
                    ["model"] = new Microsoft.OpenApi.Any.OpenApiString("Mottu Sport"),
                    ["plate"] = new Microsoft.OpenApi.Any.OpenApiString("ABC-1234")
                }
            };
        }
        
        if (context.ApiDescription.HttpMethod == "PUT" && operation.Responses.ContainsKey("200"))
        {
            operation.Responses["200"].Content["application/json"] = new OpenApiMediaType
            {
                Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["mensagem"] = new Microsoft.OpenApi.Any.OpenApiString("Placa modificada com sucesso")
                }
            };
        }
        
        
        if (operation.Responses.ContainsKey("400"))
        {
            operation.Responses["400"].Content["application/json"] = new OpenApiMediaType
            {
                Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["mensagem"] = new Microsoft.OpenApi.Any.OpenApiString("Dados inválidos")
                }
            };
        }
        
        if (operation.Responses.ContainsKey("404"))
        {
            operation.Responses["404"].Content["application/json"] = new OpenApiMediaType
            {
                Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["mensagem"] = new Microsoft.OpenApi.Any.OpenApiString("Moto não encontrada")
                }
            };
        }
    }
}
