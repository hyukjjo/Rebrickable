using UnityEngine;
using System;
using Starter.ContentView;
using Starter.ContentModel;

[Serializable]
public class PlayerDataModel : ContentModel
{
    [SerializeField] private ContentView.Sprites _sprites;
    [SerializeField] private ContentView.Content _content;

    public ContentView.Sprites Sprites => _sprites;
    public ContentView.Content Content => _content;
}
