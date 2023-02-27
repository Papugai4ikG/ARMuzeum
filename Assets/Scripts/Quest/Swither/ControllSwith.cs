using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllSwith : MonoBehaviour
{
    [SerializeField]
    GameObject _panel;
    [SerializeField]
    GameObject p_spawn;
    [SerializeField]
    Texture2D texture;
    ControllInfo ControllInfo;
    bool isWin=false;
    List<GameObject> l_spawns = new List<GameObject>();
    List<Sprite> l_sprites = new List<Sprite>();
    easyar.ImageTargetController targetController;
    private void OnEnable() 
    {
        if(_panel.GetComponent<RectTransform>().sizeDelta.x<=0 && texture !=null){
            _panel.GetComponent<RectTransform>().sizeDelta = targetController.Size;
        }
    }
    public void CheckPosition()
    {
        foreach (var item in l_spawns)
        {
            if (Mathf.Abs(item.transform.localRotation.w) != 1)
                return;
        }
        isWin = true;
        ControllInfo.OnNext();
    }
    public bool Win() => isWin;
    public void StartQuest(Texture2D texture,Vector2 vector2,ControllInfo info,easyar.ImageTargetController controller)
    {
        this.texture = texture;
        targetController = controller;
        ControllInfo = info;
        SpriteSlice(vector2);
        for (int i = 0; i < vector2.x*vector2.y; i++)
        {
            var p = Instantiate(p_spawn, transform);
            l_spawns.Add(p);
            p.AddComponent<Swith>();
        }
        for (int i = 0; i < l_spawns.Count; i++)
        {
            l_spawns[i].GetComponent<Image>().sprite = l_sprites[i];
        }
        _panel.GetComponent<Canvas>().worldCamera = Camera.main;
        _panel.SetActive(false);
    }

    void SpriteSlice(Vector2 vector2)
    {
        var x = 0.0f;
        var y = 0.0f;
        var MinX = texture.width / vector2.x;
        var MinY = texture.height / vector2.y;

        for (int i = 0; i < vector2.y; i++)
        {
            for (int k = 0; k < vector2.x; k++)
            {
                l_sprites.Add(Sprite.Create(texture, new Rect(x, y, MinX, MinY), new Vector2(0.5f, 0.5f), 100));
                x += MinX;
            }
            x =0;
            y += MinY;
        }
    }
}
