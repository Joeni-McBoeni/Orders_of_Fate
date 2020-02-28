using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number_changer : MonoBehaviour
{
    private SpriteRenderer spriterenderer;
    public Sprite[] spritesForNumbers;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void changeNumber(int number)
    {
        number %= 10;
        spriterenderer.sprite = spritesForNumbers[number];
    }
}
