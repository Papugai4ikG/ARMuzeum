using UnityEngine;
using UnityEngine.UI;
using System.IO.Compression;
using easyar;
using System.IO;
using System;
using TMPro;

public class ControllerImageTracking : MonoBehaviour
{
    [SerializeField]
    GameObject point;
    [SerializeField]
    AudioImporter audioImporter;
    [Header("Краткая информация об объектах")]
    [SerializeField]
    GameObject p_spawnInfo;
    [SerializeField]
    Transform posSpawnInfo;
    [Space()]
    [Header("Трекинг изображений")]
    [SerializeField]
    GameObject p_spawnTracker;
    [SerializeField]
    Transform spawnpoint;
    [Space()]
    [Header("Вёрстка")]
    [SerializeField]
    Info Info;
    [SerializeField]
    GameObject panelInfo;
    [Space()]
    [Header("Язык")]
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    UnityEngine.UI.Image image;
    [SerializeField]
    GameObject panelLoad;

    bool isRus = false;
    Texture sprite;
    ImageTrackerFrameFilter imageTrackerFrame;
    ImageTrackingList imageTracking = new ImageTrackingList();

    private void Awake() 
    {
        imageTrackerFrame = FindObjectOfType<ImageTrackerFrameFilter>();
        Tracking(false);
    }
    private async void Start()
    {
        var file = new LoadFromFile();
        
        if (Directory.Exists(Application.persistentDataPath + "/Resources/muzeum/" + PlayerPrefs.GetString("name")))
        {
            JSON();
        }
        else
        {
            var data = await file.LoadFileWeb(PlayerPrefs.GetString("path"));
            if(!Directory.Exists(Application.persistentDataPath + "/Resources"))
                    Directory.CreateDirectory(Application.persistentDataPath + "/Resources");
            File.WriteAllBytes(Application.persistentDataPath+ "/Resources/"+ PlayerPrefs.GetString("name")+".zip", data);
            ZipFileArhive();
        }
    }
    
    private void ZipFileArhive()
    {
        try
        {
            ZipFile.ExtractToDirectory(Application.persistentDataPath + "/Resources/" + PlayerPrefs.GetString("name") + ".zip",Application.persistentDataPath + "/Resources/");
            FileInfo fileInf = new FileInfo(Application.persistentDataPath + "/Resources/" + PlayerPrefs.GetString("name") + ".zip");
            fileInf.Delete();
            JSON();
            PlayerPrefs.SetInt("Flag", 0);
        }
        catch (Exception e)
        {
            panelLoad.GetComponentInChildren<Text>().text = e.Message;
        }
        
    }
    public void OnClickFlagSwith()
    {
        if (isRus)
        {
            image.sprite = sprites[0];
            isRus = false;
            PlayerPrefs.SetInt("Flag", 0);
        }
        else
        {
            image.sprite = sprites[1];
            isRus = true;
            PlayerPrefs.SetInt("Flag", 1);
        }
    }

    void CreaterImageTrackings()
    {
        var file = new LoadFromFile();
        for (int i = 0; i < imageTracking.Image.Length; i++)
        {
            var go = Instantiate(p_spawnTracker, spawnpoint);
            go.transform.position = Vector3.zero;
            go.AddComponent<ImageTargetController>();
            var path = Application.persistentDataPath + "/Resources/"+"muzeum/"+ PlayerPrefs.GetString("name");
            var im = new EAController(go.GetComponent<ImageTargetController>(),PathType.Absolute,
                                    path+ "/Excursion/imageTracking/" + imageTracking.Image[i].imageTracking+ ".jpg",
                                    imageTrackerFrame);
            imageTrackerFrame.LoadTarget(go.GetComponent<ImageTargetController>());
            sprite = file.LoadImageFile(path+"/" +imageTracking.Image[i].imageUrl);
            go.AddComponent<ImageController>().InfoCreater(Info, imageTracking.Image[i],sprite,audioImporter,point);
            SpawnInformation(sprite, imageTracking.Image[i].headerRu, imageTracking.Image[i].despRu);
        }
        panelLoad.SetActive(false);
        Tracking(true);
    }
    public void SpawnInformation(Texture texture,string header, string desp)
    {
        var go = Instantiate(p_spawnInfo, posSpawnInfo);
        go.GetComponent<InfoMuzeum>().InfoMuzeums(texture, header, desp);
    }
 
    private async void  JSON()
    {
        var jsonClient = new GetSetJsonFile(new JsonSerializationOption());
        imageTracking = await jsonClient.JSON<ImageTrackingList>("file://"+Application.persistentDataPath + "/Resources/muzeum/"+ PlayerPrefs.GetString("name")+ "/Excursion/ImageTracking.json");
        CreaterImageTrackings();
    }

    private void Tracking(bool on)
    {
        imageTrackerFrame.enabled=on;
    }
}
[System.Serializable]
public class Info
{
    public RawImage[] Image;
    public TMP_Text[] header;
    public TMP_Text[] desctop;
    public AudioSource audio;
    public UnityEngine.Video.VideoPlayer clip;
    public GameObject VideoPanel;
    public GameObject AudioPanel;
    public GameObject panel;
}
