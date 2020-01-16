using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_space : MonoBehaviour
{
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
}
