using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_nextTurn : MonoBehaviour
{
    public List<Command> commands_r = new List<Command>();
    public List<Command> commands_b = new List<Command>();

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

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
            SceneManager.LoadScene("ingame_resolve", LoadSceneMode.Single);
        }
    }
}
