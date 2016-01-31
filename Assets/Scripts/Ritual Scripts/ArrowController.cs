using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

	float speed = 4.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position -= new Vector3(speed, 0.0f);
	}
}
