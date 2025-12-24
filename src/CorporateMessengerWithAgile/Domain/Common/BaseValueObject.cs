namespace Domain.Common;

/// <summary>
/// Базовый класс для объектов-значений (Value Objects) в Domain-Driven Design.
/// Объекты-значения идентифицируются по их свойствам, а не по идентификатору.
/// </summary>
public abstract class BaseValueObject<TValue> : IEquatable<BaseValueObject<TValue>>
{
    public TValue Value { get; protected set; }

    protected BaseValueObject(TValue value)
    {
        Value = value;
    }

    /// <summary>
    /// Возвращает значения всех свойств объекта-значения.
    /// </summary>
    /// <returns>Коллекция значений свойств.</returns>
    public virtual IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    /// <summary>
    /// Сравнивает текущий объект-значение с другим объектом-значением.
    /// </summary>
    /// <param name="other">Другой объект-значение для сравнения.</param>
    public bool Equals(BaseValueObject<TValue>? other)
    {
        return other is not null && ValuesAreEqual(other);
    }

    /// <summary>
    /// Сравнивает текущий объект-значение с другим объектом.
    /// </summary>
    /// <param name="obj">Другой объект для сравнения.</param>
    public override bool Equals(object? obj)
    {
        return obj is BaseValueObject<TValue> other && ValuesAreEqual(other);
    }

    /// <summary>
    /// Вычисляет хэш-код на основе значений свойств объекта-значения.
    /// </summary>
    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(
                default(int),
                HashCode.Combine);
    }

    /// <summary>
    /// Проверяет, равны ли значения свойств текущего объекта и другого объекта-значения.
    /// </summary>
    private bool ValuesAreEqual(BaseValueObject<TValue> other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }
}