using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingame_plan_r : MonoBehaviour
{
    public List<Command> commands_r = new List<Command>();

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.commands_r);
        int[] test = new int[3];
        test[0] = 1;
        test[1] = 2;
        test[2] = 1;
        commands_r.Add(new Command(1, test));    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
