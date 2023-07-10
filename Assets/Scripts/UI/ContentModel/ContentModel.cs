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

        public virtual Action OnClicked => () =>
        {
            Debug.Log("Button Clicked");
            switch (_selectionActionType)
            {
                case SelectionActionType.GoToNextScene:
                    if(GameManager.Instance.IsCharacterSelected)
                    {
                        SceneManager.LoadScene(_sceneToLoad);
                    }
                    else
                    {
                        UIManager.Instance.ShowPopUpWarning("Please Select Character.");
                    }
                    break;
                case SelectionActionType.GoToNextDepth:
                    if(_nextContentPresenterPrefab != null)
                    {
                        _nextContentPresenterPrefab.SetActive(true);
                    }
                    break;
                case SelectionActionType.Quit:
                    UIManager.Instance.ShowPopUpYesOrNo(() => GameManager.Instance.SaveDataAndExitGame(), null);
                    break;
                case SelectionActionType.SelectCharacter:
                    GameManager.Instance.IsCharacterSelected = true;
                    break;
                case SelectionActionType.None:
                    break;
                default:
                    break;
            }
        };
    }
}