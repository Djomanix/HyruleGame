using UnityEngine;
using System.Collections;

public class ZControlScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		Vector3 temp = transform.position;

		temp.z = -2;
		transform.position = temp;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Vector3 temp = transform.position;
		
		temp.z = 2;
		transform.position = temp;
	}
}
