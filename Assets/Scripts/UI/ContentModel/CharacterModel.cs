using UnityEngine;
using System;
using Starter.ContentView;
using Starter.ContentModel;

[Serializable]
public class CharacterModel : ContentModel
{
    [SerializeField] private ContentView.Sprites _sprites;
    [SerializeField] private Player _player;

    public ContentView.Sprites Sprites => _sprites;
    public Player Player => _player;

    
}

