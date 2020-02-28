using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_ability : MonoBehaviour
{
    public Sprite sprite_b;
    public Sprite sprite_r;
    private SpriteRenderer spriterenderer;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void spriteChange(int type)
    {
        switch (type)
        {
            case 0:
                // neutral
                this.visibilityChange(false);
                break;
            case 2:
                // red
                spriterenderer.sprite = sprite_r;
                break;
            case 4:
                // blue
                spriterenderer.sprite = sprite_b;
                break;
            default:
                break;
        }
    }

    public void visibilityChange(bool visible)
    {
        this.GetComponent<BoxCollider2D>().enabled = visible;
        this.GetComponent<Renderer>().enabled = visible;
    }

    public void checkIfUsable()
    {
        int availableEnergy = 0;
        if (SceneManager.GetActiveScene().name == "ingame_plan_r")
        {
            availableEnergy = GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_r;
        }
        else if (SceneManager.GetActiveScene().name == "ingame_plan_b")
        {
            availableEnergy = GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_b;
        }

        if (this.getCost() > availableEnergy)
        {
            this.gameObject.transform.GetComponent<Renderer>().materials[0].color = new Color(0.6f, 0.6f, 0.6f, 1.0f);
            this.GetComponent<BoxCollider2D>().enabled = false;
        } 
        else
        {
            this.gameObject.transform.GetComponent<Renderer>().materials[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private int getCost()
    {
        switch (this.gameObject.name)
        {
            case "ability_independence":
                return 2;
            case "ability_strike":
            case "ability_blocker":
                return 4;
            case "ability_fireball":
                return 7;
            case "ability_plague":
                return 9;
            default:
                return 9999;
        }
    }

    void OnMouseDown()
    {
        this.gameObject.transform.GetComponent<Renderer>().materials[0].color = new Color(1.3f, 1.3f, 1.3f, 1.0f);
        bool checkAtTheEnd = false;
        switch (this.gameObject.name)
        {
            // Adding 90 to move Parameter in order to signify that it is a command
            case "ability_independence":
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter = 92;
                break;
            case "ability_strike":
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter = 94;
                break;
            case "ability_blocker":
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter = 93;
                break;
            case "ability_fireball":
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().firstMoveParameter = 96;
                break;
            case "ability_plague":
                if (SceneManager.GetActiveScene().name == "ingame_plan_r")
                {
                    GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_r.Add(new Command(5, new int[0]));
                }
                else if (SceneManager.GetActiveScene().name == "ingame_plan_b")
                {
                    GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_b.Add(new Command(5, new int[0]));
                }
                checkAtTheEnd = true;
                break;
            default:
                break;
        }

        if (SceneManager.GetActiveScene().name == "ingame_plan_r")
        {
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_r -= this.getCost();
            GameObject.Find("count_energy_e").GetComponent<number_changer>().changeNumber(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_r % 10);
            GameObject.Find("count_energy_z").GetComponent<number_changer>().changeNumber(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_r / 10);
        }
        else if (SceneManager.GetActiveScene().name == "ingame_plan_b")
        {
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_b -= this.getCost();
            GameObject.Find("count_energy_e").GetComponent<number_changer>().changeNumber(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_b % 10);
            GameObject.Find("count_energy_z").GetComponent<number_changer>().changeNumber(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_b / 10);
        }

        if(checkAtTheEnd == true)
        {
            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.name.PadRight(8, '0').Substring(0, 8) == "ability_")
                {
                    go.GetComponent<btn_ability>().checkIfUsable();
                }
            }
        }
    }
}
