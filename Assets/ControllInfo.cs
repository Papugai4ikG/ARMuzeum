using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

delegate string QuestTexters(string s);

public class ControllInfo : MonoBehaviour
{
    [SerializeField]
    Text t_questInfo;
    [SerializeField]
    RawImage ImageTrack;
    [SerializeField]
    Text _text;
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
    string name;
   
    int count = 0;
    private void Start() {
        AddListQuest();
    }
    public void OnNext() 
    {
        if (count >= 1)
        {
            infoControllers[count-1].Check.GetComponent<Image>().color = Color.green;
        }
        if (count >= infoControllers.Count)
        {
            WinPanel.SetActive(true);
            return;
        }
        infoControllers[count].pref.SetActive(true);
        infoControllers[count].Check.GetComponent<Image>().color = Color.white;
        ImageTrack.texture = infoControllers[count].texture;
        name = infoControllers[count].code;
        var rand = UnityEngine.Random.Range(0,questTexters.Length-1);
        t_questInfo.text = questInfo[rand];
        _text.text = questTexters[rand](Convert.ToString(name));
        count += 1;
        SecretCode.SetActive(true);
    }

    private void AddListQuest()
    {
        questTexters = new QuestTexters[]
        {
            questCode.QuestAlphabet.alphabetNum,
            questCode.QuestCalendare.GetCalendare,
            questCode.QuestClaviature.ClaviatureENG,
            questCode.QuestClaviature.ClaviatureNum,
            questCode.QuestCaesar.getCaesar,
            questSuperfluous.QuestWordNumber.GetWordNumber,
            questSuperfluous.QuestWordAlphabet.GetWordAlphabet
        };
        questInfo = new string[]
        {
            questCode.QuestAlphabet.InfoQuest,
            questCode.QuestCalendare.InfoQuest,
            questCode.QuestClaviature.InfoQuest,
            questCode.QuestClaviature.InfoQuest,
            questCode.QuestCaesar.InfoQuest,
            questSuperfluous.GetinfoQuest,
            questSuperfluous.GetinfoQuest
        };
    }
    public void OnCodeEnter(InputField inputField)
    {
        if (inputField.text == "")
            return;
        if(name.ToLower() == inputField.text.ToLower())
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
