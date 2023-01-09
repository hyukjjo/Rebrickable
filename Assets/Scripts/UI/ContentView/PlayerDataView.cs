using System;
using Starter.ContentView;
using TMPro;
using UnityEngine.UI;

public class PlayerDataView : ContentView
{
    private TextMeshProUGUI _text;

    public override void InitView(Sprites sprites = null, Content content = null, Action onClick = null, Action onHovered = null)
    {
        base.InitView(sprites, content, onClick, onHovered);
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _text.text = PlayerData.GetPlayerData()._gold.ToString();
    }

    public override void Disable()
    {
        base.Disable();
    }
}
