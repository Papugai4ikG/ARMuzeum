using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using easyar;
using System.IO.Compression;
using System;

public class ImageTrackingQuest : MonoBehaviour
{
    [SerializeField]
    GameObject ImageComplate;
    [SerializeField]
    Transform tracking;
    [SerializeField]
    GameObject TextureSwitsh;
    [SerializeField]
    GameObject panelLoad;
    [SerializeField]
    ControllInfo controllInfo;
    ImageTrackerFrameFilter imageTrackerFrame;
    [SerializeField]
    GameObject spawn;
    [SerializeField]
    Transform spawnpoint;
    Texture2D texture2D;
    int count = 0;

    private void Start()
    {
        imageTrackerFrame = FindObjectOfType<ImageTrackerFrameFilter>();
        Download();
    }
    async void Download()
    {
        if (Directory.Exists(Application.persistentDataPath + "/Resources/muzeum/" + PlayerPrefs.GetString("name")))
        {
            JSON();
        }
        else
        {
            var d = new LoadFromFile();
            if (!Directory.Exists(Application.persistentDataPath + "/Resources"))
                Directory.CreateDirectory(Application.persistentDataPath + "/Resources");
            File.WriteAllBytes(Application.persistentDataPath + "/Resources/" + PlayerPrefs.GetString("name") + ".zip", await d.LoadFileWeb(PlayerPrefs.GetString("path")));
            ZipArchive();
        }
    }
    void Json(QuestList questList)
    {
        var countValue = 100 / questList.Quest.Length;
        var _imageDownload = new LoadFromFile();
        foreach (var item in questList.Quest)
        {
            var _img = Instantiate(ImageComplate, tracking);
            var image = Application.persistentDataPath + "/Resources/" + "muzeum/" + PlayerPrefs.GetString("name") + "/Quest/image/" + item.texture;
            var go = Instantiate(spawn, spawnpoint);
            go.AddComponent<ImageTargetController>();
            go.AddComponent<OnLoadTargetImage>();
            var im = new EAController(
            go.GetComponent<ImageTargetController>(),
            PathType.Absolute,
            Application.persistentDataPath + "/Resources/" + "muzeum/" + PlayerPrefs.GetString("name") + "/Quest/imageTracking/" +item.name,
            imageTrackerFrame);
            imageTrackerFrame.LoadTarget(go.GetComponent<ImageTargetController>());
            var pref = Instantiate(TextureSwitsh, go.transform);
            texture2D = _imageDownload.LoadImageFile(image);
            go.transform.position = Vector3.zero;
            var prefgo = go.GetComponent<ImageTargetController>();
            pref.GetComponentInChildren<ControllSwith>().StartQuest(texture2D, new Vector2(3,3),controllInfo,prefgo);
            controllInfo.infoControllers.Add(new InfoController(count, item.code, pref,_img,texture2D));
            count++;
        }
        controllInfo.OnNext();
        panelLoad.SetActive(false);
    }
    private async void JSON()
    {
        string url = "file://" + Application.persistentDataPath + "/Resources/muzeum/" + PlayerPrefs.GetString("name") + "/Quest/QuestTracking.json";
        var jsonClient = new GetSetJsonFile(new JsonSerializationOption());
        var imageTracking = await jsonClient.JSON<QuestList>(url);
        Json(imageTracking);
    }
    private void ZipArchive()
    {
        try
        {
            ZipFile.ExtractToDirectory(Application.persistentDataPath + "/Resources/" + PlayerPrefs.GetString("name") + ".zip", Application.persistentDataPath + "/Resources/");
            FileInfo fileInf = new FileInfo(Application.persistentDataPath + "/Resources/" + PlayerPrefs.GetString("name") + ".zip");
            fileInf.Delete();
            JSON();
        }
        catch (Exception e)
        {
            panelLoad.GetComponentInChildren<Text>().text = e.Message;
        }
    }
}
