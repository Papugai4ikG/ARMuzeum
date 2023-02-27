using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Item",menuName ="Trackings/Quest")]
public class ItemTrackingQuest : ScriptableObject
{
    public string name;
    public GameObject QuestPrefabs;
    public Texture2D TextureSwitsh;
    public string text;
}
