using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingame_plan_b : MonoBehaviour
{
    public List<Command> commands_b = new List<Command>();

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.commands_b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
