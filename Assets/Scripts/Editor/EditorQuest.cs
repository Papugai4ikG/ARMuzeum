using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
[CustomEditor(typeof(ItemTrackingQuest))]
public class EditorQuest : Editor
{
    ItemTrackingQuest item;
    private void OnEnable()
    {
        item = (ItemTrackingQuest) target;
    }
    public override void OnInspectorGUI()
    {
        item.name = EditorGUILayout.TextField("Наименование", item.name);
        item.QuestPrefabs = (GameObject)EditorGUILayout.ObjectField("Головоломка", item.QuestPrefabs, typeof(GameObject), false);
        item.TextureSwitsh = (Texture2D)EditorGUILayout.ObjectField("Изображение", item.TextureSwitsh, typeof(Texture2D), false);
        item.text = EditorGUILayout.TextField("Код", item.text);
        if (GUI.changed)
        {
            EditorUtility.SetDirty(item);
            EditorSceneManager.MarkAllScenesDirty();
        }
    }
}
