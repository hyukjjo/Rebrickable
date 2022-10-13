using UnityEngine;
using System;
using Starter.ContentView;
using Starter.ContentModel;

[Serializable]
public class ButtonModel : ContentModel
{
    [SerializeField] private ContentView.Sprites _sprites;
    [SerializeField] private string _contentString;

    public ContentView.Sprites Sprites => _sprites;
}

