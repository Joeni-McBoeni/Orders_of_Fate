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
            GameObject.Find("tile_" + gameObject.name.Substring(5, 2)).transform.GetComponent<Renderer>().materials[0].color = new Color(1.2f, 1.2f, 1.2f, 1.0f);
            GameObject.Find(gameObject.name.Substring(5, 2) + "_fig").transform.GetComponent<Renderer>().materials[0].color = new Color(1.2f, 1.2f, 1.2f, 1.0f);
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
