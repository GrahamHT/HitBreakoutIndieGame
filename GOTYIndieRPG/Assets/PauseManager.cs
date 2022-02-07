//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PauseManager : MonoBehaviour
//{
//	Player player;
//	GameObject[] pauseObjects;
//	GameObject pauseScreen;
//	void Start()
//    {
//		player = FindObjectOfType(typeof(Player)) as Player;
//		pauseScreen = Instantiate(Resources.Load("PauseScreen")) as GameObject;
//		pauseObjects = GameObject.FindGameObjectsWithTag("ForPause");
//		hidePaused();
//	}

//	// Update is called once per frame
//	void Update()
//    {
//		if (Input.GetButtonDown("Status"))
//		{
//			if (player.isPaused)
//			{
//				player.isPaused = false;
//			}
//			else
//			{
//				player.isPaused = true;
//			}
//			pause();
//		}
//	}
//	void pause()
//	{
//		if (player.isPaused)
//		{
//			Time.timeScale = 0f;
//			AudioListener.pause = true;
//			showPaused();
//			pauseScreen.transform.position = Camera.main.transform.position;
//		}
//		else
//		{
//			Time.timeScale = 1;
//			AudioListener.pause = false;
//			hidePaused();
//		}
//	}
//	public void showPaused()
//	{
//		foreach (GameObject g in pauseObjects)
//		{
//			g.SetActive(true);
//		}
//	}
//	public void hidePaused()
//	{
//		foreach (GameObject g in pauseObjects)
//		{
//			g.SetActive(false);
//		}
//	}
//}
