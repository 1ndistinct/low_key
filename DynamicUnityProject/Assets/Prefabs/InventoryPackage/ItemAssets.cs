using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{

    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite ResourceSprite;
    public Sprite ResourceSpriteBlue;
    public Sprite ResourceSpriteYellow;
    public Sprite ResourceSpriteGreen;
    public Sprite ResourceSpritePurple;
    public Sprite GemSprite;
    public Sprite ComponentSprite;
    public Sprite ConsumableSprite;
    public Sprite NullSprite;
}
