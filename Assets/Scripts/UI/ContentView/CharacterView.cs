using System;
using Starter.ContentView;
using UnityEngine.EventSystems;

public class CharacterView : ContentView
{
    public override void InitView(Sprites sprites = null, Content content = null, Action onClick = null, Action onHovered = null)
    {
        base.InitView(sprites, null, onClick, onHovered);
    }

    public override void Disable()
    {
        base.Disable();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        GameManager.Instance.IsCharacterSelected = true;
    }
}
