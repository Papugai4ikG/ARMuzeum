using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetSetJsonFile
{ 
    public ISerializationOption _serializationOption { get; }
    public GetSetJsonFile(ISerializationOption serializationOption)
    {
            _serializationOption = serializationOption;

    }
    public async Task<TResultType> JSON<TResultType>(string url)
    {
        try{
            using var www = UnityWebRequest.Get(url);
            www.SetRequestHeader("Content-Type", "application/json");

            var operation = www.SendWebRequest();
            
            while (!operation.isDone)
            {
                await Task.Yield();
            }
            var jsonHandler = www.downloadHandler.text;
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            var jsonFile = _serializationOption.Deserialize<TResultType>(www.downloadHandler.text);
            return jsonFile;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
            return default;
        }
    }
}
