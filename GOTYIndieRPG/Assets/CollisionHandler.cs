using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
	public Player p;
	public WarpController WC;
    // Start is called before the first frame update
    void Start()
    {
		WC = GetComponent<WarpController>();
	}

    // Update is called once per frame
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
		else if (collision.gameObject.tag == "Flipper")
		{
			if (p.SR.flipY == true)
			{
				p.SR.flipY = false;
			}
			else
			{
				p.SR.flipY = true;
			}
		}
	}
}
