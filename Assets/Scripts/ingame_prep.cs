using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingame_prep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("ingame_resolve", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
