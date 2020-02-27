using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingame_plan_b : MonoBehaviour
{
    public Sprite[] spritesForMaps;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spritesForMaps[GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().mapNumber];

        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.name.PadRight(8, '0').Substring(0, 8) == "ability_")
            {
                go.GetComponent<btn_ability>().visibilityChange(true);
                go.GetComponent<btn_ability>().spriteChange(4);
                go.GetComponent<btn_ability>().checkIfUsable();
            }
        }

        GameObject.Find("count_energy_e").GetComponent<Renderer>().enabled = true;
        GameObject.Find("count_energy_z").GetComponent<Renderer>().enabled = true;
        GameObject.Find("count_energy_e").GetComponent<number_changer>().changeNumber(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_b % 10);
        GameObject.Find("count_energy_z").GetComponent<number_changer>().changeNumber(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_b / 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
