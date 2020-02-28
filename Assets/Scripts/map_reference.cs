using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_reference : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
