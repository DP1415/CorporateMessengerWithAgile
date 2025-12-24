using System.Text.Json.Serialization;
using System.Text.Json;

namespace Domain.ValueObjects
{
    // Универсальный конвертер
    public class ValueObjectJsonConverter<TValueObject, TValue> : JsonConverter<TValueObject>
        where TValueObject : BaseValueObject<TValue>
    {
        public override TValueObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new Exception();
        }

        public override void Write(Utf8JsonWriter writer, TValueObject value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }

    public class ValueObjectJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            // Проверяем, является ли тип наследником ValueObject<>
            return typeToConvert.IsClass &&
                   !typeToConvert.IsAbstract &&
                   typeToConvert.BaseType?.IsGenericType == true &&
                   typeToConvert.BaseType.GetGenericTypeDefinition() == typeof(BaseValueObject<>);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            // Получаем тип значения (TValue) из ValueObject<TValue>
            var valueType = typeToConvert.BaseType?.GetGenericArguments()[0];

            // Создаем generic тип конвертера
            var converterType = typeof(ValueObjectJsonConverter<,>).MakeGenericType(typeToConvert, valueType);

            return (JsonConverter)Activator.CreateInstance(converterType);
        }
    }

    //public class ValueObjectJsonConverter<TValueObject, TValue> : JsonConverter<TValueObject>
    //    where TValueObject : ValueObject<TValue>
    //{
    //    public override TValueObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        // Для десериализации нам нужен фабричный метод, но его нет в базовом классе
    //        // Поэтому выбрасываем исключение - десериализация требует специфичной реализации
    //        throw new NotSupportedException($"Deserialization of {typeof(TValueObject).Name} is not supported. Use specific value object converters instead.");
    //    }

    //    public override void Write(Utf8JsonWriter writer, TValueObject value, JsonSerializerOptions options)
    //    {
    //        JsonSerializer.Serialize(writer, value.Value, options);
    //    }
    //}

}
