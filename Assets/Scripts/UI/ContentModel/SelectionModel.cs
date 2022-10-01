using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Utility;
using UnityEditor;

namespace ContentModel
{
    [Serializable]
    public class SelectionModel
    {
        private enum SelectionActionType
        {
            GoToNextScene = 0,
            GoToNextDepth
        }

        [SerializeField] private ContentView.Sprites _sprites;
        [SerializeField] private SelectionActionType _selectionActionType;
        [SerializeField] private ScenePath _sceneToLoad;
        [SerializeField] private GameObject _nextContentPrefab;

        public ContentView.Sprites Sprites => _sprites;

        public Action OnClicked => () =>
        {
            Debug.Log("Button Clicked");
            switch (_selectionActionType)
            {
                case SelectionActionType.GoToNextScene:
                    SceneManager.LoadScene(_sceneToLoad);
                    break;
                case SelectionActionType.GoToNextDepth:
                    break;
                default:
                    break;
            }
        };
    }
}
