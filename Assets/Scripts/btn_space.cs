using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_space : MonoBehaviour
{
    private SpriteRenderer spriterenderer;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

        // Start is called before the first frame update
    void Start()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                spriterenderer.sprite = Resources.Load<Sprite>("tile_neutral"); // path is probably wrong
                Debug.Log("peak centrism");
                break;
            case 2:
                // red
                spriterenderer.sprite = Resources.Load<Sprite>("tile_red"); // path is probably wrong
                Debug.Log("turn red you fuck");
                break;
            case 4:
                // blue
                spriterenderer.sprite = Resources.Load<Sprite>("tile_blue"); // path is probably wrong
                Debug.Log("you should be blue, dabe dee dabe day");
                break;
            default:
                break;
        }
    }
}
