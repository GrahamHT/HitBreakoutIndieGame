using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Vector2 speed = new Vector2(3, 3);

	public void Update()
	{
		if (Input.GetButtonDown("Interact"))
		{
			//Interact with stuff
		}

		if(Input.GetButtonDown("Status"))
		{
			if (Player.Instance.isPaused)
			{
				Player.Instance.isPaused = false;
				StatusScreenController.Instance.HidePauseObjects();
			}
			else
			{
				Player.Instance.isPaused = true;
				StatusScreenController.Instance.ShowPauseObjects();
			}
		}

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(speed.x * inputX, speed.y * inputY);
		movement = movement * Time.deltaTime;
		Player.Instance.transform.Translate(movement);
	}
}
