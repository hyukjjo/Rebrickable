using System;
using Starter.ContentView;
using UnityEngine.UI;

public class ButtonView : ContentView
{
    private Text _text;

    public override void Init(Sprites sprites = null, Action onClick = null, Action onHovered = null)
    {
        base.Init(sprites, onClick, onHovered);
        _text = GetComponentInChildren<Text>();
    }

    public override void Disable()
    {
        base.Disable();
    }
}
