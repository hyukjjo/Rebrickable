using UnityEngine;
using System;
using Starter.ContentView;
using Starter.ContentModel;

[Serializable]
public class CharacterModel : ContentModel
{
    [SerializeField] private ContentView.Sprites _sprites;

    public ContentView.Sprites Sprites => _sprites;
    public GameObject PlayerPrefab;

    public override Action OnClicked => () => GameManager.Instance.PlayerPrefab = PlayerPrefab;
}

