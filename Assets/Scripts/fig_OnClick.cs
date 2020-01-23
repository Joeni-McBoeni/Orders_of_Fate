using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fig_OnClick : MonoBehaviour
{
    private SpriteRenderer spriterenderer;
    public Sprite orcSprite;
    public Sprite knightSprite;

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

    void OnMouseDown()
    { 
        GameObject.Find("tile_" + gameObject.name.Substring(0, 2)).GetComponent<btn_space>().getClickEvent();
    }

    public void changeSprite(int type)
    {
        switch (type)
        {
            case 1:
            case 2:
                spriterenderer.sprite = orcSprite;
                break;
            case 3:
            case 4:
                spriterenderer.sprite = knightSprite;
                break;
            default:
                break;
        }
    }
}
