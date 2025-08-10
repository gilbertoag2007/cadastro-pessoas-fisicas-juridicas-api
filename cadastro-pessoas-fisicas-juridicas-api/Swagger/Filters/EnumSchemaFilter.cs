using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace cadastro_pessoas_fisicas_juridicas_api.Swagger.Filters
{
    public class EnumSchemaFilter: ISchemaFilter
    {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                var enumNames = Enum.GetNames(context.Type);
                var enumValues = Enum.GetValues(context.Type).Cast<int>();

                schema.Description += "<p>Valores possíveis:</p><ul>";

                foreach (var (name, value) in enumNames.Zip(enumValues, (n, v) => (n, v)))
                {
                    schema.Description += $"<li>{value} = {name}</li>";
                }

                schema.Description += "</ul>";
            }
        }

    }
}
