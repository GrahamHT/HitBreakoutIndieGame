using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;

public class Player : MonoBehaviour
{
	private static Player instance;
	public static Player Instance { get { return instance; } }

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Debug.Log("destroying fake player");
			Destroy(this.gameObject);
		}
		else
		{
			Debug.Log("returning existing player");
			instance = this;
		}
	}

	public SpriteRenderer SR;
	public CollisionHandler CH;

	public string charName = "Pepeg";
	public int maxHP = 50;
	public int currentHP = 50;
	public int blood = 35;

	public bool isPaused = false;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		CH.handleCollision(collision);
	}
}
