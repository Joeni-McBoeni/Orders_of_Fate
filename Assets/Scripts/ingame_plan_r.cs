using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingame_plan_r : MonoBehaviour
{
    public Sprite[] spritesForMaps;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spritesForMaps[GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().mapNumber];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
