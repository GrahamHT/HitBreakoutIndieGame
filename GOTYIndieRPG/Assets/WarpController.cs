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

	private void Awake()
	{

	}
	public void WarpPlayer(Collider2D collision)
	{
		if (collision.gameObject.tag == "LocalWarp")
		{
			Vector2 newPosition = new Vector2(target.transform.position.x, target.transform.position.y + YOffset);
			Player.Instance.gameObject.transform.position = newPosition;
		}
		else if (collision.gameObject.tag == "GlobalWarp")
		{
			if (SceneUtility.GetBuildIndexByScenePath(SceneToLoad) >= 0)
			{
				SceneManager.LoadScene(SceneToLoad);
			}
			else
			{
				Debug.Log("Scene is invalid");
			}
		}
	}
}
