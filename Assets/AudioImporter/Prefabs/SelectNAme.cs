using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNAme : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    Browser browser;
    [SerializeField]
    AudioImporter audioImporter;
    // Start is called before the first frame update
    void Start()
    {
        browser.FileSelected+=OnFileSelect;
        audioImporter.Loaded+=OnLoaded;
    }
    void OnFileSelect(string path){
        audioImporter.Import(path);
    }
    private void OnLoaded(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
