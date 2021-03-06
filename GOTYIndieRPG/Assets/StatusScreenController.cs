using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatusScreenController : MonoBehaviour
{
	private static StatusScreenController instance;
	public static StatusScreenController Instance { get { return instance; } }
	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Debug.Log("destroying fake SSC");
			Destroy(this.gameObject);
		}
		else
		{
			Debug.Log("returning existing SSC");
			instance = this;
		}
	}
	public Text charNameText, currentHealthText, maxHealthText, bloodText;
    GameObject[] pauseObjects;
    // Start is called before the first frame update
    void Start()
    {
		pauseObjects = GameObject.FindGameObjectsWithTag("ForPause");
		HidePauseObjects();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPauseObjects()
	{
		Time.timeScale = 0f;
		AudioListener.pause = true;
		charNameText.text = Player.Instance.charName;
		currentHealthText.text = Player.Instance.currentHP.ToString() + "/" + Player.Instance.maxHP.ToString();
		//maxHealthText.text = Player.Instance.maxHP.ToString();
		bloodText.text = Player.Instance.blood.ToString();

		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
    }

    public void HidePauseObjects()
	{
		Time.timeScale = 1;
		AudioListener.pause = false;
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	public void ResetScene()
	{
		foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
		{
			Debug.Log("Checking for DDOL");
			if((gameObject.GetComponent("DDOL") as DDOL) == null)
			{
				Destroy(o);
				Debug.Log("Destroyed " + o.name);
			}
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Player.Instance.gameObject.transform.position = new Vector2(0, 0);
		StatusScreenController.Instance.gameObject.transform.position = new Vector2(0, 0);
		this.gameObject.transform.position = new Vector2(0, 0);
	}

}
