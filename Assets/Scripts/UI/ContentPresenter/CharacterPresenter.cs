using System.Collections.Generic;
using UnityEngine;

public class CharacterPresenter : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] private List<CharacterModel> _characterModels;

    [Header("View")]

    [SerializeField] private Transform _gridLayoutGroup;
    [SerializeField] private GameObject _viewPrefab;

    private void OnEnable()
    {
        foreach (var characterModels in _characterModels)
        {
            var view = Instantiate(_viewPrefab, _gridLayoutGroup).GetComponent<CharacterView>();
            view.Init(characterModels.Sprites, characterModels.OnClicked);
        }
    }

    private void OnDisable()
    {
        
    }
}
