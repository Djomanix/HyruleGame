using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitScript : MonoBehaviour {

	public GameObject gameController;

	int value;

	// Use this for initialization
	void Start () {
		//print (tag);
		value = 25;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerExit2D(Collider2D other)
	{
		gameController.GetComponent<RitualController>().UpdateScore(-value);
	}

	void OnTriggerStay2D(Collider2D other)
	{

		if(Input.GetKeyDown(KeyCode.UpArrow) && tag == "up")
		{
			//print ("Up Get");
			gameController.GetComponent<RitualController>().UpdateScore(value);
			Destroy(other.gameObject);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow) && tag == "down")
		{
			//print ("Down get");
			gameController.GetComponent<RitualController>().UpdateScore(value);
			Destroy(other.gameObject);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "left")
		{
			//print ("Left get");
			gameController.GetComponent<RitualController>().UpdateScore(value);
			Destroy(other.gameObject);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "right")
		{
			//print ("Right get");
			gameController.GetComponent<RitualController>().UpdateScore(value);
			Destroy(other.gameObject);
		}
	}
}
