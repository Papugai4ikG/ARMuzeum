using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;
using TMPro;
public class MenuSystem : MonoBehaviour
{
    [SerializeField]
    InfoMenu info;
    [SerializeField]
    GameObject spawnMuz;
    [SerializeField]
    Transform pos;
    [SerializeField]
    UnityEvent panelEnables;
    [SerializeField]
    GameObject buttVse;
    
    RawImage image;
    List<GameObject> gameObjects = new List<GameObject>();
    JsonMuzeumsList imageTracking = new JsonMuzeumsList();
    TMP_Text header;
    private async void Start()
    {
        string url = "https://dl.dropboxusercontent.com/s/ml84cy8k44cwdgv/muzeumJson.json";
        var jsonClient = new GetSetJsonFile(new JsonSerializationOption());
        imageTracking = await jsonClient.JSON<JsonMuzeumsList>(url);
        MenuCreater();
    }
    async void MenuCreater()
    {
        var _imageDownload = new LoadFromFile();
        foreach (var item in imageTracking.muzeums)
        {
            var go = Instantiate(spawnMuz, pos);
            gameObjects.Add(go);
            image = go.GetComponentInChildren<RawImage>();
            header = go.GetComponentInChildren<TMP_Text>();
            image.texture = await _imageDownload.LoadImageWeb(item.url_image);
            header.text = item.header;
            go.GetComponent<Button>().onClick.AddListener(()=>
            {
                panelEnables.Invoke();
                info.Creater(go.GetComponentInChildren<RawImage>().texture,item);
            });
        }
        Search(buttVse);
    }

    public void Search(GameObject gameObject)
    {
        //D9D9D9
        buttVse.GetComponentInChildren<TMP_Text>().color = new Color(0, 0, 0, 0.5f);
        buttVse.GetComponent<Unity.VectorGraphics.SVGImage>().color = new Color(0.8509804f,0.8509804f,0.8509804f,1f);
        var text = gameObject.GetComponentInChildren<TMP_Text>();
        var image = gameObject.GetComponent<Unity.VectorGraphics.SVGImage>();
        image.color = new Color(1,1,1,1);
        text.color = new Color(0, 0, 0, 1);
        buttVse = gameObject;
        if (text.text !="Все")
            foreach (var item in gameObjects)
            {
                foreach (var city in imageTracking.muzeums)
                {
                    if (city.city == text.text&&item.GetComponentInChildren<TMP_Text>().text == city.header)
                    {
                        
                        item.SetActive(true);
                        break;
                    }
                    else
                    {
                        item.SetActive(false);
                    }
                }
            }
        else
            foreach (var item in gameObjects)
            {
                item.SetActive(true);
            }

    }
}
