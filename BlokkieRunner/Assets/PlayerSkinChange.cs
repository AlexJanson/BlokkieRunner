using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinChange : MonoBehaviour {

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSkin(Sprite skinSprite)
    {
        _spriteRenderer.sprite = skinSprite;
    }

}
