using System;

public interface IRequestParameterCollection
{
    bool ContainsKey(string key);

    string GetValue(string key);
}

public abstract class AbstractRequestParameterCollection : IRequestParameterCollection
{
    public abstract bool ContainsKey(string key);

    public string GetValue(string key)
    {
        if(ContainsKey(key))
        {
            return OnGetValue(key);
        }
        else
        {
            throw new Exception("Key not found");
        }
    }

    protected abstract string OnGetValue(string key);
}

public class JsonRequestParameterCollection : AbstractRequestParameterCollection
{
    public JsonRequestParameterCollection(string parameterPart)
    {
        //todo
        //logica de json
    }
    public override bool ContainsKey(string key)
    {
        //TODO
        return false;
    }

    protected override string OnGetValue(string key)
    {
        //TODO
        return "LOLOLOL";
    }
}

public class RequestParameterCollection : AbstractRequestParameterCollection
{
    private string[] parameters;

    public RequestParameterCollection(string parameterPart)
    {
        this.parameters = parameterPart.Split('&');
    }
    public override bool ContainsKey(string key)//fie monsterId, fie playerId
    {
        foreach (string keyValueParameter in parameters)
        {
            if (keyValueParameter.Trim().StartsWith(key))
            {
                return true;
            }
        }
        return false;
    }

    protected override string OnGetValue(string key)
    {
        foreach (string keyValueParameter in parameters)
        {
            if (keyValueParameter.Trim().StartsWith(key))
            {
                int startIndex = keyValueParameter.IndexOf('=');
                string rawValue = keyValueParameter.Substring(startIndex + 1);

                return rawValue;
            }
        }
        throw new Exception("Key not found!");
    }
}