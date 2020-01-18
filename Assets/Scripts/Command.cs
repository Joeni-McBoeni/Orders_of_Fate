using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Command
{
    private int myId;
    private int[] myParameters;

    // Index for Commands sorted by Id
    //
    // 0: Empty command. Is used to fill up Command List in order to preserve crashes. No Parameters.
    // 1: Movement Command. Used to move a Number of Units to another space, if possible. Param0 = Space of Origin, Param1 = Destination, Param2 = No. of Units moved

    public Command(int id, int[] parameters)
    {
        myId = id;
        myParameters = parameters;
    }

    public int id
    {
        get { return myId; }
        set { myId = value; }
    }

    public int[] parameters
    {
        get { return myParameters; }
        set { myParameters = value; }
    }

    public void doCommand(int playerId) // 1 = red, 3 = blu
    {
        switch (this.myId)
        {
            case 1:
                int availableUnits = GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[0]].units[playerId];
                if (availableUnits >= myParameters[2])
                {
                    GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[0]].units[playerId] -= myParameters[2];
                    GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[1]].units[playerId + 1] += myParameters[2];
                } 
                else
                {
                    GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[0]].units[playerId] -= availableUnits;
                    GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[1]].units[playerId + 1] += availableUnits;
                }
                return;
            default:
                return;
        }
    }
}
