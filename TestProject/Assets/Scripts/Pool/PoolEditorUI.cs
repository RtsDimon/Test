using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using DimonPool;
[CustomEditor(typeof(PoolMain))]
public class PoolEditorUI : Editor
{
    private PoolMain menu;

    public void OnEnable()
    {
        menu = (PoolMain)target;
    }
    public override void OnInspectorGUI()
    {

        foreach (var pool in menu.pools)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.TextField("tag",pool.tag);
            pool.prefab = (PoolObject)EditorGUILayout.ObjectField("prefab", pool.prefab, typeof(PoolObject), false);
            EditorGUILayout.IntField("size", pool.size);
            EditorGUILayout.EndVertical();

            if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.Height(20)))
            {
                menu.pools.Remove(pool);
                break;
            }
            EditorGUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Add"))
        {
            menu.pools.Add(new PoolMain.Pool());
        }
        if (GUI.changed)
            SetObjectDirty(menu.gameObject);
    }
    public static void SetObjectDirty(GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);
    } 

}
[InitializeOnLoad]
public class PoolHighlighter // Подсветка пула в иерархии
{

    static PoolHighlighter()
    {
        EditorApplication.hierarchyWindowItemOnGUI += Highlighter;
    }

    private static void Highlighter(int selectionID, Rect selectionRect)
    {
        Object o = EditorUtility.InstanceIDToObject(selectionID);
        if (o)
        {
            PoolMain pool = (o as GameObject).GetComponent<PoolMain>();
            if (pool)
            {
                if (Event.current.type == EventType.Repaint)
                {
                    EditorGUI.DrawRect(selectionRect, new Color32(0, 255, 150, 80));
                }
            }
        }

    }

}
#endif
