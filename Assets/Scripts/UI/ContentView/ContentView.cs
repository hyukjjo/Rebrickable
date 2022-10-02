using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContentView : Selectable //View�� ���������� ����ϱ� ���ؼ��� ���� Ŭ������ �ø��� CharacterView�� ��ӹ޾ƾ��� ��. �ϴ��� �׽�Ʈ 22.09.27
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
        button.onClick.AddListener(OnClicked);
    }

    public virtual void OnClicked()
    {
        _onClicked?.Invoke();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        Debug.Log("Pointer Enter");
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        Debug.Log("Pointer Enter");
    }
}
