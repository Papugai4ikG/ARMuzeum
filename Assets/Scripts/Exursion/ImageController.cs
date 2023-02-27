using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class ImageController : MonoBehaviour
{
    AudioImporter audioImporter;
    GameObject panel = null;
    Info frontend = new Info();
    ImageTrackings backendJSON = new ImageTrackings();
    Texture image = null;

    public void InfoCreater(GameObject menu,Info info,ImageTrackings trackings,Texture images,AudioImporter import)
    {
        panel = menu;
        frontend = info;
        backendJSON = trackings;
        image = images;
        audioImporter=import;
    }
    private void OnEnable()
    {
        if (panel == null)
            return;
        InfoStart();
        panel.SetActive(true);
        frontend.panel.SetActive(false);
    }
    private void OnDisable()
    {
        if (panel == null)
            return;
        panel.SetActive(false);
        frontend.panel.SetActive(true);
    }
    void  InfoStart()
    {
        var path = Application.persistentDataPath + "/Resources/"+"muzeum/"+ PlayerPrefs.GetString("name");
        audioImporter.Loaded +=OnLoaded;
        if (PlayerPrefs.GetInt("Flag") == 0)
        {
            foreach (var item in frontend.desctop)
            {
                item.text = backendJSON.despRu;
            }
            foreach (var item in frontend.header)
            {
                item.text = backendJSON.headerRu;
            }
            foreach (var item in frontend.Image)
            {
                item.texture = image;
            }
            if (backendJSON.video != "")
            {
                frontend.VideoPanel.SetActive(true);
                frontend.clip.source = UnityEngine.Video.VideoSource.Url;
                frontend.clip.url = Application.persistentDataPath + "/Resources/muzeum/" + PlayerPrefs.GetString("name") + "/"+backendJSON.video;
            }
            else
                frontend.VideoPanel.SetActive(false);
            audioImporter.Import(path +"/"+ backendJSON.audioRu);
            if (frontend.audio.clip != null)
                frontend.AudioPanel.SetActive(true);
            else
                frontend.AudioPanel.SetActive(false);
        }
        else
        {
            foreach (var item in frontend.desctop)
            {
                item.text = backendJSON.despEn;
            }
            foreach (var item in frontend.header)
            {
                item.text = backendJSON.headerEn;
            }
            foreach (var item in frontend.Image)
            {
                item.texture = image;
            }
            if (backendJSON.video != "")
            {
                frontend.VideoPanel.SetActive(true);
                frontend.clip.source = UnityEngine.Video.VideoSource.Url;
                frontend.clip.url = backendJSON.video;
            }
            else
                frontend.VideoPanel.SetActive(false);

            audioImporter.Import(path +"/"+ backendJSON.audioEn);
            if (frontend.audio.clip != null)
                frontend.AudioPanel.SetActive(true);
            else
                frontend.AudioPanel.SetActive(false);
        }
    }

    void OnLoaded(AudioClip clip)
    {
        frontend.audio.clip = clip;
    }
}

