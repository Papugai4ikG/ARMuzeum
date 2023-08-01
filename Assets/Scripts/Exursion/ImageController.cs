using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using TMPro;

public class ImageController : MonoBehaviour
{
    AudioImporter audioImporter;
    Info frontend = new Info();
    ImageTrackings backendJSON = new ImageTrackings();
    Texture image = null;
    GameObject _point;

    Vector3 _pointV= new Vector3(8,8,8);

    public void InfoCreater(Info info,ImageTrackings trackings,Texture images,AudioImporter import,GameObject point)
    {
        frontend = info;
        backendJSON = trackings;
        image = images;
        audioImporter=import;
        _point = point;
    }
    private void OnEnable()
    {
        if (_point ==null) return;
        _point.SetActive(true);
        InfoStart();
        frontend.panel.SetActive(false);
    }
    private void OnDisable()
    {
        if (_point==null) return;
        _point.SetActive(false);
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
            if (backendJSON.audioRu != null)
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
            if (backendJSON.audioEn != null)
                frontend.AudioPanel.SetActive(true);
            else
                frontend.AudioPanel.SetActive(false);
        }
    }

    private void Update() {
        if(_point.activeSelf==false)
            return;
        _point.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z-2);
        float distance = Vector3.Distance(Camera.main.transform.position, transform.position);
        Debug.Log(distance);
        if(distance>500)
            {
                _point.transform.localScale = _pointV;
                _point.transform.localScale = 
                new Vector3(_point.transform.localScale.x+4,
                        _point.transform.localScale.y+4,
                        _point.transform.localScale.z+4);
            }
        else
            _point.transform.localScale = new Vector3(8,8,8);
    }
    void OnLoaded(AudioClip clip)
    {
        frontend.audio.clip = clip;
    }
}

