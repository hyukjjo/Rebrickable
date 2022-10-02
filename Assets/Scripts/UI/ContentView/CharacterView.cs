using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : ContentView
{
    public override void Init(Sprites sprites = null, Action onClick = null, Action onHovered = null)
    {
        base.Init(sprites, onClick, onHovered);
    }

    public override void OnClicked()
    {
        base.OnClicked();
    }
}
