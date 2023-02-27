using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[System.Serializable]
public class ImageTrackings 
{
    public string imageTracking;
    public string imageUrl;
    public string headerRu;
    public string headerEn;
    public string despRu;
    public string despEn;
    public string audioRu;
    public string audioEn;
    public string video;
}
[System.Serializable]
public class ImageTrackingList
{
   public ImageTrackings[] Image;
}
