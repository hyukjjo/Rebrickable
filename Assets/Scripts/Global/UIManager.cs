using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public List<ContentPresenter> contentPresenters = new List<ContentPresenter>();

    public void InputLock()
    {
        if(contentPresenters.Count > 0)
        {
            foreach (var presenter in contentPresenters)
            {
                var buttons = presenter.GetComponentsInChildren<Button>();

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
                var buttons = presenter.GetComponentsInChildren<Button>();

                foreach (var button in buttons)
                {
                    button.enabled = true;
                }
            }
        }
    }
}
