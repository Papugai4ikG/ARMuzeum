using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLoadScene : MonoBehaviour
{
    private InputSystemNew inputActions;
    private void Awake() 
    {
        inputActions = new InputSystemNew();
        inputActions.UI.Cancel.performed+=content => Back();
        if(SceneManager.GetActiveScene().buildIndex==0&&easyar.EasyARController.Initialized)
        {
            easyar.EasyARController.Deinitialize();
        }
    }
    private void OnEnable() {
        inputActions.Enable();
    }
    private void OnDisable() {
        inputActions.Disable();
    }
    private void Back()
    {
        if (SceneManager.GetActiveScene().buildIndex!=0)
        {
            SceneManager.LoadScene(0);
        }
    }
   public void OnLoadEnter(int numberLoad)
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(numberLoad);
    }
    public void OnExit()
    {
        Application.Quit();
    }
    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
