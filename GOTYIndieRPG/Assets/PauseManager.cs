using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
	public Player p;
	GameObject[] pauseObjects;
	GameObject pauseScreen;
	void Start()
    {
		//p = GameObject.Find("Player").GetComponent<Player>();
		//pauseScreen = Instantiate(Resources.Load("PauseScreen")) as GameObject;
		pauseObjects = GameObject.FindGameObjectsWithTag("ForPause");
		DontDestroyOnLoad(this);
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetButtonDown("Status"))
		{
			if (p.isPaused)
			{
				p.isPaused = false;
			}
			else
			{
				p.isPaused = true;
			}
			pause();
		}
	}
	void pause()
	{
		if (p.isPaused)
		{
			Time.timeScale = 0f;
			AudioListener.pause = true;
			foreach (GameObject g in pauseObjects)
			{
				g.SetActive(true);
			}
			//pauseScreen.transform.position = Camera.main.transform.position;
		}
		else
		{
			Time.timeScale = 1;
			AudioListener.pause = false;
			foreach (GameObject g in pauseObjects)
			{
				g.SetActive(false);
			}
		}
	}
}
