using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField]
    private InputSystemNew inputActions;
private void Awake() {
    inputActions = new InputSystemNew();
}
private void OnDisable() {
    inputActions.Enable();
}
private void OnEnable() {
    inputActions.Disable();
}
}
