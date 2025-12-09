using System.Text.Json.Serialization;
using System.Text.Json;

namespace Domain.Result
{
    public class ResultConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(Result) ||
                   (typeToConvert.IsGenericType &&
                    typeToConvert.GetGenericTypeDefinition() == typeof(Result<>));
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert == typeof(Result)) return new ResultConverter();

            var valueType = typeToConvert.GetGenericArguments()[0];
            return (JsonConverter)Activator.CreateInstance(
                typeof(ResultTConverter<>).MakeGenericType(valueType))!;

        }

        private class ResultConverter : JsonConverter<Result>
        {
            public override Result Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => throw new NotSupportedException("Deserialization of Result is not supported");

            public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                writer.WriteBoolean("isSuccess", value.IsSuccess);
                if (value.IsSuccess) writer.WriteNull("exception");
                else writer.WriteString("exception", value.Exception.Message);
                writer.WriteEndObject();
            }
        }

        private class ResultTConverter<T> : JsonConverter<Result<T>>
        {
            public override Result<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => throw new NotSupportedException($"Deserialization of Result<{typeof(T).Name}> is not supported");

            public override void Write(Utf8JsonWriter writer, Result<T> value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                writer.WriteBoolean("isSuccess", value.IsSuccess);
                if (value.IsSuccess)
                {
                    writer.WriteNull("exception");
                    writer.WritePropertyName("value");
                    JsonSerializer.Serialize(writer, value.Value, options);
                }
                else
                {
                    writer.WriteNull("value");
                    writer.WriteString("exception", value.Exception.Message);
                }
                writer.WriteEndObject();
            }
        }
    }
}