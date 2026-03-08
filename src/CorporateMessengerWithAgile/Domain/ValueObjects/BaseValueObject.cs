namespace Domain.ValueObjects;

/// <summary>
/// Базовый класс для объектов-значений (Value Objects) в Domain-Driven Design.
/// Объекты-значения идентифицируются по их свойствам, а не по идентификатору.
/// </summary>
public abstract class BaseValueObject<TValue>(TValue value)
    : IEquatable<BaseValueObject<TValue>>
    where TValue : notnull
{
    public TValue Value { get; init; } = value;

    /// <summary>
    /// Сравнивает текущий объект-значение с другим объектом-значением.
    /// </summary>
    /// <param name="other">Другой объект-значение для сравнения.</param>
    public bool Equals(BaseValueObject<TValue>? other)
        => other is not null && GetType() == other.GetType() && Value.Equals(other.Value);

    /// <summary>
    /// Сравнивает текущий объект-значение с другим объектом.
    /// </summary>
    /// <param name="obj">Другой объект для сравнения.</param>
    public override bool Equals(object? obj)
        => obj is not null && obj is BaseValueObject<TValue> valueObject && Equals(valueObject);


    /// <summary>
    /// Вычисляет хэш-код на основе значения свойства объекта-значения.
    /// </summary>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Value);

    public static bool operator ==(BaseValueObject<TValue>? left, BaseValueObject<TValue>? right)
        => left is null ? right is null : left.Equals(right);
    public static bool operator !=(BaseValueObject<TValue>? left, BaseValueObject<TValue>? right)
        => !(left == right);

    public static implicit operator TValue(BaseValueObject<TValue> valueObject) => valueObject.Value;
}
