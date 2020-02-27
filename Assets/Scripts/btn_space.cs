using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        else if(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter < 90)
        {
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().addMoveCommand(spaceNumber);
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "ingame_plan_r")
            {
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_r.Add(new Command(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter - 90, new int[1] { spaceNumber }));
            }
            else if (SceneManager.GetActiveScene().name == "ingame_plan_b")
            {
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_b.Add(new Command(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter - 90, new int[1] { spaceNumber }));
            }
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter = -1;
            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.name.PadRight(8, '0').Substring(0, 8) == "ability_")
                {
                    go.GetComponent<btn_ability>().checkIfUsable();
                }
            }
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
