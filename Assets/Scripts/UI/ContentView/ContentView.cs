using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace Starter.ContentView
{
    public class ContentView : Selectable //View�� ���������� ����ϱ� ���ؼ��� ���� Ŭ������ �ø��� CharacterView�� ��ӹ޾ƾ��� ��. �ϴ��� �׽�Ʈ 22.09.27
    {
        [Serializable]
        public class Sprites
        {
            public Sprite NormalSprite;
            public Sprite HoverSprite;
        }

        [Serializable]
        public class Content
        {
            public string TextKey;
            public string Text;
        }

        [SerializeField] private Image _image;
        [SerializeField] private Sprites _sprites;
        [SerializeField] private Content _content;
        private Action _onClicked;
        private Action _onHovered;

        public virtual void InitView(Sprites sprites = null, Content content = null, Action onClick = null, Action onHovered = null)
        {
            _content = content;
            _onClicked = onClick;
            _onHovered = onHovered;
            _sprites = sprites ?? _sprites;
            _image.sprite = _sprites.NormalSprite;
        }

        public virtual void ResetView()
        {
            
        }

        public virtual void Enable()
        {
            gameObject.SetActive(true);
        }

        public virtual void Disable()
        {
            gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
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
}