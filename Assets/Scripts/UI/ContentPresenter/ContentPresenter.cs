using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentPresenter : MonoBehaviour
{
    [SerializeField] protected bool _currentPresenterActivation = false;

    public virtual void OnEnable()
    {
        
    }

    public virtual void OnDisable()
    {

    }
}
