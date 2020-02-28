using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class btn_offline : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("menu_mapchoice", LoadSceneMode.Single);
    }
}
