using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataPresenter : ContentPresenter
{
    [Header("Model")]
    [SerializeField] private List<PlayerDataModel> _playerDataModels;

    private List<PlayerDataView> _playerDataViewList = new List<PlayerDataView>();

    public override void OnEnable()
    {
        if (_playerDataViewList.Count == 0)
        {
            foreach (var playerDataModels in _playerDataModels)
            {
                var view = Instantiate(_viewPrefab, _gridLayoutGroup).GetComponent<PlayerDataView>();
                view.InitView(playerDataModels.Sprites, playerDataModels.Content, playerDataModels.OnClicked);
                _playerDataViewList.Add(view);
            }
        }
        else
        {
            foreach (var view in _playerDataViewList)
            {
                view.Enable();
            }
        }
    }

    public override void OnDisable()
    {
        foreach (var view in _playerDataViewList)
        {
            view.Disable();
        }
    }
}
