using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Serialization
{
    public class DateOnlyConverter : JsonConverter<DateOnly>
    {

        private readonly string _format = "dd/MM/yyyy";

        public DateOnlyConverter() { }
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateOnly.ParseExact(reader.GetString()!, _format, CultureInfo.InvariantCulture);

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_format));
    }
}
