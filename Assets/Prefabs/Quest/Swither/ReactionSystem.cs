using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionSystem : MonoBehaviour
{
    [SerializeField]
    GameObject _pref;
    ControllInfo ControllInfo;
    List<GameObject> spawns = new List<GameObject>();

    public void StartQuest()
    {
       var count= Random.Range(4, 10);

        for (int i = 0; i < count; i++)
        {
           spawns.Add(Instantiate(_pref, transform));
           spawns[i].GetComponentInChildren<Text>().text = (i+1).ToString();
        }
        foreach (var item in spawns)
        {
            Vector3 vec = new Vector3(30, 30, 0);
            for (int i = 0; i < Random.Range(0,3); i++)
            {
                item.transform.position += new Vector3(30,0,0);
            }
            for (int x = 0; x < Random.Range(0, 3); x++)
            {
                item.transform.position += new Vector3(0, 30, 0);
            }
            item.GetComponent<Button>().onClick.AddListener(() =>
            {
                spawns.Remove(item);
                Destroy(item);
                OnWin();
            });
        }
        ControllInfo = FindObjectOfType<ControllInfo>();
    }

    void OnWin()
    {
        if (spawns.Count <= 0)
        {
            ControllInfo.OnNext();
        }
    }

}
