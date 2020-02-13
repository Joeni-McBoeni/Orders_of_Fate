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
    // 0: Empty command. Is used to fill up Command List in order to preserve crashes. No Parameters. Cost: 0
    // 1: Movement Command. Used to move a Number of Units to another space, if possible. Param0 = Space of Origin, Param1 = Destination, Param2 = No. of Units moved. Cost: 0
    // 2: Command for "Independence". If the chosen Space is empty, turn it neutral. Does not work with Bases. Param0 = Chosen Space. Cost: 2
    // 3: Command. Cost: 3
    // 4: Command for "Strike". All units on the chosen space become dormant. Param0 = Chosen Space. Cost: 5
    // 5: Command for "Plague". Takes away one enemy Unit from every Space. No Parameters. Cost: 8
    // 6: Command for "Giant Fiery Ball". Kills everything on a Space. Param0 = Chosen Space. Cost: 13

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

    public void doCommand(int playerId) // 1 = red, 3 = blue
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
            case 2:
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[0]].independenceCheck = true;
                return;
            case 4:
                // NOT QUITE RIGHT YET, BECAUSE WHOEVER GOES FIRST HAS AN ADVANTAGE
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[0]].units[2] += GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[0]].units[1];
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[1]].units[1] = 0;
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[0]].units[4] += GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[0]].units[3];
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[1]].units[3] = 0;
                return;
            case 5:
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().plagueInEffect[playerId / 3] = true;
                return;
            case 6:
                GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[myParameters[0]].GFB = true;
                return;
            default:
                return;
        }
    }
}
