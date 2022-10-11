using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnStart);
    }

    void OnStart()
    {
        if (!string.IsNullOrEmpty(GameManager.Instance._sceneToLoad))
        {
            _button.onClick.RemoveListener(OnStart);
            SceneManager.LoadScene(GameManager.Instance._sceneToLoad);
        }
        else
        {

        }
    }
}
