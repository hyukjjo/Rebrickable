using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpWarning : MonoBehaviour
{
    [SerializeField]
    private string _content;
    private Text _text;

    private void OnEnable()
    {
        if (_text == null)
        {
            _text = GetComponentInChildren<Text>();
        }

        _text.text = _content;
    }

    private void OnDisable()
    {
        UIManager.Instance.HidePopUpWarning();
    }
}
