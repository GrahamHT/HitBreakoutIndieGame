using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestingResetButtonManager : MonoBehaviour
{
    // Reloads the current scene for testing purposes
    public void ResetScene()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
