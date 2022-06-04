using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Player p;
	public StatusScreenController SSC;
	public Vector2 speed = new Vector2(3,3);
	private void Start()
	{
		//p = GameObject.Find("Player").GetComponent<Player>();
	}

	public void Update()
	{
		if (Input.GetButtonDown("Interact"))
		{
			//Interact with stuff
		}

		if(Input.GetButtonDown("Status"))
		{
			if (p.isPaused)
			{
				p.isPaused = false;
				SSC.HidePauseObjects();
			}
			else
			{
				p.isPaused = true;
				SSC.ShowPauseObjects();
			}
		}

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(speed.x * inputX, speed.y * inputY);
		movement = movement * Time.deltaTime;
		p.transform.Translate(movement);
	}
}
