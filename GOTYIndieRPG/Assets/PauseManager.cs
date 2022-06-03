using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	public Player p;
	public StatusScreenController SSC;

	void Start()
    {

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
