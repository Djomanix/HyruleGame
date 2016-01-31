using UnityEngine;
using System.Collections;

public class ZControlScript : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Player")
			other.GetComponent<Renderer>().sortingOrder = 
				GetComponent<Renderer>().sortingOrder - 1;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<Renderer>().sortingOrder = 
				GetComponent<Renderer>().sortingOrder + 1;
		}
	}
}
