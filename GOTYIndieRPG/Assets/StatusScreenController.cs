using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatusScreenController : MonoBehaviour

{
	public Player p;
	public Text charNameText, currentHealthText, maxHealthText, bloodText;
    GameObject[] pauseObjects;
    // Start is called before the first frame update
    void Start()
    {
		//p = Player.Instance;
        pauseObjects = GameObject.FindGameObjectsWithTag("ForPause");
		HidePauseObjects();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPauseObjects()
	{
		Time.timeScale = 0f;
		AudioListener.pause = true;
		charNameText.text = p.charName;
		currentHealthText.text = p.currentHP.ToString() + "/" + p.maxHP.ToString();
		//maxHealthText.text = p.maxHP.ToString();
		bloodText.text = p.blood.ToString();

		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
    }

    public void HidePauseObjects()
	{
		Time.timeScale = 1;
		AudioListener.pause = false;
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	public void ResetScene()
	{
		foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
		{
			Destroy(o);
			Debug.Log("Destroyed " + o.name);
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
