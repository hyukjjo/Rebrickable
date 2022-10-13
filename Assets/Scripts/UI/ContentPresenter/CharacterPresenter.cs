using System.Collections.Generic;
using UnityEngine;

public class CharacterPresenter : ContentPresenter
{
    [Header("Model")]
    [SerializeField] private List<CharacterModel> _characterModels;

    

    private List<CharacterView> _characterViewList = new List<CharacterView>();

    public override void OnEnable()
    {
        if (_characterViewList.Count == 0)
        {
            foreach (var characterModels in _characterModels)
            {
                var view = Instantiate(_viewPrefab, _gridLayoutGroup).GetComponent<CharacterView>();
                view.Init(characterModels.Sprites, characterModels.OnClicked);
                _characterViewList.Add(view);
            }
        }
        else
        {
            foreach(var view in _characterViewList)
            {
                view.Enable();
            }
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
