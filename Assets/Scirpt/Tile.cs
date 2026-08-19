using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offSetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Offset(bool isOffset)
    {
        spriteRenderer.color = isOffset? offSetColor : baseColor;
    }
}
