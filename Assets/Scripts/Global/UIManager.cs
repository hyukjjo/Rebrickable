using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public List<ContentPresenter> contentPresenters = new List<ContentPresenter>();
    [SerializeField] private PopUpWarning _popUpWarning;

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
}
