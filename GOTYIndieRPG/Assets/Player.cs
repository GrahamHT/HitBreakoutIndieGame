using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;

public class Player : MonoBehaviour
{
	private static Player instance;
	public static Player Instance
	{
		get
		{
			if (instance == null)
			{
				Debug.Log("Creating new player instance");
				instance = GameObject.FindObjectOfType<Player>();
			}
			Debug.Log("Returning existing player instance");
			return instance;
		}
	}

	public SpriteRenderer SR;
	public CollisionHandler CH;

	public string charName = "Pepeg";
	public int maxHP = 50;
	public int currentHP = 50;
	public int blood = 35;

	public bool isPaused = false;
	private void Start()
	{
		SR = GetComponent<SpriteRenderer>();
		CH = GetComponent<CollisionHandler>();

		if (instance != null && instance != this)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		CH.handleCollision(collision);
	}
}
