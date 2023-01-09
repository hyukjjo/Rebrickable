using System;
using Starter.ContentView;
using TMPro;
using UnityEngine.UI;

public class ButtonView : ContentView
{
    private string _textID;
    private TextMeshProUGUI _text;

    public override void InitView(Sprites sprites = null, Content content = null, Action onClick = null, Action onHovered = null)
    {
        base.InitView(sprites, content, onClick, onHovered);
        _text = GetComponentInChildren<TextMeshProUGUI>();

        if (content != null)
        {
            _textID = content.TextKey;
            _text.text = content.Text;
        }
    }

    public override void Disable()
    {
        base.Disable();
    }
}
