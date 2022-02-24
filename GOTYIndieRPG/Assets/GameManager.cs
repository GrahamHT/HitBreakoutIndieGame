using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] managers;
    void Start()
    {
        managers = GameObject.FindGameObjectsWithTag("Manager");
        foreach (GameObject m in managers)
        {
            DontDestroyOnLoad(m);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
