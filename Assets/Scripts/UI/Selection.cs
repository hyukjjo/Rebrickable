using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct sSelectionModel
{
    public string modelName;
    public Action OnSelect;
};

public class Selection : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] private List<GameObject> _selectionModels = new List<GameObject>();

    [Header("View")]
    [SerializeField] private GameObject _characterView;
}
