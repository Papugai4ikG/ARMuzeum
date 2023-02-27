using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
{
    [SerializeField]
    Text header, desp,address;
    [SerializeField]
    RawImage image;
    [SerializeField]
    GameObject exc, quest,site;

    public void Creater(Texture texture,JsonMuzeums item)
    {
        this.header.text = item.header;
        this.desp.text = item.desp;
        image.texture = texture;
        this.address.text ="Адрес: " + address;
        if (item.url_zip_quest == "")
            quest.SetActive(false);
        else
            quest.SetActive(true);

        if(item.url_zip_exc == "")
            exc.SetActive(false);
        else
            exc.SetActive(true);

        ButtonOnClick(exc.GetComponent<Button>(),item.url_zip_exc,1,item.name);
        ButtonOnClick(quest.GetComponent<Button>(),item.url_zip_quest,2,item.name);
        site.GetComponent<Button>().onClick.AddListener(() =>
        {
            Application.OpenURL(item.site);
        });
    }

    private void ButtonOnClick(Button button,string url,int level,string name)
    {
        button.onClick.AddListener(()=>
        {
            PlayerPrefs.SetString("name", name);
            PlayerPrefs.SetString("path", url);
            easyar.EasyARController.Initialize();
            SceneManager.LoadScene(level);
        });
    }
}
