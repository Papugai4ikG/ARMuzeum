using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

delegate string QuestTexters(string s);

public class ControllInfo : MonoBehaviour
{
    [SerializeField]
    Sprite _complete;
    [SerializeField]
    TMP_Text t_questInfo;
    //[SerializeField]
    //RawImage ImageTrack;
    [SerializeField]
    TMP_Text _text;
    [SerializeField]
    GameObject SecretCode;
    [SerializeField]
    GameObject WinPanel;
    [SerializeField]
    public List<InfoController> infoControllers = new List<InfoController>();
    QuestCode questCode = new QuestCode();
    QuestSuperfluous questSuperfluous = new QuestSuperfluous();
    QuestTexters[] questTexters;
    string[] questInfo;
    string names;
   
    int count = 0;
    private void Start() {
        AddListQuest();
    }
    public void OnNext() 
    {
        if (count >= 1)
        {
            infoControllers[count-1].Check.GetComponent<Image>().sprite = _complete;
            infoControllers[count-1].Check.GetComponentInChildren<TMP_Text>().enabled = false;
        }
        if (count >= infoControllers.Count)
        {
            WinPanel.SetActive(true);
            return;
        }
        _text.text = "";
        infoControllers[count].Check.GetComponent<Image>().color = Color.white;
        infoControllers[count].pref.gameObject.SetActive(true);
        //ImageTrack.texture = infoControllers[count].texture;
        names = infoControllers[count].code;
        var rand = UnityEngine.Random.Range(0,questTexters.Length-1);
        t_questInfo.text = questInfo[rand];
        var q =questTexters[rand](names.ToString());
        _text.text = q;
        count += 1;
        SecretCode.SetActive(true);
    }

    private void AddListQuest()
    {
        questTexters = new QuestTexters[]
        {
            questCode.QuestAlphabet.alphabetNum,
            questCode.QuestClaviature.ClaviatureENG,
            questCode.QuestClaviature.ClaviatureNum,
            questCode.QuestCaesar.getCaesar,
            questSuperfluous.QuestWordNumber.GetWordNumber,
            questSuperfluous.QuestWordAlphabet.GetWordAlphabet,
            questCode.QuestBrouler.GetMorze
        };
        questInfo = new string[]
        {
            questCode.QuestAlphabet.InfoQuest,
            questCode.QuestClaviature.InfoQuest,
            questCode.QuestClaviature.InfoQuest,
            questCode.QuestCaesar.InfoQuest,
            questSuperfluous.GetinfoQuest,
            questSuperfluous.GetinfoQuest,
            questCode.QuestBrouler.GetinfoQuest
        };
    }
    public void OnCodeEnter(InputField inputField)
    {
        if (inputField.text == "")
            return;
        if(names.ToLower() == inputField.text.ToLower())
        {
            inputField.text = "";
            SecretCode.SetActive(false);
        }
        else
        {
            inputField.text = "";
        }
    }
}
[System.Serializable]
public class InfoController
{
    public int id = 0;
    public string code;
    public GameObject pref;
    public GameObject Check;
    public Texture texture;
    public InfoController(int id,string code,GameObject gameObject,GameObject Image,Texture texture)
    {
        this.id = id;
        this.code = code;
        pref = gameObject;
        this.Check = Image;
        this.texture = texture;
    }
   
}
