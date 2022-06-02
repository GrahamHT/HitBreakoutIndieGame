using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	public Player p;
	public PauseManager instance;
	public Text charNameText;
	//public Text currentHealthText;
	//public Text maxHealthText;
	//public Text bloodText;

	GameObject[] pauseObjects;
	GameObject pauseScreen;

	//Without this DontDestroyOnLoad isn't called until you pause once. I don't know if that would actually be a problem or not.
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
	}
	void Start()
    {
		pauseObjects = GameObject.FindGameObjectsWithTag("ForPause");
		pause();
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
			//charNameText.text = p.charName;
			//currentHealthText.text = p.currentHP.ToString();
			//maxHealthText.text = p.maxHP.ToString();
			//bloodText.text = p.blood.ToString();

			foreach (GameObject g in pauseObjects)
			{
				g.SetActive(true);
			}
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
