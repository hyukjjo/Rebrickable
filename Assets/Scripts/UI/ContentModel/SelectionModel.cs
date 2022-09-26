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

        [SerializeField] private Sprite _sprite;
        [SerializeField] private SelectionActionType _selectionActionType;
        [SerializeField] private ScenePath _sceneToLoad;
        [SerializeField] private GameObject _nextContentPrefab;

        public Action OnClicked => () =>
        {
            switch (_selectionActionType)
            {
                case SelectionActionType.GoToNextScene:
                    break;
                case SelectionActionType.GoToNextDepth:
                    break;
                default:
                    break;
            }
        };
    }
}
