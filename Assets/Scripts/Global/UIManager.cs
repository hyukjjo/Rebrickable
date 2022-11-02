using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private List<ContentPresenter> contentPresenters = new List<ContentPresenter>();
    [SerializeField] private PopUpWarning _popUpWarning;
    [SerializeField] private PopUpYesOrNo _popUpYesOrNo;

    private void Start()
    {
        contentPresenters.AddRange(FindObjectsOfType<ContentPresenter>());
    }

    public void InputLock()
    {
        if(contentPresenters.Count > 0)
        {
            foreach (var presenter in contentPresenters)
            {
                var buttons = presenter.GetComponentsInChildren<Selectable>();

                foreach (var button in buttons)
                {
                    button.enabled = false;
                }
            }
        }
    }

    public void InputUnlock()
    {
        if (contentPresenters.Count > 0)
        {
            foreach (var presenter in contentPresenters)
            {
                var buttons = presenter.GetComponentsInChildren<Selectable>();

                foreach (var button in buttons)
                {
                    button.enabled = true;
                }
            }
        }
    }

    public void ShowPopUpWarning()
    {
        InputLock();
        _popUpWarning.gameObject.SetActive(true);
    }

    public void HidePopUpWarning()
    {
        _popUpWarning.gameObject.SetActive(false);
        InputUnlock();
    }

    public void ShowPopUpYesOrNo(Action yesAction, Action noAction)
    {
        InputLock();
        _popUpYesOrNo.gameObject.SetActive(true);
        _popUpYesOrNo.OnYesClicked = yesAction;
        _popUpYesOrNo.OnNoClicked = noAction;
    }

    public void HidePopUpYesOrNo()
    {
        _popUpYesOrNo.OnYesClicked = null;
        _popUpYesOrNo.OnNoClicked = null;
        _popUpYesOrNo.gameObject.SetActive(false);
        InputUnlock();
    }
}
