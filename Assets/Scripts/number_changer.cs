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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeNumber(int number)
    {
        number %= 10;
        spriterenderer.sprite = spritesForNumbers[number];
    }
}
