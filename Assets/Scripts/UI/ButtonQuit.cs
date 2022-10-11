using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
{
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnQuit);
    }

    private void OnQuit()
    {
        _button.onClick.RemoveListener(OnQuit);
        Application.Quit();
    }
}
