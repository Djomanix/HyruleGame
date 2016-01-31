using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//print (tag);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log ("Hit " + tag);

		if(Input.GetKeyDown(KeyCode.UpArrow) && tag == "up")
		{
			//print ("Up Get");
			Destroy(other.gameObject);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow) && tag == "down")
		{
			//print ("Down get");
			Destroy(other.gameObject);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "left")
		{
			//print ("Left get");
			Destroy(other.gameObject);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "right")
		{
			//print ("Right get");
			Destroy(other.gameObject);
		}
	}
}
