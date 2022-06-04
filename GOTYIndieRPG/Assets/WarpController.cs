using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WarpController : MonoBehaviour
{
    public Transform target;
	public float YOffset;
	public string SceneToLoad;

	private void Start()
	{

	}
	public void WarpPlayer(Collider2D collision)
	{
		if (collision.gameObject.tag == "LocalWarp")
		{
			collision.gameObject.transform.position = target.position;
			Vector3 newPosition = new Vector3(target.transform.position.x, target.transform.position.y + YOffset, 0f);
			Debug.Log("d");
			collision.gameObject.transform.localPosition = newPosition;
		} 
		else if (collision.gameObject.tag == "GlobalWarp")
		{
			SceneToLoad = collision.gameObject.GetComponent<Text>().text;
			SceneManager.LoadScene(SceneToLoad);
			//Vector2 newPosition = new Vector2(lastPosition.x + 3, lastPosition.y);
			//transform.position = newPosition;
		}
	}

}
