using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Serialization
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {

        private readonly string _format = "dd/MM/yyyy";

        public DateTimeConverter() { }
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateTime.ParseExact(reader.GetString()!, _format, CultureInfo.InvariantCulture);

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_format));
    }
}
