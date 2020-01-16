using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_nextTurn : MonoBehaviour
{
    public List<Command> commands_r = new List<Command>();
    public List<Command> commands_b = new List<Command>();
    public List<Space> gameSpaces = new List<Space>();
    public int firstMoveParameter = -1;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // this will need to be individualized at some point, for different maps
        gameSpaces.Add(new Space(0, new int[3] { 1, 2, 9 }));
        gameSpaces.Add(new Space(0, new int[3] { 0, 3, 4 }));
        gameSpaces.Add(new Space(0, new int[3] { 0, 4, 5 }));
        gameSpaces.Add(new Space(0, new int[2] { 1, 6 }));
        gameSpaces.Add(new Space(0, new int[4] { 1, 2, 6, 7 }));
        gameSpaces.Add(new Space(0, new int[2] { 2, 7 }));
        gameSpaces.Add(new Space(0, new int[3] { 3, 4, 8 }));
        gameSpaces.Add(new Space(0, new int[3] { 4, 5, 8 }));
        gameSpaces.Add(new Space(0, new int[3] { 6, 7, 10 }));
        gameSpaces.Add(new Space(1, new int[1] { 0 }));
        gameSpaces.Add(new Space(3, new int[1] { 8 }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMoveCommand(int secondMoveParameter)
    {
        foreach (int possibleSpace in gameSpaces[firstMoveParameter].adjacentSpaces)
        {
            if(possibleSpace == secondMoveParameter)
            {
                if (SceneManager.GetActiveScene().name == "ingame_plan_r")
                {
                    commands_r.Add(new Command(1, new int[3] { firstMoveParameter, secondMoveParameter, gameSpaces[firstMoveParameter].units[1] }));
                }
                else if (SceneManager.GetActiveScene().name == "ingame_plan_b")
                {
                    commands_b.Add(new Command(1, new int[3] { firstMoveParameter, secondMoveParameter, gameSpaces[firstMoveParameter].units[3] }));
                }
            }
        }

        // Debug Block
        if(commands_r.Count != 0)
        {
            Command cbt = commands_r[commands_r.Count - 1];
            Debug.Log(cbt.parameters[0].ToString() + " to " + cbt.parameters[1].ToString() + ". No. of Units: " + cbt.parameters[2].ToString());
        }

        firstMoveParameter = -1;
    }

    void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name == "ingame_plan_r")
        {
            commands_r.Add(new Command(0, new int[0]));
        }
        else if (SceneManager.GetActiveScene().name == "ingame_plan_b")
        {
            commands_b.Add(new Command(0, new int[0]));
        }


        if (commands_r.Count == 0)
        {
            SceneManager.LoadScene("ingame_plan_r", LoadSceneMode.Single);
        }
        else if (commands_b.Count == 0)
        {
            SceneManager.LoadScene("ingame_plan_b", LoadSceneMode.Single);
        }
        else 
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("ingame_resolve", LoadSceneMode.Single);
        }
    }
}
