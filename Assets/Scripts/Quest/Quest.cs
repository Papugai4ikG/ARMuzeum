using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Quest { 

    public string name;
    public string texture;
    public string code;
}
[Serializable]
public class QuestList 
{
    public Quest[] Quest;
}
