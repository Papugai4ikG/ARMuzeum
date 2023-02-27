using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class JsonSerializationOption : ISerializationOption
{
    public T Deserialize<T>(string text)
    {
        try
        {
            var jsonFile = JsonUtility.FromJson<T>(text);
            return jsonFile;
        }
        catch (System.Exception e)
        {
            Debug.LogError(text);
            return default;
        }
    }
}