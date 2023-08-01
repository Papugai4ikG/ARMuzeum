using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class LoadFromFile
{
    AudioClip clip;
    public Texture2D LoadImageFile(string url)
    {
        if(!File.Exists(url))
            return null;
        byte[] textureBytes = File.ReadAllBytes(url);
        Texture2D texture = new Texture2D(0,0);
        texture.LoadImage(textureBytes);
        return texture;
    }

    public async Task<Texture> LoadImageWeb(string url)
    {
        try{
            using var www = UnityWebRequestTexture.GetTexture(url);

            var operation = www.SendWebRequest();
            while (!operation.isDone)
            {
                await Task.Yield();
            }
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            
            return texture ;
        }
        catch (System.Exception e)
        {
            return default;
        }
    }
    public async Task <AudioClip> LoadMusicWeb(string url)
    {
        try{
            using var www = UnityWebRequestMultimedia.GetAudioClip("file:///"+url,AudioType.MPEG);

            var operation = www.SendWebRequest();
            
            while (!operation.isDone)
            {
                await Task.Yield();
            }
            var audio = ((DownloadHandlerAudioClip)www.downloadHandler).audioClip;
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            
            return audio ;
        }
        catch (System.Exception e)
        {
            return default;
        }
    }
    public async Task <byte[]> LoadFileWeb(string url)
    {
        try{
            using var www = UnityWebRequest.Get(url);

            var operation = www.SendWebRequest();
            
            while (!operation.isDone)
            {
                await Task.Yield();
            }
            var file = www.downloadHandler.data;
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            
            return file;
        }
        catch (System.Exception e)
        {
            return default;
        }
    }
}
