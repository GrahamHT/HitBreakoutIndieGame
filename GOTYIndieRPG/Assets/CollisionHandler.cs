using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
	public WarpController WC;
    void Start()
    {
		WC = GetComponent<WarpController>();
	}

    void Update()
    {
        
    }

    public void handleCollision(Collider2D collision)
	{
		Vector2 lastPosition = transform.position;
		if (collision.gameObject.tag == "Enemy")
		{
			SceneManager.LoadScene("Battle");
			//onSceneLoad();
			transform.position = new Vector2(0, 0);
		}
		else if (collision.gameObject.tag == "GlobalWarp" || collision.gameObject.tag == "LocalWarp")
		{
			WarpController targetWC = collision.gameObject.GetComponent(typeof(WarpController)) as WarpController;
			targetWC.WarpPlayer(collision);
		}
	}
}
