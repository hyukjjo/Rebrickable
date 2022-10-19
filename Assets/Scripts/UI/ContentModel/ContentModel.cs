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
            GoToNextDepth = 1,
            Quit = 2,
            SelectCharacter = 3,
            None
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
                    if(GameManager.Instance.LoadSceneReady)
                    {
                        SceneManager.LoadScene(_sceneToLoad);
                    }
                    else
                    {
                        UIManager.Instance.ShowPopUpWarning();
                    }
                    break;
                case SelectionActionType.GoToNextDepth:
                    if(_nextContentPresenterPrefab != null)
                    {
                        _nextContentPresenterPrefab.SetActive(true);
                    }
                    break;
                case SelectionActionType.Quit:
                    UIManager.Instance.ShowPopUpYesOrNo();
                    break;
                case SelectionActionType.SelectCharacter:
                    GameManager.Instance.LoadSceneReady = true;
                    break;
                case SelectionActionType.None:
                    break;
                default:
                    break;
            }
        };
    }
}