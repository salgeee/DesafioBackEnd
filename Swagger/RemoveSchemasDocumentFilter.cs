using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class RemoveSchemasDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // Verifica se a propriedade "Schemas" existe antes de tentar removê-la
        if (swaggerDoc.Components.Schemas != null)
        {
            swaggerDoc.Components.Schemas.Clear();
        }
    }
}