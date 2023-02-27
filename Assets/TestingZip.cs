using UnityEngine;
using System.Net;
using System.IO.Compression;
public class TestingZip : MonoBehaviour
{
    
    private void Start()
    {
        Download();
    }

    async void Download()
    {
        WebClient webClient = new WebClient();
        await webClient.DownloadFileTaskAsync("https://dl.dropbox.com/s/7abc9abudt9nyyd/muzeum.zip", Application.streamingAssetsPath + "/Resources/muzeum.zip");
        NewMethod();
    }
    private void NewMethod()
    {
        ZipFile.ExtractToDirectory(Application.streamingAssetsPath + "/Resources/muzeum.zip", Application.streamingAssetsPath + "/Resources/");
        Debug.Log("OK");
    }
}
