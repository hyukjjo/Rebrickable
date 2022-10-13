using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentPresenter : MonoBehaviour
{
    [Header("View")]
    [SerializeField] protected Transform _gridLayoutGroup;
    [SerializeField] protected GameObject _viewPrefab;

    public virtual void OnEnable()
    {
        
    }

    public virtual void OnDisable()
    {

    }
}
