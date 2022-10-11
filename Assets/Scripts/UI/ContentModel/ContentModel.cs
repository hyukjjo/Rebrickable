using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Utility;

namespace Starter.ContentModel
{
    [Serializable]
    public class ContentModel
    {
        private enum SelectionActionType
        {
            GoToNextScene = 0,
            GoToNextDepth
        }

        [SerializeField] private SelectionActionType _selectionActionType;
        [SerializeField] private ScenePath _sceneToLoad;
        [SerializeField] private GameObject _nextContentPresenterPrefab;

        public Action OnClicked => () =>
        {
            Debug.Log("Button Clicked");
            switch (_selectionActionType)
            {
                case SelectionActionType.GoToNextScene:
                    GameManager.Instance._sceneToLoad = _sceneToLoad;
                    break;
                case SelectionActionType.GoToNextDepth:
                    if(_nextContentPresenterPrefab != null)
                    {
                        _nextContentPresenterPrefab.SetActive(true);
                    }
                    break;
                default:
                    break;
            }
        };
    }
}