
public struct RefNullable<T>
{
    private T value;

    private bool hasValue;

    public T Value
    {
        get
        {
            if (hasValue)
                return value;
            throw new System.Exception("HasValue must be true");
        }
    }

    public bool HasValue
    {
        get
        {
            return hasValue;
        }
    }

    public RefNullable(T value)
    {
        this.value = value;
        this.hasValue = true;
    }

    public static implicit operator RefNullable<T>(T @value)
    {
        return new RefNullable<T>(value);
    }
}