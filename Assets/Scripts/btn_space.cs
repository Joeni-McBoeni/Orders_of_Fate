using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_space : MonoBehaviour
{
    private SpriteRenderer spriterenderer;
    public Sprite neutralSprite;
    public Sprite blueSprite;
    public Sprite redSprite;

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

    public void getClickEvent()
    {
        OnMouseDown();
    }

    void OnMouseDown()
    {
        int spaceNumber = int.Parse(gameObject.name.Substring(5));
        if (GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter == -1)
        {
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter = spaceNumber;
        }
        else
        {
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().addMoveCommand(spaceNumber);
        }
    }

    public void spriteChange(int type)
    {
        switch (type)
        {
            case 0:
                // neutral
                spriterenderer.sprite = neutralSprite;
                break;
            case 2:
                // red
                spriterenderer.sprite = redSprite;
                break;
            case 4:
                // blue
                spriterenderer.sprite = blueSprite;
                break;
            default:
                break;
        }
    }
}
