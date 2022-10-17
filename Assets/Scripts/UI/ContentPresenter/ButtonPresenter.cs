using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresenter : ContentPresenter
{
    [Header("Model")]
    [SerializeField] private List<ButtonModel> _buttonModels;

    private List<ButtonView> _buttonViewList = new List<ButtonView>();

    public override void OnEnable()
    {
        if (_buttonViewList.Count == 0)
        {
            foreach (var characterModels in _buttonModels)
            {
                var view = Instantiate(_viewPrefab, _gridLayoutGroup).GetComponent<ButtonView>();
                view.InitView(characterModels.Sprites, characterModels.OnClicked);
                _buttonViewList.Add(view);
            }
        }
        else
        {
            foreach (var view in _buttonViewList)
            {
                view.Enable();
            }
        }
    }

    public override void OnDisable()
    {
        foreach (var characterView in _buttonViewList)
        {
            characterView.Disable();
        }
    }
}
