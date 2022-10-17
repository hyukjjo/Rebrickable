using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpWarning : MonoBehaviour
{
    private void OnEnable()
    {
        //
    }

    private void OnDisable()
    {
        UIManager.Instance.HidePopUpWarning();
    }
}
