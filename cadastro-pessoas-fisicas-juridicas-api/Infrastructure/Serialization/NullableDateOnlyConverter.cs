using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Serialization;

namespace cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Serialization
{
    public class NullableDateOnlyConverter : JsonConverter<DateOnly?>
    {
        private readonly string _format = "dd/MM/yyyy";

        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            var str = reader.GetString();
            if (string.IsNullOrWhiteSpace(str))
                return null;

            return DateOnly.ParseExact(str, _format, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                writer.WriteStringValue(value.Value.ToString(_format, CultureInfo.InvariantCulture));
            else
                writer.WriteNullValue();
        }
    }
}

