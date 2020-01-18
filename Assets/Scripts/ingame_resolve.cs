using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingame_resolve : MonoBehaviour
{
    public List<Command> commands_r = new List<Command>();
    public List<Command> commands_b = new List<Command>();
    int debugCycleIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        commands_r = GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_r;
        commands_b = GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_b;

        syncCommands();
        drawBoard();

        for(int counter = 0; counter < commands_r.Count; counter++)
        {
            commands_r[counter].doCommand(1);
            commands_b[counter].doCommand(3);

            StartCoroutine(waiter());
            drawBoard();
        }

        endTurn();
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
    }

        // Update is called once per frame
    void Update()
    {
        
    }

    public void drawBoard()
    {
        int spaceNumberForDebug = 0;

        foreach (Space currentSpace in GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces)
        {
            currentSpace.battle();

            debugshit(currentSpace, spaceNumberForDebug);
            spaceNumberForDebug++;
        }

        debugCycleIndex++;
    }

    public void debugshit(Space currentSpace, int spaceNumberForDebug)
    {
        // this is allowed to be ugly, cuz it's only for testing
        string debugType = "";
        if ((currentSpace.type + 1) / 2 == 0)
        {
            debugType += "Grey ";
        }
        else if ((currentSpace.type + 1) / 2 == 1)
        {
            debugType += "Red ";
        }
        else if ((currentSpace.type + 1) / 2 == 2)
        {
            debugType += "Blue ";
        }
        if (currentSpace.type % 2 == 0)
        {
            debugType += "Normal";
        }
        else
        {
            debugType += "Base";
        }

        Debug.Log("Cycle " + debugCycleIndex + ", Space " + spaceNumberForDebug + ": " + debugType + ", " + currentSpace.units[1] + "|" + currentSpace.units[2] + "|" + currentSpace.units[3] + "|" + currentSpace.units[4]);
    }

    public void syncCommands()
    {
        if(commands_r.Count > commands_b.Count)
        {
            for(int commandsFilled = commands_b.Count; commandsFilled < commands_r.Count; commandsFilled++)
            {
                commands_b.Add(new Command(0, new int[0]));
            }
        } 
        else
        {
            for (int commandsFilled = commands_r.Count; commandsFilled < commands_b.Count; commandsFilled++)
            {
                commands_r.Add(new Command(0, new int[0]));
            }
        }
    }

    public void endTurn()
    {
        foreach (Space currentSpace in GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces)
        {
            currentSpace.refresh();
        }

        drawBoard();

        GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_r = new List<Command>();
        GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_b = new List<Command>();

        GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().roundIndex++;
        SceneManager.LoadScene("ingame_plan_r", LoadSceneMode.Single);
    }
}
