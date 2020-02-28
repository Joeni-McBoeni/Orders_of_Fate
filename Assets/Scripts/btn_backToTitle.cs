using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_backToTitle : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("menu_start", LoadSceneMode.Single);
    }
}
