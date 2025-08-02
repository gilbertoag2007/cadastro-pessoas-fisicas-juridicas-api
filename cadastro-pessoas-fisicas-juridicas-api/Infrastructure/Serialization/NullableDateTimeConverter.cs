using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Serialization
{
    public class NullableDateTimeConverter : JsonConverter<DateTime?>
    {
        private readonly string _format = "dd/MM/yyyy";

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            var str = reader.GetString();
            if (string.IsNullOrWhiteSpace(str))
                return null;

            var date = DateTime.ParseExact(str, _format, CultureInfo.InvariantCulture);
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                writer.WriteStringValue(value.Value.ToString(_format));
            else
                writer.WriteNullValue();
        }
    }

}


