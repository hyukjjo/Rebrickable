using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SelectionModel
{
    public string modelName;
    public Action OnSelect;
    public GameObject _characterView;
}

public class Selection : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] private List<SelectionModel> _selectionModels = new List<SelectionModel>();

    [Header("View")]
    
    [SerializeField] private Transform _gridLayoutGroup;

    private void Start()
    {
        if(_selectionModels != null)
        {
            foreach (var item in _selectionModels)
            {
                var viewObject = GameObject.Instantiate(item._characterView);
                viewObject.transform.SetParent(_gridLayoutGroup.transform);

            }
        }
    }
}
