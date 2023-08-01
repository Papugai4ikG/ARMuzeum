using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class WindowFocus : MonoBehaviour,IClickable
{
    [SerializeField]
    UnityEvent eventsStart;
    [SerializeField]
    UnityEvent eventsStop;
    [SerializeField]
    InputAction click;
    bool isActive=true;
    public void OnClick()
{
    eventsStart?.Invoke();
}
private void OnDisable()
{
    eventsStop?.Invoke();
}
 void Awake() 
    {
        click = new InputAction(binding: "<Touchscreen>/press");
        click.performed += ctx => {
            RaycastHit hit; 
            Vector3 coor = Touchscreen.current.position.ReadValue();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(coor), out hit)) 
            {
                OnClick();
            }
        };
        click.Enable();
    }
}

