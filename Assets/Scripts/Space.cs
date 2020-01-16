using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Space
{
    private int myType; // 0 = unaligned normal, 1 = red base, 2 = red normal, 3 = blue base, 4 = blue normal
    private int[] myUnits; // counts number of units. 0 = blank (for consistency with myType), 1 = red active, 2 = red dormant, 3 = blue active, 4 = blue dormant
    private int[] myAdjacentSpaces; // Spaces you can move to from here

    public Space(int type, int[] adjacentSpaces)
    {
        myType = type;
        myUnits = new int[5];
        for(int i = 0; i < 5; i++)
        {
            myUnits[i] = 0;
        }
        myAdjacentSpaces = adjacentSpaces;
    }

    public void refresh()
    {
        switch (this.myType)
        {
            case 1:
            case 2:
                myUnits[1] += myUnits[2] + 1;
                myUnits[2] = 0;
                break;
            case 3:
            case 4:
                myUnits[3] += myUnits[4] + 1;
                myUnits[4] = 0;
                break;
            default:
                break;
        }
    }

    public void battle()
    {
        while (myUnits[1] + myUnits[2] != 0 && myUnits[3] + myUnits[4] != 0)
        {
            int change = 0;
            myUnits[2] -= change;
        }

        if(myUnits[1] + myUnits[2] != 0)
        {
            switch (myType)
            {
                case 3: // took over enemy base -> win condition
                    SceneManager.LoadScene("redwon", LoadSceneMode.Single);
                    break;
                case 1:
                    break;
                default:
                    myType = 2;
                    break;
            }
        } 
        else if (myUnits[3] + myUnits[4] != 0)
        {
            switch (myType)
            {
                case 1: // took over enemy base -> win condition
                    SceneManager.LoadScene("bluwon", LoadSceneMode.Single);
                    break;
                case 3:
                    break;
                default:
                    myType = 4;
                    break;
            }
        }
    }

    public void checkBattle()
    {
        if (myUnits[1] + myUnits[2] != 0 && myUnits[3] + myUnits[4] != 0)
        {
            this.battle();
        }
    }

    public int type
    {
        get { return myType; }
        set { myType = value; }
    }

    public int[] units
    {
        get { return myUnits; }
        set { myUnits = value; }
    }

    public int[] adjacentSpaces
    {
        get { return myAdjacentSpaces; }
        set { myAdjacentSpaces = value; }
    }
}
