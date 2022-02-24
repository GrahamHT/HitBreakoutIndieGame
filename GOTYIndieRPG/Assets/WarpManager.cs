using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager : MonoBehaviour
{
	//public Player p;
    public Transform target;
	public float YOffset;

	private void Start()
	{
		DontDestroyOnLoad(this);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.gameObject.transform.position = target.position;
		Vector3 newPosition = new Vector3(target.transform.position.x, target.transform.position.y + YOffset, 0f);
		collision.gameObject.transform.localPosition = newPosition;
	}

}
