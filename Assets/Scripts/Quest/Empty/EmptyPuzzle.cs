using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPuzzle : MonoBehaviour
{
    ControllInfo ControllInfo;
    bool isPlay = false;
    private void OnEnable() 
    {
        if(isPlay)
        {
            ControllInfo.OnNext();
            gameObject.SetActive(false);
        } 
    }
    public void StartQuest(ControllInfo info)
    {
        ControllInfo = info;
        isPlay = true;
        gameObject.SetActive(false);
    }
}
