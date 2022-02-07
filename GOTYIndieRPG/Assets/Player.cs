using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	private static Player instance;
	public static Player Instance { get { return instance; } }

	private SpriteRenderer SR;
	public Vector2 speed = new Vector2(6, 6);

	public string charName = "Pepeg";
	public int MaxHP = 50;
	public int currentHP = 50;
	public int blood = 35;

	public bool isPaused = false;

	//public PauseManager PM;
	GameObject[] pauseObjects;
	GameObject pauseScreen;

	private void Start()
	{
		SR = GetComponent<SpriteRenderer>();

		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		pauseObjects = GameObject.FindGameObjectsWithTag("ForPause");
		hidePaused();
	}

	void Update()
	{
		if (Input.GetButtonDown("Status"))
		{
			if (isPaused)
			{
				isPaused = false;
			}
			else
			{
				isPaused = true;
			}
			pause();
		}
	}

	public void FixedUpdate()
	{
		if (!isPaused)
		{
			if (Input.GetButtonDown("Interact"))
			{
				//Interact with stuff
			}

			float inputX = Input.GetAxis("Horizontal");
			float inputY = Input.GetAxis("Vertical");
			Vector2 movement = new Vector2(speed.x * inputX, speed.y * inputY);
			movement = movement * Time.deltaTime;
			transform.Translate(movement);
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		Vector2 lastPosition = gameObject.transform.position;
		if (c.gameObject.tag == "Enemy")
		{
			SceneManager.LoadScene("Battle");
			transform.position = new Vector2(0, 0);
		}
		else if (c.gameObject.tag == "Warp")
		{
			SceneManager.LoadScene("Overworld");
			Vector2 newPosition = new Vector2(lastPosition.x + 3, lastPosition.y);
			transform.position = newPosition;
		}
		else if (c.gameObject.tag == "Flipper")
		{
			if (SR.flipY == true)
			{
				SR.flipY = false;
			}
			else
			{
				SR.flipY = true;
			}
		}
	}
	void pause()
	{
		if (isPaused)
		{
			Time.timeScale = 0f;
			AudioListener.pause = true;
			showPaused();
			//pauseScreen.transform.position = Camera.main.transform.position;
		}
		else
		{
			Time.timeScale = 1;
			AudioListener.pause = false;
			hidePaused();
		}
	}
	public void showPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
			g.transform.position = Camera.main.transform.position;
		}
	}
	public void hidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}
}
