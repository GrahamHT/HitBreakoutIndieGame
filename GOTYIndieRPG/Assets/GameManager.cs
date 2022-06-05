using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("destroying fake gameManager");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("returning existing gamemanager");
            instance = this;
        }
    }

    void Start()
    {
        Resources.Load("Player");
        Resources.Load("StatusScreen");
        GameObject player = Resources.Load<GameObject>("Player") as GameObject;
        Instantiate(player, new Vector2(0, 0), Quaternion.identity);
        GameObject SSC = Resources.Load<GameObject>("StatusScreen") as GameObject;
        SSC = Instantiate(SSC, new Vector2(0, 0), Quaternion.identity);
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
        Debug.Log("Loaded scene: " + scene.name);
    }
}
