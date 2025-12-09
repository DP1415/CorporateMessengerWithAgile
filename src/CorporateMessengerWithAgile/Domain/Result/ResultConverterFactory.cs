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
            if (typeToConvert == typeof(Result))
            {
                return new NonGenericResultConverter();
            }
            else
            {
                var valueType = typeToConvert.GetGenericArguments()[0];
                var converterType = typeof(GenericResultConverter<>).MakeGenericType(valueType);
                return (JsonConverter)Activator.CreateInstance(converterType)!;
            }
        }

        private class NonGenericResultConverter : JsonConverter<Result>
        {
            public override Result Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                    throw new JsonException();

                bool isSuccess = false;
                Exception? exception = null;

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        break;

                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        string propertyName = reader.GetString()!;
                        reader.Read();

                        switch (propertyName)
                        {
                            case "isSuccess":
                                isSuccess = reader.GetBoolean();
                                break;
                            case "exception":
                                var errorMessage = reader.GetString();
                                if (errorMessage != null)
                                    exception = new Exception(errorMessage);
                                break;
                        }
                    }
                }

                if (isSuccess)
                    return Result.Success();
                else
                    return Result.Failure(exception ?? new Exception("Unknown error"));
            }

            public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                writer.WriteBoolean("isSuccess", value.IsSuccess);

                if (!value.IsSuccess && value.Exception != null)
                {
                    writer.WritePropertyName("exception");
                    JsonSerializer.Serialize(writer, value.Exception.Message, options);
                }

                writer.WriteEndObject();
            }
        }

        private class GenericResultConverter<T> : JsonConverter<Result<T>>
        {
            public override Result<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                    throw new JsonException();

                bool isSuccess = false;
                Exception? exception = null;
                T? value = default;

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        break;

                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        string propertyName = reader.GetString()!;
                        reader.Read();

                        switch (propertyName)
                        {
                            case "isSuccess":
                                isSuccess = reader.GetBoolean();
                                break;
                            case "value":
                                value = JsonSerializer.Deserialize<T>(ref reader, options);
                                break;
                            case "exception":
                                var errorMessage = reader.GetString();
                                if (errorMessage != null)
                                    exception = new Exception(errorMessage);
                                break;
                        }
                    }
                }

                if (isSuccess)
                    return Result.Success(value!);
                else
                    return Result.Failure<T>(exception ?? new Exception("Unknown error"));
            }

            public override void Write(Utf8JsonWriter writer, Result<T> value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                writer.WriteBoolean("isSuccess", value.IsSuccess);

                if (value.IsSuccess)
                {
                    writer.WritePropertyName("value");
                    JsonSerializer.Serialize(writer, value.Value, options);
                }
                else if (value.Exception != null)
                {
                    writer.WritePropertyName("exception");
                    JsonSerializer.Serialize(writer, value.Exception.Message, options);
                }

                writer.WriteEndObject();
            }
        }
    }
}
