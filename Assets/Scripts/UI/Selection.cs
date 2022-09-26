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

    private void Start()
    {
        
    }
}
