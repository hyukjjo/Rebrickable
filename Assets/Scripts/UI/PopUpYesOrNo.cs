using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpYesOrNo : MonoBehaviour
{
    public Action OnYesClicked;
    public Action OnNoClicked;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void Yes()
    {
        OnYesClicked?.Invoke();
        UIManager.Instance.HidePopUpYesOrNo();
    }

    public void No()
    {
        OnNoClicked?.Invoke();
        UIManager.Instance.HidePopUpYesOrNo();
    }
}
