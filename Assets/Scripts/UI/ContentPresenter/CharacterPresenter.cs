using System.Collections.Generic;
using UnityEngine;

public class CharacterPresenter : ContentPresenter
{
    [Header("Model")]
    [SerializeField] private List<CharacterModel> _characterModels;

    [Header("View")]
    [SerializeField] private Transform _gridLayoutGroup;
    [SerializeField] private GameObject _viewPrefab;

    private List<CharacterView> _characterViewList;

    public override void OnEnable()
    {
        foreach (var characterModels in _characterModels)
        {
            var view = Instantiate(_viewPrefab, _gridLayoutGroup).GetComponent<CharacterView>();
            view.Init(characterModels.Sprites, characterModels.OnClicked);
            _characterViewList.Add(view);
        }
    }

    public override void OnDisable()
    {
        foreach (var characterView in _characterViewList)
        {
            characterView.Disable();
        }
    }
}
