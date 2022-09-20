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

    private string _regKey;

    [MenuItem("Window/Asset Bookmark")]
    public static void ShowWindow()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(AssetBookmarkWindow));
        window.minSize = new Vector2(100f, 100f);
        window.titleContent = EditorGUIUtility.TrTextContentWithIcon("Asset Bookmark", "UnityEditor.ConsoleWindow");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
