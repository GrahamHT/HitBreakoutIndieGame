using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	private static Player instance;
	private SpriteRenderer SR;
	public static Player Instance { get { return instance; } }
	public Vector2 speed = new Vector2(6, 6);

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
	}

	public void FixedUpdate()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(speed.x * inputX, speed.y * inputY);
		movement = movement * Time.deltaTime;
		transform.Translate(movement);
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
			Vector2 newPosition= new Vector2(lastPosition.x + 3, lastPosition.y);
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
}
