using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
	private static Player instance;
	public static Player Instance { get { return instance; } }

	private SpriteRenderer SR;

	public string charName = "Pepeg";
	public int MaxHP = 50;
	public int currentHP = 50;
	public int blood = 35;

	public bool isPaused = false;
	private void Start()
	{
		SR = GetComponent<SpriteRenderer>();

		if (instance != null && instance != this)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Vector2 lastPosition = transform.position;
		if (collision.gameObject.tag == "Enemy")
		{
			SceneManager.LoadScene("Battle");
			onSceneLoad();
			transform.position = new Vector2(0, 0);
		}
		else if (collision.gameObject.tag == "Warp")
		{
			SceneManager.LoadScene("Overworld");
			onSceneLoad();
			Vector2 newPosition = new Vector2(lastPosition.x + 3, lastPosition.y);
			transform.position = newPosition;
		}
		else if (collision.gameObject.tag == "Flipper")
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


	//this is awful and also doesn't work
	private void onSceneLoad()
	{
		Debug.Log(SceneManager.GetActiveScene().name.ToString());
		GameObject[] toMove;
		toMove = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject g in toMove)
		{
			SceneManager.MoveGameObjectToScene(g, SceneManager.GetActiveScene());
		}
	}
}
