using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class AssetBookmarkWindow : EditorWindow
{
    //View
    private ReorderableList _assetListView;

    //Model
    private List<Object> _assetList = new List<Object>();

    private static string _regKey;

    [MenuItem("Window/Asset Bookmark")]
    public static void ShowWindow()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(AssetBookmarkWindow));
        window.minSize = new Vector2(100f, 100f);
        window.titleContent = EditorGUIUtility.TrTextContentWithIcon("Asset Bookmark", "UnityEditor.ConsoleWindow");
    }

    private void Awake()
    {
        _regKey = $"AssetBookmark_At_{Application.dataPath.Split('/')[1]}";

        foreach (var data in EditorPrefs.GetString(_regKey).Split('|'))
        {
            if (string.IsNullOrEmpty(data)) continue;
            var idx = data.Substring(0, data.IndexOf('/'));
            var guid = data.Substring(data.IndexOf('/') + 1);
            _assetList.Add(AssetDatabase.LoadAssetAtPath<Object>(AssetDatabase.GUIDToAssetPath(guid)));
        }
    }

    private void OnEnable()
    {
        _assetListView = new ReorderableList(_assetList, typeof(Object), displayHeader: false, draggable: true, displayAddButton: true, displayRemoveButton: true)
        {
            drawElementCallback = (rect, index, active, focused) =>
            {
                _assetList[index] = EditorGUI.ObjectField(rect, _assetList[index], typeof(Object), false);
                UpdatePref();
            }
        };
    }

    private void UpdatePref()
    {
        var prefVal = "";

        for (int i = 0; i < _assetList.Count; i++)
        {
            prefVal += $"{i}/{AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(_assetList[i])).ToString()}|";
        }
        EditorPrefs.SetString(_regKey, prefVal);
    }

    private void OnGUI()
    {
        _assetListView.DoLayoutList();
    }
}
