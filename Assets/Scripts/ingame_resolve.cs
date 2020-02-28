using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingame_resolve : MonoBehaviour
{
    public List<Command> commands_r = new List<Command>();
    public List<Command> commands_b = new List<Command>();
    int debugCycleIndex = 0;
    public Sprite[] spritesForMaps;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spritesForMaps[GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().mapNumber];

        commands_r = GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_r;
        commands_b = GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_b;

        syncCommands();
        drawBoard();

        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        for (int counter = 0; counter < commands_r.Count; counter++)
        {
            yield return new WaitForSeconds(1.2f);

            commands_r[counter].doCommand(1, commands_b[counter]);
            commands_b[counter].doCommand(3, commands_r[counter]);

            drawBoard();

            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().plagueInEffect[0] = false;
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().plagueInEffect[1] = false;
        }

        yield return new WaitForSeconds(1.0f);

        endTurn();
    }

        // Update is called once per frame
    void Update()
    {
        
    }

    public void drawBoard()
    {
        int spaceNumber = 0;

        foreach (Space currentSpace in GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces)
        {
            plagueCheck(currentSpace);

            int previousspace = currentSpace.type;
            string paddedSpaceNumber = spaceNumber.ToString().PadLeft(2, '0');

            currentSpace.battle();

            if(previousspace != currentSpace.type)
            {
                GameObject.Find("tile_" + paddedSpaceNumber).GetComponent<btn_space>().spriteChange(currentSpace.type);
            }

            int renderInfoActive = 0;
            if(currentSpace.units[1] + currentSpace.units[2] + currentSpace.units[3] + currentSpace.units[4] != 0)
            {
                renderInfoActive = (currentSpace.type + 1) / 2;
                GameObject.Find(paddedSpaceNumber + "_fig").GetComponent<BoxCollider2D>().enabled = true;
                GameObject.Find(paddedSpaceNumber + "_fig").GetComponent<Renderer>().enabled = true;
                GameObject.Find(paddedSpaceNumber + "_count_active_e").GetComponent<Renderer>().enabled = true;
                GameObject.Find(paddedSpaceNumber + "_count_active_z").GetComponent<Renderer>().enabled = true;
                GameObject.Find(paddedSpaceNumber + "_count_passive_e").GetComponent<Renderer>().enabled = true;
                GameObject.Find(paddedSpaceNumber + "_count_passive_z").GetComponent<Renderer>().enabled = true;

                if (currentSpace.units[1] + currentSpace.units[3] == 0)
                {
                    GameObject.Find(paddedSpaceNumber + "_fig").transform.GetComponent<Renderer>().materials[0].color = new Color(0.8f, 0.8f, 0.8f, 1.0f);
                }
                else
                {
                    GameObject.Find(paddedSpaceNumber + "_fig").transform.GetComponent<Renderer>().materials[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }

            switch (renderInfoActive)
            {
                case 1:
                    GameObject.Find(paddedSpaceNumber + "_fig").GetComponent<fig_OnClick>().changeSprite(1);
                    GameObject.Find(paddedSpaceNumber + "_count_active_e").GetComponent<number_changer>().changeNumber(currentSpace.units[1] % 10);
                    GameObject.Find(paddedSpaceNumber + "_count_active_z").GetComponent<number_changer>().changeNumber(currentSpace.units[1] / 10);
                    GameObject.Find(paddedSpaceNumber + "_count_passive_e").GetComponent<number_changer>().changeNumber(currentSpace.units[2] % 10);
                    GameObject.Find(paddedSpaceNumber + "_count_passive_z").GetComponent<number_changer>().changeNumber(currentSpace.units[2] / 10);
                    break;
                case 2:
                    GameObject.Find(paddedSpaceNumber + "_fig").GetComponent<fig_OnClick>().changeSprite(3);
                    GameObject.Find(paddedSpaceNumber + "_count_active_e").GetComponent<number_changer>().changeNumber(currentSpace.units[3] % 10);
                    GameObject.Find(paddedSpaceNumber + "_count_active_z").GetComponent<number_changer>().changeNumber(currentSpace.units[3] / 10);
                    GameObject.Find(paddedSpaceNumber + "_count_passive_e").GetComponent<number_changer>().changeNumber(currentSpace.units[4] % 10);
                    GameObject.Find(paddedSpaceNumber + "_count_passive_z").GetComponent<number_changer>().changeNumber(currentSpace.units[4] / 10);
                    break;
                default:
                    GameObject.Find(paddedSpaceNumber + "_fig").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find(paddedSpaceNumber + "_fig").GetComponent<Renderer>().enabled = false;
                    GameObject.Find(paddedSpaceNumber + "_count_active_e").GetComponent<Renderer>().enabled = false;
                    GameObject.Find(paddedSpaceNumber + "_count_active_z").GetComponent<Renderer>().enabled = false;
                    GameObject.Find(paddedSpaceNumber + "_count_passive_e").GetComponent<Renderer>().enabled = false;
                    GameObject.Find(paddedSpaceNumber + "_count_passive_z").GetComponent<Renderer>().enabled = false;
                    break;
            }

            spaceNumber++;
        }

        debugCycleIndex++;
    }

    private void plagueCheck(Space currentSpace)
    {
        if(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().plagueInEffect[0] == true)
        {
            if (currentSpace.units[3] != 0)
            {
                currentSpace.units[3]--;
            }
            else if (currentSpace.units[4] != 0)
            {
                currentSpace.units[4]--;
            }
        }

        if (GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().plagueInEffect[1] == true)
        {
            if (currentSpace.units[1] != 0)
            {
                currentSpace.units[1]--;
            }
            else if (currentSpace.units[2] != 0)
            {
                currentSpace.units[2]--;
            }
        }
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

        if (GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[10].type == 1)
        {
            destroyEverythingInDontDestroyOnLoad();

            if(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[9].type == 3)
            {
                Debug.Log("draw lmao");
                SceneManager.LoadScene("draw_lmao", LoadSceneMode.Single);
            }
            else 
            {
                Debug.Log("redwon lmao");
                SceneManager.LoadScene("redwon", LoadSceneMode.Single);
            }
        }
        else if(GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().gameSpaces[9].type == 3)
        {
            destroyEverythingInDontDestroyOnLoad();

            Debug.Log("bluwon lmao");
            SceneManager.LoadScene("bluwon", LoadSceneMode.Single);
        }
        else
        {
            GameObject.Find("btn_next_turn").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("btn_next_turn").GetComponent<Renderer>().enabled = true;

            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_r = new List<Command>();
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().commands_b = new List<Command>();
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_r++;
            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().energy_b++;

            GameObject.Find("btn_next_turn").GetComponent<btn_nextTurn>().roundIndex++;
            SceneManager.LoadScene("ingame_plan_r", LoadSceneMode.Single);
        }
    }

    private void destroyEverythingInDontDestroyOnLoad()
    {
        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        foreach (var root in go.scene.GetRootGameObjects())
        {
            Destroy(root);
        }
    }
}
