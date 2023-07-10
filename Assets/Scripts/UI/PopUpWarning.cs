using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpWarning : MonoBehaviour
{
    [SerializeField]
    private string _content;
    [SerializeField]
    private TextMeshProUGUI _text;

    public void SetText(string content)
    {
        _content = content;

        if (_text.text.Equals(string.Empty))
            _text.text = _content;
    }

    private void OnDisable()
    {
        _content = string.Empty;
        _text.text = string.Empty;
    }
}
