using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_mapbtn : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("ingame_prep_" + this.gameObject.name.Substring(3, 1), LoadSceneMode.Single);
    }
}
