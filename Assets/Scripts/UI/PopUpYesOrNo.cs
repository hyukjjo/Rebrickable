using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpYesOrNo : MonoBehaviour
{
    public bool answer;

    private void OnEnable()
    {
        //
    }

    private void OnDisable()
    {
        
    }

    public void SelectYesOrNo(bool select)
    {
        answer = select;
    }
}