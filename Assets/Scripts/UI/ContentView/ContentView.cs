using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ContentView : MonoBehaviour //View를 공통적으로 사용하기 위해서는 상위 클래스로 올리고 CharacterView가 상속받아야할 듯. 일단은 테스트 22.09.27
{
    [Serializable]
    public class Sprites
    {
        public Sprite normalSprite;
        public Sprite hoverSprite;
    }

    [SerializeField] private Image _image;
    [SerializeField] private Sprites _sprites;
    [SerializeField] private Button button;
    private Action _onClicked;
    private Action _onHovered;

    public virtual void Init(Sprites sprites = null, Action onClick = null, Action onHovered = null)
    {
        _onClicked = onClick;
        _onHovered = onHovered;
        _sprites = sprites ?? _sprites;
        _image.sprite = _sprites.normalSprite;

        
    }
}
