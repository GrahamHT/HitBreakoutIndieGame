using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager : MonoBehaviour
{
    public Transform target;
	public float YOffset;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.gameObject.transform.position = target.position;
		Vector3 newPosition = new Vector3(target.transform.position.x, target.transform.position.y + YOffset, 0f);
		collision.gameObject.transform.localPosition = newPosition;
	}
	
}
