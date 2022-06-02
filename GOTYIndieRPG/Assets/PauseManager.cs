using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	public Player p;
	public PauseManager instance;
	public Text charNameText;
	public StatusScreenController SSC;
	//public Text currentHealthText;
	//public Text maxHealthText;
	//public Text bloodText;

	//Without this DontDestroyOnLoad isn't called until you pause once. I don't know if that would actually be a problem or not.
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
	}
	void Start()
    {
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
			SSC.ShowPauseObjects();
		}
		else
		{
			SSC.HidePauseObjects();
		}
	}
}
