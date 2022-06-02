using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusScreenController : MonoBehaviour

{
    GameObject[] pauseObjects;
    // Start is called before the first frame update
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ForPause");
		foreach (GameObject g in pauseObjects)
		{
			DontDestroyOnLoad(g);
		}

	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPauseObjects()
	{
		Time.timeScale = 0f;
		AudioListener.pause = true;
		//charNameText.text = p.charName;
		//currentHealthText.text = p.currentHP.ToString();
		//maxHealthText.text = p.maxHP.ToString();
		//bloodText.text = p.blood.ToString();

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

}
