using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Selection : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] private List<ContentModel.SelectionModel> _selectionModels;

    [Header("View")]
    
    [SerializeField] private Transform _gridLayoutGroup;
    [SerializeField] private GameObject _viewPrefab;

    private void Start()
    {
        foreach(var selectionModel in _selectionModels)
        {
            var view = Instantiate(_viewPrefab, _gridLayoutGroup).GetComponent<ContentView>();
            view.Init(selectionModel.Sprites, selectionModel.OnClicked);
        }
    }
}
