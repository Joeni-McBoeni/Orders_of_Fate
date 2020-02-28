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
    public int roundIndex = 0;
    public int mapNumber = 0;
    public bool[] plagueInEffect = new bool[2]; // 0 = red, 1 = blu
    public int energy_r = 0;
    public int energy_b = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        mapNumber = int.Parse(SceneManager.GetActiveScene().name.Substring(12, 1));
        addSpaces();
    }

    private void addSpaces()
    {
        switch (mapNumber)
        {
            case 0:
                gameSpaces.Add(new Space(0, new int[2] { 2, 9 }));
                gameSpaces.Add(new Space(0, new int[2] { 3, 9 }));
                gameSpaces.Add(new Space(0, new int[2] { 0, 4 }));
                gameSpaces.Add(new Space(0, new int[2] { 1, 4 }));
                gameSpaces.Add(new Space(0, new int[4] { 2, 3, 5, 6 }));
                gameSpaces.Add(new Space(0, new int[2] { 4, 7 }));
                gameSpaces.Add(new Space(0, new int[2] { 4, 8 }));
                gameSpaces.Add(new Space(0, new int[2] { 5, 10 }));
                gameSpaces.Add(new Space(0, new int[2] { 6, 10 }));
                gameSpaces.Add(new Space(1, new int[2] { 0, 1 }));
                gameSpaces.Add(new Space(3, new int[2] { 7, 8 }));
                break;
            case 1:
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
                break;
            case 2:
                gameSpaces.Add(new Space(0, new int[2] { 3, 9 }));
                gameSpaces.Add(new Space(0, new int[3] { 2, 4, 9 }));
                gameSpaces.Add(new Space(0, new int[2] { 1, 5 }));
                gameSpaces.Add(new Space(0, new int[2] { 0, 6 }));
                gameSpaces.Add(new Space(0, new int[2] { 1, 7 }));
                gameSpaces.Add(new Space(0, new int[2] { 2, 8 }));
                gameSpaces.Add(new Space(0, new int[2] { 3, 7 }));
                gameSpaces.Add(new Space(0, new int[3] { 4, 6, 10 }));
                gameSpaces.Add(new Space(0, new int[2] { 5, 10 }));
                gameSpaces.Add(new Space(1, new int[2] { 0, 1 }));
                gameSpaces.Add(new Space(3, new int[2] { 7, 8 }));
                break;
            case 3:
                gameSpaces.Add(new Space(0, new int[2] { 1, 9 }));
                gameSpaces.Add(new Space(0, new int[2] { 0, 3 }));
                gameSpaces.Add(new Space(0, new int[3] { 4, 5, 9 }));
                gameSpaces.Add(new Space(0, new int[3] { 1, 4, 6 }));
                gameSpaces.Add(new Space(0, new int[3] { 2, 3, 7 }));
                gameSpaces.Add(new Space(0, new int[2] { 2, 7 }));
                gameSpaces.Add(new Space(0, new int[2] { 3, 8 }));
                gameSpaces.Add(new Space(0, new int[3] { 4, 5, 10 }));
                gameSpaces.Add(new Space(0, new int[2] { 6, 10 }));
                gameSpaces.Add(new Space(1, new int[2] { 0, 2 }));
                gameSpaces.Add(new Space(3, new int[2] { 7, 8 }));
                break;
            case 4:
                gameSpaces.Add(new Space(0, new int[1] { 2 }));
                gameSpaces.Add(new Space(0, new int[2] { 2, 3 }));
                gameSpaces.Add(new Space(0, new int[4] { 0, 1, 4, 9 }));
                gameSpaces.Add(new Space(0, new int[2] { 1, 4 }));
                gameSpaces.Add(new Space(0, new int[4] { 2, 3, 5, 6 }));
                gameSpaces.Add(new Space(0, new int[2] { 4, 7 }));
                gameSpaces.Add(new Space(0, new int[4] { 4, 7, 8, 10 }));
                gameSpaces.Add(new Space(0, new int[2] { 5, 6 }));
                gameSpaces.Add(new Space(0, new int[1] { 6 }));
                gameSpaces.Add(new Space(1, new int[1] { 2 }));
                gameSpaces.Add(new Space(3, new int[1] { 6 }));
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

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
                if (SceneManager.GetActiveScene().name == "ingame_plan_r" && gameSpaces[firstMoveParameter].units[1] != 0)
                {
                    commands_r.Add(new Command(1, new int[3] { firstMoveParameter, secondMoveParameter, gameSpaces[firstMoveParameter].units[1] }));
                }
                else if (SceneManager.GetActiveScene().name == "ingame_plan_b" && gameSpaces[firstMoveParameter].units[3] != 0)
                {
                    commands_b.Add(new Command(1, new int[3] { firstMoveParameter, secondMoveParameter, gameSpaces[firstMoveParameter].units[3] }));
                }
            }
        }

        // Debug Block
        if (SceneManager.GetActiveScene().name == "ingame_plan_r")
        {
            if (commands_r.Count != 0)
            {
                Command cbt = commands_r[commands_r.Count - 1];
                Debug.Log("Round " + roundIndex + ", Red: " + cbt.parameters[0].ToString() + " to " + cbt.parameters[1].ToString() + ". No. of Units: " + cbt.parameters[2].ToString());
            }
        }
        else if (SceneManager.GetActiveScene().name == "ingame_plan_b")
        {
            if (commands_b.Count != 0)
            {
                Command cbt = commands_b[commands_b.Count - 1];
                Debug.Log("Round " + roundIndex + ", Blue: " + cbt.parameters[0].ToString() + " to " + cbt.parameters[1].ToString() + ". No. of Units: " + cbt.parameters[2].ToString());
            }
        }

        GameObject.Find("tile_" + firstMoveParameter.ToString().PadLeft(2, '0')).transform.GetComponent<Renderer>().materials[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        GameObject.Find(firstMoveParameter.ToString().PadLeft(2, '0') + "_fig").transform.GetComponent<Renderer>().materials[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
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

        Debug.Log("Change Scene");
        firstMoveParameter = -1;


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
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Renderer>().enabled = false;
            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.name.PadRight(8, '0').Substring(0, 8) == "ability_")
                {
                    go.GetComponent<btn_ability>().visibilityChange(false);
                }
            }
            GameObject.Find("count_energy_e").GetComponent<Renderer>().enabled = false;
            GameObject.Find("count_energy_z").GetComponent<Renderer>().enabled = false;

            SceneManager.LoadScene("ingame_resolve", LoadSceneMode.Single);
        }
    }
}
