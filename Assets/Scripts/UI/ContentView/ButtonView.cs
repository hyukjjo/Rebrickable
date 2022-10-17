using System;
using Starter.ContentView;
using UnityEngine.UI;

public class ButtonView : ContentView
{
    [NonSerialized] private string _textID;
    private Text _text;

    public override void InitView(Sprites sprites = null, Action onClick = null, Action onHovered = null)
    {
        base.InitView(sprites, onClick, onHovered);
        _text = GetComponentInChildren<Text>();
    }

    public override void Disable()
    {
        base.Disable();
    }
}
