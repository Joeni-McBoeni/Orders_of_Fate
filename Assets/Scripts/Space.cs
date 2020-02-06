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
        int responsibleUnits_r = 2;
        int responsibleUnits_b = 4;
        while (myUnits[1] + myUnits[2] != 0 && myUnits[3] + myUnits[4] != 0)
        {
            if(myUnits[responsibleUnits_b] == 0)
            {
                responsibleUnits_b--;
            }
            if (myUnits[responsibleUnits_r] == 0)
            {
                responsibleUnits_r--;
            }

            int change = 0;
            if(myUnits[responsibleUnits_b] < myUnits[responsibleUnits_r])
            {
                change = myUnits[responsibleUnits_b];
            }
            else
            {
                change = myUnits[responsibleUnits_r];
            }

            myUnits[responsibleUnits_b] -= change;
            myUnits[responsibleUnits_r] -= change;


            Debug.Log(myUnits[responsibleUnits_b] + " " + responsibleUnits_b + " " + myUnits[responsibleUnits_r] + " " + responsibleUnits_r);
        }

        if (myUnits[1] + myUnits[2] != 0)
        {
            switch (myType)
            {
                case 3: // took over enemy base -> win condition
                    Debug.Log("thank you orcs");
                    myType = 1;
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
                    Debug.Log("thank you knights");
                    myType = 3;
                    break;
                case 3:
                    break;
                default:
                    myType = 4;
                    break;
            }
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
