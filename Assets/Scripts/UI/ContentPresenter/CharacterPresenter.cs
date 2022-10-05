using System.Collections.Generic;
using UnityEngine;

public class CharacterPresenter : ContentPresenter
{
    [Header("Model")]
    [SerializeField] private List<CharacterModel> _characterModels;

    [Header("View")]
    [SerializeField] private Transform _gridLayoutGroup;
    [SerializeField] private GameObject _viewPrefab;

    public override void OnEnable()
    {
        foreach (var characterModels in _characterModels)
        {
            var view = Instantiate(_viewPrefab, _gridLayoutGroup).GetComponent<CharacterView>();
            view.Init(characterModels.Sprites, characterModels.OnClicked);
        }
    }

    public override void OnDisable()
    {//오류임 수정 필요
        if (_currentPresenterActivation == false)
        {
            foreach (var characterModels in _characterModels)
            {
                var view = Instantiate(_viewPrefab, _gridLayoutGroup).GetComponent<CharacterView>();
                view.Init(characterModels.Sprites, characterModels.OnClicked);
            }
        }
    }
}
