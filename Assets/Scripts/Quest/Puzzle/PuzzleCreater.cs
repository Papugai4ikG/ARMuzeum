using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PuzzleCreater : MonoBehaviour
{
    
    bool isPlay = false;
    [SerializeField]
    Transform win,detail;
    [SerializeField]
    GameObject _panel;
    [SerializeField]
    GameObject p_spawn;
    [SerializeField]
    Texture2D texture;
    ControllInfo ControllInfo;
    bool isWin=false;
    bool isDraging = false;
    List<GameObject> l_spawns_details = new List<GameObject>();
    List<GameObject> l_spawns_win = new List<GameObject>();
    List<Sprite> l_sprites = new List<Sprite>();
    easyar.ImageTargetController targetController;
    // Start is called before the first frame update

    private void OnEnable() 
    {
        if(_panel.GetComponent<RectTransform>().sizeDelta.x<=0 && texture !=null){
            _panel.GetComponent<RectTransform>().sizeDelta = targetController.Size;
            var x = targetController.Size.x/3;
            var y = targetController.Size.y/3;
            win.gameObject.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(x,y);
            detail.gameObject.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(x,y);
            StartCoroutine(timer());
        }
    }
    IEnumerator timer(){
        yield return new WaitForSeconds(1f);
        if(!isPlay)
        {
            detail.gameObject.GetComponent<UnityEngine.UI.GridLayoutGroup>().enabled = false;
            Shafl();
        } 
        else Shafl();
        isPlay=true;
    }

    void Shafl()
    {
        foreach (var item in detail.gameObject.GetComponentsInChildren<DragDetailsPuzzle>())
        {
            var i = item.gameObject;
            var rand = Random.Range(-90,90);
            var randPos = Random.Range(0,2);
            var rect = i.GetComponent<RectTransform>();
            if(randPos ==0)rect.localPosition = new Vector2(rect.rect.x+rand,rect.rect.y);
            else if(randPos ==1)rect.localPosition = new Vector2(rect.rect.x,rect.rect.y+rand);
            else rect.localPosition = new Vector2(rect.rect.x+rand,rect.rect.y+rand);
        }
    }

    public void WinCheck()
    {
        foreach (var item in detail.gameObject.GetComponentsInChildren<DragDetailsPuzzle>())
        {
            if(!item.isFinish())return;
        }
        ControllInfo.OnNext();
    }
    public bool Win() => isWin;
    async public void StartQuest(Texture2D texture,Vector2 vector2,ControllInfo info,easyar.ImageTargetController controller)
    {
        this.texture = texture;
        targetController = controller;
        ControllInfo = info;
        await SpriteSlice(vector2);
        for (int i = 0; i < vector2.x*vector2.y; i++)
        {
            var p = Instantiate(p_spawn, win);
            p.GetComponent<UnityEngine.UI.Image>().color = new Color(1,1,1,0);
            l_spawns_win.Add(p);
            //p.AddComponent<Swith>();
        }
        for (int i = 0; i < vector2.x*vector2.y; i++)
        {
            var p = Instantiate(p_spawn, detail);
            p.GetComponent<UnityEngine.UI.Image>().sprite = l_sprites[i];
            l_spawns_details.Add(p);
            p.AddComponent<BoxCollider2D>();
            p.AddComponent<DragDetailsPuzzle>().Controller(i,l_spawns_win[i]);
        }
        _panel.GetComponent<Canvas>().worldCamera = Camera.main;
        _panel.SetActive(false);
    }
    
    async Task SpriteSlice(Vector2 vector2)
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
        await Task.Delay(500);
    }
}
