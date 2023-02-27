using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoadTargetImage : MonoBehaviour
{
    GameObject obj;
    void  OnEnable()
    {
        if (!GetComponentInChildren<Canvas>()||!GetComponentInChildren<Canvas>().gameObject.activeSelf)
        {
            return;
        }
        if(obj == null)
            obj = GameObject.FindGameObjectWithTag("Menu");
        obj.SetActive(false);
    }

    private void OnDisable()
    {
        if (obj != null)
            obj.SetActive(true);
    }
}
