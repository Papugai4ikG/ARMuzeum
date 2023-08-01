using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDetailsPuzzle : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    private RectTransform draging;
    private bool isfinish = false;
    private GameObject form;
    private int id;
    PuzzleCreater puzzleCreater;
    private Vector3 velocity = Vector3.zero;

    void Start(){
        draging = transform as RectTransform;
        puzzleCreater = GameObject.FindObjectOfType<PuzzleCreater>();
    }
    public bool isFinish()=>isfinish;
    public void Controller(int id,GameObject form)
    {
        this.id = id;
        this.form = form;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(isfinish)return;
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle(draging,
        eventData.position,eventData.pressEventCamera,out var globalMousePosition))
        {
            draging.position = Vector3.SmoothDamp(draging.position,globalMousePosition,ref velocity,.05f); 
        }
    }
     public void OnEndDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x)<=5f&&
           Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y)<=5f)
           {
            this.transform.position = new Vector2(form.transform.position.x,form.transform.position.y);
            isfinish = true;
            this.gameObject.SetActive(false);
            form.GetComponent<UnityEngine.UI.Image>().color = new Color(1,1,1,1);
            form.GetComponent<UnityEngine.UI.Image>().sprite = this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite;
            puzzleCreater.WinCheck();
           }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("NO");
    }
}
