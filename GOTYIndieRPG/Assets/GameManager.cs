using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] managers;
    void Start()
    {
        //Resources.Load("Player");
        //Resources.Load("StatusScreen");
        //GameObject player = Resources.Load<GameObject>("Player") as GameObject;
        //Instantiate(player, new Vector2(0, 0), Quaternion.identity);
        //GameObject SSC = Resources.Load<GameObject>("StatusScreen") as GameObject;
        //SSC = Instantiate(SSC, new Vector2(0, 0), Quaternion.identity);

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
}
