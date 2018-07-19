public class RequestParameterCollection
{
    public abstract bool ContainsKey(string key);

    public abstract string GetValue(string key);
}

public class UrlFormEncodedRequestParameterCollection : RequestParameterCollection
{
     public override bool ContainsKey(string key)
    {
        throw new NotImplementedException();
    }

    public override string GetValue(string key)
    {
        throw new NotImplementedException();
    }
}